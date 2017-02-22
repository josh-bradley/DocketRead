module Types

type AnnotationVerticy = { X: int; Y: int }
type Annotation = { Description: string; Verticies: AnnotationVerticy list}

type Price = Annotation
type LineDetails = { Text: string; Annotations: Annotation list; Price: Option<Price> }

type Verticy = TopLeft | TopRight | BottomLeft | BottomRight

let getPoint v (anno : Annotation) = 
    let idx =  match v with 
                | TopLeft -> 0
                | TopRight -> 1
                | BottomRight -> 2
                | BottomLeft -> 3

    anno.Verticies.[idx]

let getTopLeftPoint = getPoint TopLeft
let getTopRightPoint = getPoint TopRight
let getBottomLeftPoint = getPoint BottomLeft
let getBottomRightPoint = getPoint BottomRight

let getDummyData = 
    [{Description = "TRADITIONAL BREAD WHOLEMEAL 750G
        JUICE B LBLGRAPEFRUIT 1.5L
        SPROUT ALFALFA 125G P/P
        GEA
        BABy SpN RUC 60G CARROT
        0.642 kg NET
        $2.50/kg
        FR CHICKEN BREAST FILLET SML RW
        TRUSS RED
        0.222 kg NET
        $8.90/kg
        SMOKED BEEF PASTRAMI
        CUPS LOOSE
        kg NET $10.98/kg
        MED JOOL DATES 450G
        CAVENDISH
        1.097 kg NET
        $3.90/kg
        RED LOOSE
        kg NET $4.00/kg
        HASS
        3.50
        5.00
        2.20
        2.00
        1.61
        11.50
        4.35
        2.57
        10.00
        4.28
        "; Verticies = [{X = 63; Y = 17};{X = 2444; Y = 17};{X = 2444; Y = 2473};{X = 63; Y = 2473}]};
        {Description = "TRADITIONAL"; Verticies = [{X = 361; Y = 137};{X = 795; Y = 99};{X = 806; Y = 225};{X = 372; Y = 263}]};
        {Description = "BREAD"; Verticies = [{X = 852; Y = 95};{X = 1071; Y = 76};{X = 1082; Y = 201};{X = 863; Y = 221}]};
        {Description = "WHOLEMEAL"; Verticies = [{X = 1112; Y = 71};{X = 1503; Y = 37};{X = 1513; Y = 162};{X = 1123; Y = 197}]};
        {Description = "750G"; Verticies = [{X = 1550; Y = 33};{X = 1732; Y = 17};{X = 1743; Y = 143};{X = 1561; Y = 159}]};
        {Description = "JUICE"; Verticies = [{X = 438; Y = 261};{X = 644; Y = 243};{X = 655; Y = 363};{X = 448; Y = 381}]};
        {Description = "B"; Verticies = [{X = 685; Y = 240};{X = 733; Y = 236};{X = 743; Y = 355};{X = 695; Y = 360}]};
        {Description = "LBLGRAPEFRUIT"; Verticies = [{X = 769; Y = 232};{X = 1319; Y = 184};{X = 1329; Y = 303};{X = 779; Y = 352}]};
        {Description = "1.5L"; Verticies = [{X = 1365; Y = 180};{X = 1541; Y = 165};{X = 1552; Y = 284};{X = 1375; Y = 300}]};
        {Description = "SPROUT"; Verticies = [{X = 70; Y = 362};{X = 315; Y = 362};{X = 315; Y = 509};{X = 70; Y = 509}]};
        {Description = "ALFALFA"; Verticies = [{X = 351; Y = 391};{X = 649; Y = 378};{X = 654; Y = 493};{X = 356; Y = 506}]};
        {Description = "125G"; Verticies = [{X = 694; Y = 376};{X = 851; Y = 369};{X = 856; Y = 484};{X = 699; Y = 491}]};
        {Description = "P/P"; Verticies = [{X = 903; Y = 362};{X = 1021; Y = 362};{X = 1021; Y = 509};{X = 903; Y = 509}]};
        {Description = "GEA"; Verticies = [{X = 1184; Y = 452};{X = 1313; Y = 441};{X = 1323; Y = 560};{X = 1194; Y = 572}]};
        {Description = "BABy"; Verticies = [{X = 476; Y = 514};{X = 641; Y = 500};{X = 652; Y = 619};{X = 486; Y = 634}]};
        {Description = "SpN"; Verticies = [{X = 683; Y = 496};{X = 805; Y = 485};{X = 815; Y = 605};{X = 693; Y = 616}]};
        {Description = "RUC"; Verticies = [{X = 846; Y = 481};{X = 972; Y = 470};{X = 982; Y = 590};{X = 856; Y = 601}]};
        {Description = "60G"; Verticies = [{X = 1013; Y = 467};{X = 1144; Y = 456};{X = 1154; Y = 575};{X = 1023; Y = 587}]};
        {Description = "CARROT"; Verticies = [{X = 63; Y = 676};{X = 318; Y = 665};{X = 322; Y = 755};{X = 67; Y = 766}]};
        {Description = "0.642"; Verticies = [{X = 107; Y = 785};{X = 310; Y = 785};{X = 310; Y = 889};{X = 107; Y = 889}]};
        {Description = "kg"; Verticies = [{X = 353; Y = 785};{X = 434; Y = 785};{X = 434; Y = 889};{X = 353; Y = 889}]};
        {Description = "NET"; Verticies = [{X = 475; Y = 785};{X = 601; Y = 785};{X = 601; Y = 889};{X = 475; Y = 889}]};
        {Description = "$2.50/kg"; Verticies = [{X = 895; Y = 746};{X = 1230; Y = 746};{X = 1230; Y = 857};{X = 895; Y = 857}]};
        {Description = "FR"; Verticies = [{X = 312; Y = 908};{X = 395; Y = 904};{X = 400; Y = 1012};{X = 317; Y = 1016}]};
        {Description = "CHICKEN"; Verticies = [{X = 434; Y = 903};{X = 725; Y = 890};{X = 729; Y = 998};{X = 439; Y = 1011}]};
        {Description = "BREAST"; Verticies = [{X = 763; Y = 888};{X = 1014; Y = 877};{X = 1018; Y = 985};{X = 768; Y = 996}]};
        {Description = "FILLET"; Verticies = [{X = 1055; Y = 875};{X = 1315; Y = 864};{X = 1319; Y = 972};{X = 1060; Y = 983}]};
        {Description = "SML"; Verticies = [{X = 1362; Y = 862};{X = 1503; Y = 856};{X = 1508; Y = 964};{X = 1367; Y = 970}]};
        {Description = "RW"; Verticies = [{X = 1552; Y = 853};{X = 1643; Y = 849};{X = 1648; Y = 957};{X = 1557; Y = 961}]};
        {Description = "TRUSS"; Verticies = [{X = 355; Y = 1038};{X = 563; Y = 1034};{X = 565; Y = 1138};{X = 357; Y = 1142}]};
        {Description = "RED"; Verticies = [{X = 597; Y = 1033};{X = 723; Y = 1030};{X = 725; Y = 1134};{X = 599; Y = 1137}]};
        {Description = "0.222"; Verticies = [{X = 96; Y = 1168};{X = 304; Y = 1168};{X = 304; Y = 1274};{X = 96; Y = 1274}]};
        {Description = "kg"; Verticies = [{X = 345; Y = 1163};{X = 433; Y = 1161};{X = 436; Y = 1281};{X = 348; Y = 1283}]};
        {Description = "NET"; Verticies = [{X = 474; Y = 1168};{X = 597; Y = 1168};{X = 597; Y = 1274};{X = 474; Y = 1274}]};
        {Description = "$8.90/kg"; Verticies = [{X = 893; Y = 1150};{X = 1228; Y = 1150};{X = 1228; Y = 1255};{X = 893; Y = 1255}]};
        {Description = "SMOKED"; Verticies = [{X = 346; Y = 1287};{X = 597; Y = 1283};{X = 599; Y = 1395};{X = 348; Y = 1399}]};
        {Description = "BEEF"; Verticies = [{X = 640; Y = 1282};{X = 800; Y = 1279};{X = 802; Y = 1391};{X = 642; Y = 1394}]};
        {Description = "PASTRAMI"; Verticies = [{X = 841; Y = 1278};{X = 1179; Y = 1273};{X = 1181; Y = 1385};{X = 843; Y = 1390}]};
        {Description = "CUPS"; Verticies = [{X = 424; Y = 1424};{X = 598; Y = 1424};{X = 598; Y = 1525};{X = 424; Y = 1525}]};
        {Description = "LOOSE"; Verticies = [{X = 637; Y = 1424};{X = 840; Y = 1424};{X = 840; Y = 1525};{X = 637; Y = 1525}]};
        {Description = "kg"; Verticies = [{X = 343; Y = 1560};{X = 429; Y = 1560};{X = 429; Y = 1671};{X = 343; Y = 1671}]};
        {Description = "NET"; Verticies = [{X = 474; Y = 1560};{X = 599; Y = 1560};{X = 599; Y = 1671};{X = 474; Y = 1671}]};
        {Description = "$10.98/kg"; Verticies = [{X = 838; Y = 1560};{X = 1226; Y = 1560};{X = 1226; Y = 1671};{X = 838; Y = 1671}]};
        {Description = "MED"; Verticies = [{X = 296; Y = 1692};{X = 431; Y = 1692};{X = 431; Y = 1792};{X = 296; Y = 1792}]};
        {Description = "JOOL"; Verticies = [{X = 450; Y = 1692};{X = 596; Y = 1692};{X = 596; Y = 1792};{X = 450; Y = 1792}]};
        {Description = "DATES"; Verticies = [{X = 631; Y = 1692};{X = 846; Y = 1692};{X = 846; Y = 1792};{X = 631; Y = 1792}]};
        {Description = "450G"; Verticies = [{X = 889; Y = 1692};{X = 1051; Y = 1692};{X = 1051; Y = 1792};{X = 889; Y = 1792}]};
        {Description = "CAVENDISH"; Verticies = [{X = 340; Y = 1823};{X = 717; Y = 1823};{X = 717; Y = 1925};{X = 340; Y = 1925}]};
        {Description = "1.097"; Verticies = [{X = 70; Y = 1957};{X = 290; Y = 1957};{X = 290; Y = 2061};{X = 70; Y = 2061}]};
        {Description = "kg"; Verticies = [{X = 338; Y = 1942};{X = 429; Y = 1946};{X = 424; Y = 2070};{X = 333; Y = 2066}]};
        {Description = "NET"; Verticies = [{X = 469; Y = 1957};{X = 594; Y = 1957};{X = 594; Y = 2061};{X = 469; Y = 2061}]};
        {Description = "$3.90/kg"; Verticies = [{X = 891; Y = 1968};{X = 1226; Y = 1968};{X = 1226; Y = 2091};{X = 891; Y = 2091}]};
        {Description = "RED"; Verticies = [{X = 288; Y = 2088};{X = 432; Y = 2088};{X = 432; Y = 2195};{X = 288; Y = 2195}]};
        {Description = "LOOSE"; Verticies = [{X = 465; Y = 2088};{X = 671; Y = 2088};{X = 671; Y = 2195};{X = 465; Y = 2195}]};
        {Description = "kg"; Verticies = [{X = 333; Y = 2217};{X = 427; Y = 2221};{X = 421; Y = 2351};{X = 327; Y = 2347}]};
        {Description = "NET"; Verticies = [{X = 471; Y = 2223};{X = 595; Y = 2228};{X = 589; Y = 2358};{X = 465; Y = 2353}]};
        {Description = "$4.00/kg"; Verticies = [{X = 878; Y = 2240};{X = 1233; Y = 2255};{X = 1227; Y = 2385};{X = 872; Y = 2370}]};
        {Description = "HASS"; Verticies = [{X = 371; Y = 2354};{X = 554; Y = 2345};{X = 560; Y = 2462};{X = 377; Y = 2471}]};
        {Description = "3.50"; Verticies = [{X = 2255; Y = 33};{X = 2432; Y = 17};{X = 2441; Y = 120};{X = 2264; Y = 136}]};
        {Description = "5.00"; Verticies = [{X = 2250; Y = 169};{X = 2433; Y = 153};{X = 2443; Y = 263};{X = 2260; Y = 279}]};
        {Description = "2.20"; Verticies = [{X = 2247; Y = 314};{X = 2432; Y = 298};{X = 2442; Y = 405};{X = 2256; Y = 422}]};
        {Description = "2.00"; Verticies = [{X = 2245; Y = 458};{X = 2430; Y = 442};{X = 2439; Y = 545};{X = 2254; Y = 562}]};
        {Description = "1.61"; Verticies = [{X = 2249; Y = 734};{X = 2420; Y = 727};{X = 2424; Y = 827};{X = 2253; Y = 835}]};
        {Description = "11.50"; Verticies = [{X = 2202; Y = 864};{X = 2421; Y = 857};{X = 2425; Y = 968};{X = 2206; Y = 975}]};
        {Description = "4.35"; Verticies = [{X = 2237; Y = 1283};{X = 2408; Y = 1268};{X = 2417; Y = 1368};{X = 2246; Y = 1383}]};
        {Description = "2.57"; Verticies = [{X = 2235; Y = 1557};{X = 2402; Y = 1542};{X = 2411; Y = 1640};{X = 2244; Y = 1655}]};
        {Description = "10.00"; Verticies = [{X = 2209; Y = 1679};{X = 2407; Y = 1688};{X = 2402; Y = 1793};{X = 2204; Y = 1784}]};
        {Description = "4.28"; Verticies = [{X = 2248; Y = 1953};{X = 2408; Y = 1960};{X = 2403; Y = 2066};{X = 2243; Y = 2059}]}
        ]

let getDocket3 = 
    [{Description = "WOOLWORTHS IAX INVOICE ABN 88 000 014 b/b
HELGAS TRADITIONAL BREAD WHOLEME AL 750G
5.00
ORIGINAL JUICE B/LBLGRAPEFRUIT 1.5L.
2.20
SPROUT ALFALFA 125G P/P
2.00
F/C SALAD BABY SpN RUC 60G 6EA
CARROT
1.61
0.642 kg NET $2.50/kg
MACRO FR CHICKEN BREASI FILLET SML RW
11.50
TOMATO TRUSS RED
1.98
0.222 kg NET $8.90/kg
4.35
SELECT SMOKED BEEF PASTRAMI
MUSHROOM CUPS LOOSE
2.57
0.234 kg NET $10.98/kg
10.00
SNACK MEDJOOL DATES 450G
BANANA CAVENDISH
1.097 kg NET $3.90/kg
ONION RED LOOSE
0.71
0.177 kg NET $4.00/kg
AVOCADO HASS
4.80
Qty
2 $2.40 ea
1.50
AVOCADO HASS OFFER
BERRY STRAWBERRY 250G P/P
4.00
Qty 2 $2.00 ea
-0.50
BERRY STRAWBE OFFER
BROCCOLINI BUNCH
Qty
2 0 $3.00 ea
6.00
BROCCOl RU OFFER
"; Verticies = [{X = 163; Y = 5};{X = 3005; Y = 5};{X = 3005; Y = 4031};{X = 163; Y = 4031}]};
{Description = "WOOLWORTHS"; Verticies = [{X = 476; Y = 5};{X = 950; Y = 5};{X = 950; Y = 109};{X = 476; Y = 109}]};
{Description = "IAX"; Verticies = [{X = 998; Y = 5};{X = 1135; Y = 5};{X = 1135; Y = 109};{X = 998; Y = 109}]};
{Description = "INVOICE"; Verticies = [{X = 1195; Y = 5};{X = 1517; Y = 5};{X = 1517; Y = 109};{X = 1195; Y = 109}]};
{Description = "ABN"; Verticies = [{X = 1659; Y = 5};{X = 1800; Y = 5};{X = 1800; Y = 109};{X = 1659; Y = 109}]};
{Description = "88"; Verticies = [{X = 1850; Y = 5};{X = 1942; Y = 5};{X = 1942; Y = 109};{X = 1850; Y = 109}]};
{Description = "000"; Verticies = [{X = 1992; Y = 5};{X = 2133; Y = 5};{X = 2133; Y = 109};{X = 1992; Y = 109}]};
{Description = "014"; Verticies = [{X = 2179; Y = 5};{X = 2322; Y = 5};{X = 2322; Y = 109};{X = 2179; Y = 109}]};
{Description = "b/b"; Verticies = [{X = 2372; Y = 5};{X = 2515; Y = 5};{X = 2515; Y = 109};{X = 2372; Y = 109}]};
{Description = "HELGAS"; Verticies = [{X = 228; Y = 259};{X = 511; Y = 259};{X = 511; Y = 369};{X = 228; Y = 369}]};
{Description = "TRADITIONAL"; Verticies = [{X = 566; Y = 259};{X = 1095; Y = 259};{X = 1095; Y = 369};{X = 566; Y = 369}]};
{Description = "BREAD"; Verticies = [{X = 1139; Y = 259};{X = 1379; Y = 259};{X = 1379; Y = 369};{X = 1139; Y = 369}]};
{Description = "WHOLEME"; Verticies = [{X = 1421; Y = 259};{X = 1747; Y = 259};{X = 1747; Y = 369};{X = 1421; Y = 369}]};
{Description = "AL"; Verticies = [{X = 1763; Y = 259};{X = 1857; Y = 259};{X = 1857; Y = 369};{X = 1763; Y = 369}]};
{Description = "750G"; Verticies = [{X = 1909; Y = 259};{X = 2101; Y = 259};{X = 2101; Y = 369};{X = 1909; Y = 369}]};
{Description = "5.00"; Verticies = [{X = 2642; Y = 366};{X = 2829; Y = 366};{X = 2829; Y = 458};{X = 2642; Y = 458}]};
{Description = "ORIGINAL"; Verticies = [{X = 226; Y = 387};{X = 615; Y = 387};{X = 615; Y = 505};{X = 226; Y = 505}]};
{Description = "JUICE"; Verticies = [{X = 663; Y = 387};{X = 899; Y = 387};{X = 899; Y = 505};{X = 663; Y = 505}]};
{Description = "B/LBLGRAPEFRUIT"; Verticies = [{X = 948; Y = 387};{X = 1674; Y = 387};{X = 1674; Y = 505};{X = 948; Y = 505}]};
{Description = "1.5L."; Verticies = [{X = 1728; Y = 387};{X = 1911; Y = 387};{X = 1911; Y = 505};{X = 1728; Y = 505}]};
{Description = "2.20"; Verticies = [{X = 2651; Y = 494};{X = 2846; Y = 503};{X = 2841; Y = 609};{X = 2646; Y = 601}]};
{Description = "SPROUT"; Verticies = [{X = 224; Y = 533};{X = 517; Y = 533};{X = 517; Y = 643};{X = 224; Y = 643}]};
{Description = "ALFALFA"; Verticies = [{X = 563; Y = 533};{X = 907; Y = 533};{X = 907; Y = 643};{X = 563; Y = 643}]};
{Description = "125G"; Verticies = [{X = 950; Y = 533};{X = 1144; Y = 533};{X = 1144; Y = 643};{X = 950; Y = 643}]};
{Description = "P/P"; Verticies = [{X = 1193; Y = 533};{X = 1336; Y = 533};{X = 1336; Y = 643};{X = 1193; Y = 643}]};
{Description = "2.00"; Verticies = [{X = 2659; Y = 631};{X = 2852; Y = 639};{X = 2847; Y = 742};{X = 2655; Y = 734}]};
{Description = "F/C"; Verticies = [{X = 218; Y = 667};{X = 368; Y = 665};{X = 370; Y = 784};{X = 220; Y = 786}]};
{Description = "SALAD"; Verticies = [{X = 411; Y = 665};{X = 658; Y = 662};{X = 660; Y = 781};{X = 413; Y = 784}]};
{Description = "BABY"; Verticies = [{X = 700; Y = 661};{X = 897; Y = 658};{X = 899; Y = 777};{X = 702; Y = 780}]};
{Description = "SpN"; Verticies = [{X = 946; Y = 657};{X = 1096; Y = 655};{X = 1098; Y = 774};{X = 948; Y = 776}]};
{Description = "RUC"; Verticies = [{X = 1135; Y = 655};{X = 1285; Y = 653};{X = 1287; Y = 772};{X = 1137; Y = 774}]};
{Description = "60G"; Verticies = [{X = 1330; Y = 651};{X = 1484; Y = 649};{X = 1486; Y = 768};{X = 1332; Y = 770}]};
{Description = "6EA"; Verticies = [{X = 1529; Y = 649};{X = 1675; Y = 647};{X = 1677; Y = 766};{X = 1531; Y = 768}]};
{Description = "CARROT"; Verticies = [{X = 212; Y = 818};{X = 508; Y = 805};{X = 512; Y = 914};{X = 217; Y = 927}]};
{Description = "1.61"; Verticies = [{X = 2675; Y = 921};{X = 2865; Y = 921};{X = 2865; Y = 1019};{X = 2675; Y = 1019}]};
{Description = "0.642"; Verticies = [{X = 261; Y = 948};{X = 498; Y = 943};{X = 501; Y = 1069};{X = 264; Y = 1074}]};
{Description = "kg"; Verticies = [{X = 549; Y = 943};{X = 644; Y = 941};{X = 647; Y = 1067};{X = 552; Y = 1069}]};
{Description = "NET"; Verticies = [{X = 691; Y = 939};{X = 841; Y = 936};{X = 844; Y = 1062};{X = 694; Y = 1065}]};
{Description = "$2.50/kg"; Verticies = [{X = 1193; Y = 933};{X = 1582; Y = 933};{X = 1582; Y = 1043};{X = 1193; Y = 1043}]};
{Description = "MACRO"; Verticies = [{X = 202; Y = 1082};{X = 445; Y = 1077};{X = 447; Y = 1203};{X = 204; Y = 1208}]};
{Description = "FR"; Verticies = [{X = 494; Y = 1076};{X = 599; Y = 1074};{X = 601; Y = 1200};{X = 496; Y = 1202}]};
{Description = "CHICKEN"; Verticies = [{X = 643; Y = 1074};{X = 988; Y = 1068};{X = 990; Y = 1193};{X = 645; Y = 1200}]};
{Description = "BREASI"; Verticies = [{X = 1037; Y = 1067};{X = 1329; Y = 1062};{X = 1331; Y = 1187};{X = 1039; Y = 1193}]};
{Description = "FILLET"; Verticies = [{X = 1378; Y = 1061};{X = 1688; Y = 1055};{X = 1690; Y = 1181};{X = 1380; Y = 1187}]};
{Description = "SML"; Verticies = [{X = 1734; Y = 1053};{X = 1888; Y = 1050};{X = 1890; Y = 1176};{X = 1736; Y = 1179}]};
{Description = "RW"; Verticies = [{X = 1931; Y = 1049};{X = 2032; Y = 1047};{X = 2034; Y = 1173};{X = 1933; Y = 1175}]};
{Description = "11.50"; Verticies = [{X = 2630; Y = 1061};{X = 2873; Y = 1054};{X = 2876; Y = 1161};{X = 2633; Y = 1168}]};
{Description = "TOMATO"; Verticies = [{X = 200; Y = 1226};{X = 495; Y = 1226};{X = 495; Y = 1332};{X = 200; Y = 1332}]};
{Description = "TRUSS"; Verticies = [{X = 549; Y = 1226};{X = 789; Y = 1226};{X = 789; Y = 1332};{X = 549; Y = 1332}]};
{Description = "RED"; Verticies = [{X = 836; Y = 1226};{X = 987; Y = 1226};{X = 987; Y = 1332};{X = 836; Y = 1332}]};
{Description = "1.98"; Verticies = [{X = 2703; Y = 1346};{X = 2892; Y = 1338};{X = 2896; Y = 1435};{X = 2707; Y = 1443}]};
{Description = "0.222"; Verticies = [{X = 250; Y = 1362};{X = 488; Y = 1362};{X = 488; Y = 1484};{X = 250; Y = 1484}]};
{Description = "kg"; Verticies = [{X = 537; Y = 1362};{X = 643; Y = 1362};{X = 643; Y = 1484};{X = 537; Y = 1484}]};
{Description = "NET"; Verticies = [{X = 692; Y = 1362};{X = 833; Y = 1362};{X = 833; Y = 1484};{X = 692; Y = 1484}]};
{Description = "$8.90/kg"; Verticies = [{X = 1195; Y = 1360};{X = 1588; Y = 1360};{X = 1588; Y = 1474};{X = 1195; Y = 1474}]};
{Description = "4.35"; Verticies = [{X = 2708; Y = 1478};{X = 2905; Y = 1487};{X = 2900; Y = 1593};{X = 2703; Y = 1585}]};
{Description = "SELECT"; Verticies = [{X = 198; Y = 1515};{X = 492; Y = 1513};{X = 493; Y = 1626};{X = 199; Y = 1628}]};
{Description = "SMOKED"; Verticies = [{X = 541; Y = 1511};{X = 841; Y = 1509};{X = 842; Y = 1622};{X = 542; Y = 1624}]};
{Description = "BEEF"; Verticies = [{X = 885; Y = 1510};{X = 1084; Y = 1508};{X = 1085; Y = 1621};{X = 886; Y = 1623}]};
{Description = "PASTRAMI"; Verticies = [{X = 1135; Y = 1508};{X = 1531; Y = 1505};{X = 1532; Y = 1618};{X = 1136; Y = 1621}]};
{Description = "MUSHROOM"; Verticies = [{X = 192; Y = 1661};{X = 594; Y = 1656};{X = 595; Y = 1773};{X = 193; Y = 1778}]};
{Description = "CUPS"; Verticies = [{X = 637; Y = 1657};{X = 834; Y = 1655};{X = 835; Y = 1772};{X = 638; Y = 1774}]};
{Description = "LOOSE"; Verticies = [{X = 885; Y = 1653};{X = 1137; Y = 1650};{X = 1138; Y = 1767};{X = 886; Y = 1770}]};
{Description = "2.57"; Verticies = [{X = 2718; Y = 1783};{X = 2912; Y = 1783};{X = 2912; Y = 1885};{X = 2718; Y = 1885}]};
{Description = "0.234"; Verticies = [{X = 250; Y = 1801};{X = 496; Y = 1801};{X = 496; Y = 1932};{X = 250; Y = 1932}]};
{Description = "kg"; Verticies = [{X = 543; Y = 1801};{X = 639; Y = 1801};{X = 639; Y = 1932};{X = 543; Y = 1932}]};
{Description = "NET"; Verticies = [{X = 685; Y = 1801};{X = 832; Y = 1801};{X = 832; Y = 1932};{X = 685; Y = 1932}]};
{Description = "$10.98/kg"; Verticies = [{X = 1143; Y = 1801};{X = 1593; Y = 1801};{X = 1593; Y = 1915};{X = 1143; Y = 1915}]};
{Description = "10.00"; Verticies = [{X = 2681; Y = 1927};{X = 2914; Y = 1919};{X = 2918; Y = 2038};{X = 2685; Y = 2046}]};
{Description = "SNACK"; Verticies = [{X = 194; Y = 1958};{X = 435; Y = 1954};{X = 437; Y = 2071};{X = 196; Y = 2075}]};
{Description = "MEDJOOL"; Verticies = [{X = 490; Y = 1954};{X = 825; Y = 1949};{X = 827; Y = 2066};{X = 492; Y = 2071}]};
{Description = "DATES"; Verticies = [{X = 883; Y = 1949};{X = 1137; Y = 1945};{X = 1139; Y = 2062};{X = 885; Y = 2066}]};
{Description = "450G"; Verticies = [{X = 1191; Y = 1943};{X = 1392; Y = 1940};{X = 1394; Y = 2057};{X = 1193; Y = 2060}]};
{Description = "BANANA"; Verticies = [{X = 190; Y = 2102};{X = 487; Y = 2102};{X = 487; Y = 2220};{X = 190; Y = 2220}]};
{Description = "CAVENDISH"; Verticies = [{X = 539; Y = 2102};{X = 983; Y = 2102};{X = 983; Y = 2220};{X = 539; Y = 2220}]};
{Description = "1.097"; Verticies = [{X = 242; Y = 2248};{X = 486; Y = 2248};{X = 486; Y = 2375};{X = 242; Y = 2375}]};
{Description = "kg"; Verticies = [{X = 535; Y = 2248};{X = 635; Y = 2248};{X = 635; Y = 2375};{X = 535; Y = 2375}]};
{Description = "NET"; Verticies = [{X = 683; Y = 2248};{X = 832; Y = 2248};{X = 832; Y = 2375};{X = 683; Y = 2375}]};
{Description = "$3.90/kg"; Verticies = [{X = 1195; Y = 2248};{X = 1600; Y = 2248};{X = 1600; Y = 2362};{X = 1195; Y = 2362}]};
{Description = "ONION"; Verticies = [{X = 194; Y = 2405};{X = 436; Y = 2405};{X = 436; Y = 2519};{X = 194; Y = 2519}]};
{Description = "RED"; Verticies = [{X = 482; Y = 2405};{X = 641; Y = 2405};{X = 641; Y = 2519};{X = 482; Y = 2519}]};
{Description = "LOOSE"; Verticies = [{X = 683; Y = 2405};{X = 929; Y = 2405};{X = 929; Y = 2519};{X = 683; Y = 2519}]};
{Description = "0.71"; Verticies = [{X = 2746; Y = 2537};{X = 2936; Y = 2537};{X = 2936; Y = 2643};{X = 2746; Y = 2643}]};
{Description = "0.177"; Verticies = [{X = 242; Y = 2555};{X = 488; Y = 2555};{X = 488; Y = 2688};{X = 242; Y = 2688}]};
{Description = "kg"; Verticies = [{X = 533; Y = 2555};{X = 629; Y = 2555};{X = 629; Y = 2688};{X = 533; Y = 2688}]};
{Description = "NET"; Verticies = [{X = 681; Y = 2555};{X = 824; Y = 2555};{X = 824; Y = 2688};{X = 681; Y = 2688}]};
{Description = "$4.00/kg"; Verticies = [{X = 1183; Y = 2555};{X = 1608; Y = 2555};{X = 1608; Y = 2688};{X = 1183; Y = 2688}]};
{Description = "AVOCADO"; Verticies = [{X = 183; Y = 2710};{X = 531; Y = 2710};{X = 531; Y = 2828};{X = 183; Y = 2828}]};
{Description = "HASS"; Verticies = [{X = 582; Y = 2710};{X = 780; Y = 2710};{X = 780; Y = 2828};{X = 582; Y = 2828}]};
{Description = "4.80"; Verticies = [{X = 2762; Y = 2836};{X = 2957; Y = 2845};{X = 2951; Y = 2967};{X = 2757; Y = 2959}]};
{Description = "Qty"; Verticies = [{X = 175; Y = 2866};{X = 326; Y = 2866};{X = 326; Y = 2988};{X = 175; Y = 2988}]};
{Description = "2"; Verticies = [{X = 525; Y = 2868};{X = 580; Y = 2868};{X = 580; Y = 2997};{X = 525; Y = 2997}]};
{Description = "$2.40"; Verticies = [{X = 1196; Y = 2872};{X = 1451; Y = 2872};{X = 1451; Y = 2992};{X = 1196; Y = 2992}]};
{Description = "ea"; Verticies = [{X = 1506; Y = 2868};{X = 1610; Y = 2868};{X = 1610; Y = 2997};{X = 1506; Y = 2997}]};
{Description = "1.50"; Verticies = [{X = 2770; Y = 3002};{X = 2960; Y = 3002};{X = 2960; Y = 3112};{X = 2770; Y = 3112}]};
{Description = "AVOCADO"; Verticies = [{X = 277; Y = 3022};{X = 629; Y = 3022};{X = 629; Y = 3146};{X = 277; Y = 3146}]};
{Description = "HASS"; Verticies = [{X = 677; Y = 3022};{X = 883; Y = 3022};{X = 883; Y = 3146};{X = 677; Y = 3146}]};
{Description = "OFFER"; Verticies = [{X = 978; Y = 3022};{X = 1243; Y = 3022};{X = 1243; Y = 3146};{X = 978; Y = 3146}]};
{Description = "BERRY"; Verticies = [{X = 165; Y = 3175};{X = 420; Y = 3175};{X = 420; Y = 3304};{X = 165; Y = 3304}]};
{Description = "STRAWBERRY"; Verticies = [{X = 470; Y = 3175};{X = 983; Y = 3175};{X = 983; Y = 3304};{X = 470; Y = 3304}]};
{Description = "250G"; Verticies = [{X = 1037; Y = 3175};{X = 1251; Y = 3175};{X = 1251; Y = 3304};{X = 1037; Y = 3304}]};
{Description = "P/P"; Verticies = [{X = 1305; Y = 3175};{X = 1456; Y = 3175};{X = 1456; Y = 3304};{X = 1305; Y = 3304}]};
{Description = "4.00"; Verticies = [{X = 2785; Y = 3311};{X = 2984; Y = 3320};{X = 2979; Y = 3441};{X = 2780; Y = 3432}]};
{Description = "Qty"; Verticies = [{X = 163; Y = 3319};{X = 313; Y = 3320};{X = 312; Y = 3470};{X = 162; Y = 3469}]};
{Description = "2"; Verticies = [{X = 515; Y = 3321};{X = 569; Y = 3321};{X = 568; Y = 3471};{X = 514; Y = 3471}]};
{Description = "$2.00"; Verticies = [{X = 1200; Y = 3340};{X = 1457; Y = 3340};{X = 1457; Y = 3452};{X = 1200; Y = 3452}]};
{Description = "ea"; Verticies = [{X = 1510; Y = 3340};{X = 1616; Y = 3340};{X = 1616; Y = 3452};{X = 1510; Y = 3452}]};
{Description = "-0.50"; Verticies = [{X = 2734; Y = 3486};{X = 2988; Y = 3474};{X = 2993; Y = 3590};{X = 2740; Y = 3603}]};
{Description = "BERRY"; Verticies = [{X = 267; Y = 3484};{X = 515; Y = 3484};{X = 515; Y = 3611};{X = 267; Y = 3611}]};
{Description = "STRAWBE"; Verticies = [{X = 566; Y = 3484};{X = 938; Y = 3484};{X = 938; Y = 3611};{X = 566; Y = 3611}]};
{Description = "OFFER"; Verticies = [{X = 990; Y = 3484};{X = 1253; Y = 3484};{X = 1253; Y = 3611};{X = 990; Y = 3611}]};
{Description = "BROCCOLINI"; Verticies = [{X = 165; Y = 3644};{X = 679; Y = 3622};{X = 684; Y = 3749};{X = 171; Y = 3772}]};
{Description = "BUNCH"; Verticies = [{X = 728; Y = 3620};{X = 992; Y = 3608};{X = 997; Y = 3736};{X = 734; Y = 3748}]};
{Description = "Qty"; Verticies = [{X = 169; Y = 3795};{X = 312; Y = 3795};{X = 312; Y = 3920};{X = 169; Y = 3920}]};
{Description = "2"; Verticies = [{X = 533; Y = 3774};{X = 635; Y = 3774};{X = 635; Y = 3921};{X = 533; Y = 3921}]};
{Description = "0"; Verticies = [{X = 887; Y = 3774};{X = 949; Y = 3774};{X = 949; Y = 3921};{X = 887; Y = 3921}]};
{Description = "$3.00"; Verticies = [{X = 1208; Y = 3783};{X = 1465; Y = 3783};{X = 1465; Y = 3908};{X = 1208; Y = 3908}]};
{Description = "ea"; Verticies = [{X = 1513; Y = 3783};{X = 1619; Y = 3783};{X = 1619; Y = 3908};{X = 1513; Y = 3908}]};
{Description = "6.00"; Verticies = [{X = 2799; Y = 3789};{X = 3004; Y = 3798};{X = 2998; Y = 3921};{X = 2794; Y = 3912}]};
{Description = "BROCCOl"; Verticies = [{X = 271; Y = 3917};{X = 629; Y = 3917};{X = 629; Y = 4031};{X = 271; Y = 4031}]};
{Description = "RU"; Verticies = [{X = 846; Y = 3933};{X = 960; Y = 3933};{X = 960; Y = 4031};{X = 846; Y = 4031}]};
{Description = "OFFER"; Verticies = [{X = 992; Y = 3917};{X = 1253; Y = 3917};{X = 1253; Y = 4031};{X = 992; Y = 4031}]};]


