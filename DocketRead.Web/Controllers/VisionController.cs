using System.Web.Http;
using DocketRead.DocketReader;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Microsoft.FSharp.Collections;
using System.Linq;
using System.Web.Mvc;
using System.IO;

namespace WebApplication1.Controllers
{
    public class VisionController : ApiController
    {
        public async Task<ActionResult> Post()
        {
            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);
            var c = new Vision();

            FSharpList<Types.LineDetails> result = FSharpList<Types.LineDetails>.Empty;
            foreach (var file in provider.Contents)
            {
                var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                var buffer = await file.ReadAsByteArrayAsync();
                result = c.GetFromBytes(buffer);
                //Do whatever you want with filename and its binaray data.
            }

            return BuildFile(result);
        }

        private ActionResult BuildFile(FSharpList<Types.LineDetails> lineDetails)
        {
            using (var ms = new MemoryStream())
            {
                using (var tw = new StreamWriter(ms))
                {
                    foreach (var listItem in lineDetails)
                    {
                        var priceText = listItem.Price?.Value.Description ?? string.Empty;
                        if (priceText.Length > 0)
                        {
                            priceText = priceText + ",";
                        }

                        if (listItem.Text.Length > 0)
                        {
                            tw.WriteLine($"{listItem.Text},{priceText}");
                        }
                    }

                    tw.Flush();
                }

                
                return new FileStreamResult(ms, "text/plain");
            }
        }
    }
}
