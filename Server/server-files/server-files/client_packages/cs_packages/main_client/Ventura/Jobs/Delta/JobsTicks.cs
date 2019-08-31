using System;
using System.Collections.Generic;
using System.Text;
using RAGE;

namespace main_client.Ventura.Jobs.Delta
{
    /*
     * 
     * 
     * {"id":526,"color":68,"name":"LSPD","x":441.677216,"y":-983.170837,"z":30.6895981,"scale":1.0}
{"id":73,"color":60,"name":"Binco","x":424.990845,"y":-805.152344,"z":29.491148,"scale":0.8}
{"id":522,"color":2,"name":"Black Knight","x":732.358643,"y":-1082.17053,"z":22.16884,"scale":1.0}
{"id":642,"color":44,"name":"Concessionnaire","x":-40.5183372,"y":-1097.79382,"z":26.42235,"scale":0.9}
{"id":419,"color":0,"name":"Gouvernement","x":2477.62769,"y":-384.1188,"z":94.40317,"scale":1.0}
{"id":475,"color":4,"name":"Arcadius","x":-117.100113,"y":-604.4245,"z":36.2807159,"scale":0.9}
{"id":524,"color":53,"name":"Parking public","x":134.9536,"y":-1052.06433,"z":29.1605949,"scale": 0.8}
{"id":487,"color":0,"name":"Tribunal","x":235.408859,"y":-411.2847,"z":48.1119461,"scale":1.0}
{"id":121,"color":8,"name":"Vanilla_Unicorn","x":126.568642,"y":-1285.94238,"z":29.2840328,"scale":0.8}
{"id":643,"color":0,"name":"Garagiste","x":-335.465729,"y":-136.966278,"z":39.0096664,"scale":0.8}
{"id":61,"color":1,"name":"Hôpital","x":-473.1987,"y":-338.725861,"z":35.2018166,"scale":0.9}
{"id":617,"color":57,"name":"Vangelico","x":-623.2145,"y":-231.596451,"z":38.057045,"scale":0.8}
{"id":71,"color":9,"name":"Boh Mulét","x":-816.178955,"y":-184.839188,"z":37.56893,"scale":0.8}
{"id":93,"color":33,"name":"Tequi la-la","x":-557.812744,"y":285.3452,"z":82.17643,"scale":0.8}
{"id":73,"color":60,"name":"Binco","x":-821.8633,"y":-1073.958,"z":11.3281,"scale":0.8}
{"id":52,"color":2,"name":"LTD Gasoline","x":-710.515259,"y":-911.9343,"z":19.2155857,"scale":0.8}
{"id":73,"color":60,"name":"Suburban","x":-1191.302,"y":-771.0348,"z":17.3250275,"scale":0.8}
{"id":459,"color":1,"name":"Lifeinvader","x":-1082.128,"y":-250.429886,"z":37.76331,"scale":1.0}
{"id":52,"color":2,"name":"LTD Gasoline","x":-1824.80664,"y":791.156,"z":138.19809,"scale":0.8}
{"id":100,"color":0,"name":"Car Wash","x":48.14382,"y":-1396.85156,"z":29.3610439,"scale":0.7}
{"id":52,"color":2,"name":"24/7 Market","x":28.60493,"y":-1341.40515,"z":30.4469986,"scale":0.8}
{"id":119,"color":6,"name":"Ammu Nation","x":250.75769,"y":-47.9124146,"z":69.94103,"scale":0.8}
{"id":71,"color":9,"name":"Hot Shave","x":-33.0918159,"y":-151.741714,"z":57.0765,"scale":0.8}
{"id":52,"color":2,"name":"Rebs Liquor","x":-1486.68811,"y":-379.761047,"z":40.16342,"scale":0.8}
{"id":72,"color":27,"name":"Benny's","x":-212.983871,"y":-1326.35254,"z":30.8903847,"scale":0.8}
{"id":100,"color":0,"name":"Car Wash","x":-699.5873,"y":-942.3794,"z":19.2168617,"scale":0.7}
{"id":102,"color":0,"name":"Movie Masks","x":-1336.33142,"y":-1277.56543,"z":4.874423,"scale":0.8}
{"id":488,"color":66,"name":"Bike Rental","x":-1261.04187,"y":-1439.92676,"z":4.35166025,"scale":0.8}
{"id":366,"color":18,"name":"Sidewalk","x":-1218.26648,"y":-1516.00183,"z":4.37973642,"scale":0.8}
{"id":442,"color":81,"name":"Pacific Bluffs","x":-3024.01831,"y":80.573494,"z":11.608119,"scale":0.8}
{"id":276,"color":2,"name":"Bank Vinewood","x":249.230118,"y":217.76442,"z":106.286758,"scale":1.2}
{"id":75,"color":0,"name":"Blazing Tattoo","x":323.0578,"y":180.888229,"z":103.586487,"scale":0.8}
{"id":52,"color":2,"name":"24/7 Market","x":544.2137,"y":2668.976,"z":42.1565475,"scale":0.8}
{"id":73,"color":60,"name":"Discount Store","x":1195.59277,"y":2709.6394,"z":38.22264,"scale":0.8}
{"id":226,"color":0,"name":"LOST","x":1180.54431,"y":2638.902,"z":37.79473,"scale":0.8}
{"id":93,"color":33,"name":"Pibwasser","x":1986.89856,"y":3048.947,"z":47.2151,"scale":0.8}
{"id":237,"color":13,"name":"Centre Pénitentiaire","x":1689.28418,"y":2605.22729,"z":45.5648956,"scale":1.0}
     * 
     * */


    class JobsTicks : Events.Script
    {
        private bool Active = false;
/*{"id":1,"state":0,"from":{"x":-829.1092,"y":-1074.062,"z":11.32811},"to":{"x":-820.2423,"y":-1067.473,"z":11.32803}}
{"id":2,"state":0,"from":{"x":-1188.704,"y":-772.6194,"z":-17.3302},"to":{"x":-1186.371,"y":-771.1503,"z":17.33065}}*/


    public List<Tuple<string, int, bool, object, Type>> Jobs = new List<Tuple<string, int, bool, object, Type>>() {
            new Tuple<string, int, bool, object, Type>("Magasin de Vétement", 0, true, new List<JobsData.ClothShopData>() {
                new JobsData.ClothShopData() {
                    From = new Vector3(429.287f, -800.2769f, 29.49114f),
                    To = new Vector3(429.8726f, -811.5738f, 29.49115f),
                    State = 0,
                },
                 new JobsData.ClothShopData() {
                    From = new Vector3(-829.1092f, -1074.062f, 11.32811f),
                    To = new Vector3(-820.2423f, -1067.473f, 11.32803f),
                    State = 0,
                },
                  new JobsData.ClothShopData() {
                    From = new Vector3(-1190.085f, -773.9192f, 17.33055f),
                    To = new Vector3(-1192.749f, -767.7954f, 17.31872f),
                    State = 0,
                },
            }, typeof(List<JobsData.ClothShopData>)
                ),
            new Tuple<string, int, bool, object, Type>("Magasin 7/24", 1, true, new List<JobsData.MarketShopData>() {
                new JobsData.MarketShopData() {
                    From = new Vector3(-1487.249f, -379.621f, 40.16343f),
                    To = new Vector3(-1487.249f, -379.621f, 40.16343f),
                    State = 0,
                },
                new JobsData.MarketShopData() {
                    From = new Vector3(-1821.226f, 792.7946f, 138.1218f),
                    To = new Vector3(-1821.226f, 792.7946f, 138.1218f),
                    State = 0,
                },
                new JobsData.MarketShopData() {
                    From = new Vector3(-1487.249f, -379.621f, 40.16343f),
                    To = new Vector3(-1487.249f, -379.621f, 40.16343f),
                    State = 0,
                },
                new JobsData.MarketShopData() {
                    From = new Vector3(547.9656f, 2669.895f, 42.1565f),
                    To = new Vector3(547.9656f, 2669.895f, 42.1565f),
                    State = 0,
                },
                new JobsData.MarketShopData() {
                    From = new Vector3(26.36736f, -1345.381f, 29.49702f),
                    To = new Vector3(26.36736f, -1345.381f, 29.49702f),
                    State = 0,
                },
            }, typeof(List<JobsData.MarketShopData>)
                ),
            new Tuple<string, int, bool, object, Type>("Benny's Custom", 2, true, new List<JobsData.BennysCustomData>() {
                new JobsData.BennysCustomData() {
                    Inside = new Vector3(-206.8048f, -1341.575f, 34.22261f),
                    Out = new Vector3(-205.6315f, -1341.575f, 34.23072f),
                    GetService = new Vector3(-203.6693f, -1331.526f, 34.22412f),
                    ScriptPaintPosition = new Vector3(-226.2996f, -1330.391f, 30.24215f),
                    ZonePaintPosition = new Vector3(-222.8074f, -1330.248f, 30.24215f),
                    CoffrePosition = new Vector3(-224.3796f, -1319.881f, 30.2185f),
                    ComputerPosition = new Vector3(-228.3896f, -1329.601f, 30.2185f),
                    State = 0,
                },
            }, typeof(List<JobsData.BennysCustomData>)
                ),
            new Tuple<string, int, bool, object, Type>("Weazel News", 3, true, new List<JobsData.WeazelNewsData>() {
                new JobsData.WeazelNewsData() {
                    Inside = new Vector3(-598.3453f, -929.8484f, 23.20639f),
                    Out = new Vector3(1173.377f, -3196.656f, -39.67186f),
                    GetService = new Vector3(1170.78f, -3199.104f, -39.67186f),
                    ComputerPosition = new Vector3(1162.936f, -3196.596f, -39.40295f),
                    GarbageVehicle = new Vector3(-543.7112f, -887.0047f, 24.53517f),
                    SpawnVehicle = new Vector3(-543.7112f, -893.8396f, 23.89082f),
                    GarbageHeli = new Vector3(-583.0386f, -923.396f, 36.17921f),
                    SpawnHeli = new Vector3(-583.4398f, -930.6013f, 36.17921f),
                    InsideTop = new Vector3(-589.8537f, -912.5399f, 23.23489f),
                    OutTop = new Vector3(-568.6429f, -927.7338f, 36.17921f),
                    IPL = "",
                    State = 0,
                },
            }, typeof(List<JobsData.WeazelNewsData>)
                ),
            new Tuple<string, int, bool, object, Type>("Feliz Pesca", 4, true, new List<JobsData.FishData>() {
                new JobsData.FishData() {
                    Inside = new Vector3(-598.3453f, -929.8484f, 23.20639f),
                    Out = new Vector3(1173.377f, -3196.656f, -39.67186f),
                    GetService = new Vector3(-53.12764f, -2525.049f, 6.73716f),
                    ComputerPosition = new Vector3(-59.58362f, -2517.995f, 7.198833f),
                    CoffrePosition = new Vector3(-56.1306f, -2520.122f, 6.72995f),
                    GarbageVehicle = new Vector3(-475.397f, -2832.679f, 6.635561f),
                    SpawnVehicle = new Vector3(-484.0511f, -2824.239f, 5.334264f),
                    GarbageBoat = new Vector3(-290.6473f, -2769.014f, 1.530797f),
                    SpawnBoat = new Vector3(-292.5309f, -2762.585f, 0.3969294f),
                    ZoneFishing = new Vector3(-389.2018f, -3783.328f, -0.1335282f),
                    ZoneTreat = new Vector3(880.7523f, -1670.677f, 31.11255f),
                    Container = new Vector3(-92.00076f, -2462.088f, 5.367797f),
                    IPL = "",
                    State = 0,
                },
            }, typeof(List<JobsData.FishData>)
                ),
            new Tuple<string, int, bool, object, Type>("Rensson Luxury Cars", 5, true, new List<JobsData.RenssonConcessData>() {
                new JobsData.RenssonConcessData() {
                    GetService = new Vector3(-30.64168f, -1111.025f, 25.75464f),
                    ComputerPosition = new Vector3(-30.36254f, -1106.188f, 26.2338f),
                    CoffrePosition = new Vector3(-29.2958f, -1107.936f, 25.75464f),
                    GarbageVehicle = new Vector3(-177.0078f, -1178.92f, 22.49698f),
                    SpawnVehicle = new Vector3(-177.0078f, -1182.924f, 22.49698f),
                    IPL = "",
                    State = 0,
                },
            }, typeof(List<JobsData.RenssonConcessData>)
                ),
            new Tuple<string, int, bool, object, Type>("Black Knight", 6, true, new List<JobsData.BlackKnightData>() {
                new JobsData.BlackKnightData() {
                    Inside = new Vector3(-345.5216f, -122.9615f, 38.33978f),
                    Out = new Vector3(996.8751f, -3158.109f, -39.56956f),
                    GetService = new Vector3(-347.4148f, -133.4179f, 38.35509f),
                    ComputerPosition = new Vector3(1007.158f, -3169.944f, -39.56956f),
                    CoffrePosition = new Vector3(1008.367f, -3171.982f, -39.56956f),
                    GarbageVehicle = new Vector3(1000.102f, -3175.801f, -39.20456f),
                    SpawnVehicle = new Vector3(999.9911f, -3172.134f, -39.56956f),
                    GarbageHeli = new Vector3(-583.0386f, -923.396f, 36.17921f),
                    SpawnHeli = new Vector3(-583.4398f, -930.6013f, 36.17921f),
                    InsideTop = new Vector3(-589.8537f, -912.5399f, 23.23489f),
                    OutTop = new Vector3(-568.6429f, -927.7338f, 36.17921f),
                    IPL = "",
                    State = 0,
                },
            }, typeof(List<JobsData.BlackKnightData>)
                ),
            new Tuple<string, int, bool, object, Type>("The Lost MC", 7, true, new List<JobsData.LostData>() {
                new JobsData.LostData() {
                    Inside = new Vector3(-598.3453f, -929.8484f, 23.20639f),
                    Out = new Vector3(1173.377f, -3196.656f, -39.67186f),
                    GetService = new Vector3(1171.187f, 2637.537f, 37.09661f),
                    ComputerPosition = new Vector3(1186.421f, 2637.874f, 37.73964f),
                    CoffrePosition = new Vector3(1187.211f, 2635.761f, 37.73964f),
                    GarbageVehicle = new Vector3(1233.098f, 2737.303f, 37.33589f),
                    SpawnVehicle = new Vector3(-543.7112f, -893.8396f, 23.89082f),
                    IPL = "",
                    State = 0,
                },
            }, typeof(List<JobsData.LostData>)
                ),
            new Tuple<string, int, bool, object, Type>("Downton Cab.co", 8, true, new List<JobsData.TaxiData>() {
                new JobsData.TaxiData() {
                    Inside = new Vector3(894.6803f, -179.0263f, 74.0313f),
                    Out = new Vector3(194.3714f, -1022.985f, -99.62987f),
                    GetService = new Vector3(1170.78f, -3199.104f, -39.67186f),
                    CoffrePosition = new Vector3(206.328f, -1015.317f, -99.66939f),
                    ComputerPosition = new Vector3(203.3676f, -1013.799f, -99.66939f),
                    GarbageVehicle = new Vector3(193.4734f, -1015.169f, -99.66405f),
                    SpawnVehicle = new Vector3(902.7777f, -143.0149f, 75.94064f),
                    IPL = "",
                    State = 0,
                },
            }, typeof(List<JobsData.TaxiData>)
                ),
            new Tuple<string, int, bool, object, Type>("D&C", 9, true, new List<JobsData.DAndCData>() {
                new JobsData.DAndCData() {
                    Inside = new Vector3(-598.3453f, -929.8484f, 23.20639f),
                    Out = new Vector3(1173.377f, -3196.656f, -39.67186f),
                    GetService = new Vector3(724.9796f, -1069.167f, 27.64651f),
                    ComputerPosition = new Vector3(1162.936f, -3196.596f, -39.40295f),
                    CoffrePosition = new Vector3(727.0012f, -1065.203f, 27.64651f),
                    GarbageVehicle = new Vector3(733.905f, -1057.322f, 21.39324f),
                    SpawnVehicle = new Vector3(740.3875f, -1054.981f, 21.2744f),
                    GarbageHeli = new Vector3(-583.0386f, -923.396f, 36.17921f),
                    SpawnHeli = new Vector3(-583.4398f, -930.6013f, 36.17921f),
                    InsideTop = new Vector3(-589.8537f, -912.5399f, 23.23489f),
                    OutTop = new Vector3(-568.6429f, -927.7338f, 36.17921f),
                    IPL = "",
                    State = 0,
                },
            }, typeof(List<JobsData.DAndCData>)
                ),
            new Tuple<string, int, bool, object, Type>("Brink's", 10, true, new List<JobsData.BrinksData>() {
                new JobsData.BrinksData() {
                    GetService = new Vector3(-4.79524f, -653.9509f, 32.78694f),
                    GarbageVehicle = new Vector3(-3.999718f, -659.1559f, 32.80807f),
                    SpawnVehicle = new Vector3(-4.622936f, -669.8881f, 31.67671f),
                    IPL = "",
                    State = 0,
                },
            }, typeof(List<JobsData.BrinksData>)
                ),
            new Tuple<string, int, bool, object, Type>("Organiz", 11, true, new List<JobsData.OrganizData>() {
                new JobsData.OrganizData() {
                    Inside = new Vector3(-3024.488f, 80.07495f, 10.95362f),
                    Out = new Vector3(-1569.419f, -3017.522f, -75.0664f),
                    GetService = new Vector3(1170.78f, -3199.104f, -39.67186f),
                    ComputerPosition = new Vector3(1162.936f, -3196.596f, -39.40295f),
                    GarbageVehicle = new Vector3(-2948.102f, 57.30811f, 10.94252f),
                    SpawnVehicle = new Vector3(-2956.435f, 58.798f, 10.94596f),
                    IPL = "",
                    State = 0,
                },
            }, typeof(List<JobsData.OrganizData>)
                ),
            new Tuple<string, int, bool, object, Type>("Niglo Tattoo", 12, true, new List<JobsData.NigloTattooData>() {
                new JobsData.NigloTattooData() {
                    GetService = new Vector3(-1153.699f, -1428.281f, 4.291035f),
                    ComputerPosition = new Vector3(-1152.732f, -1423.572f, 4.291035f),
                    IPL = "",
                    State = 0,
                },
            }, typeof(List<JobsData.NigloTattooData>)
                ),
            new Tuple<string, int, bool, object, Type>("Dépannage Burns", 13, true, new List<JobsData.BurnsData>() {
                new JobsData.BurnsData() {
                    GetService = new Vector3(98.81788f, 6621.208f, 31.77402f),
                    ComputerPosition = new Vector3(101.0115f, 6620.238f, 31.77402f),
                    GarbageVehicle = new Vector3(111.4186f, 6631.046f, 31.1918f),
                    SpawnVehicle = new Vector3(110.2273f, 6626.408f, 31.1918f),
                    IPL = "",
                    State = 0,
                },
            }, typeof(List<JobsData.BurnsData>)
                ),
            new Tuple<string, int, bool, object, Type>("El Barrio Records", 14, true, new List<JobsData.BarioData>() {
                new JobsData.BarioData() {
                    Inside = new Vector3(-1016.018f, -265.8888f, 38.37031f),
                    Out = new Vector3(-787.029f, 315.7113f, 216.9739f),
                    ComputerPosition = new Vector3(-797.0709f, 321.4075f, 216.3689f),
                    CoffrePosition = new Vector3(-798.978f, 327.8373f, 216.3689f),
                    IPL = "",
                    State = 0,
                },
            }, typeof(List<JobsData.BarioData>)
                ),
            new Tuple<string, int, bool, object, Type>("Entreprise pétrole", 15, true, new List<JobsData.PetrolData>() {
                new JobsData.PetrolData() {
                    GetService = new Vector3(2748.261f, 1453.605f, 24.05029f),
                    ComputerPosition = new Vector3(2746.94f, 1458.547f, 24.05029f),
                    CoffrePosition = new Vector3(2813.081f, 1468.843f, 24.16721f),
                    GarbageVehicle = new Vector3(2681.304f, 1330.781f, 24.00948f),
                    SpawnVehicle = new Vector3(2703.283f, 1346.503f, 24.00948f),
                    IPL = "",
                    State = 0,
                },
            }, typeof(List<JobsData.PetrolData>)
                ),
            new Tuple<string, int, bool, object, Type>("Vigneron", 16, true, new List<JobsData.VigneronData>() {
                new JobsData.VigneronData() {
                    Inside = new Vector3(-3024.488f, 80.07495f, 10.95362f),
                    Out = new Vector3(1048.361f, -3097.059f, -39.66226f),
                    GetService = new Vector3(1048.361f, -3102.634f, -39.6712f),
                    ComputerPosition = new Vector3(1048.361f, -3100.585f, -39.6712f),
                    IPL = "",
                    State = 0,
                },
            }, typeof(List<JobsData.VigneronData>)
                ),
            new Tuple<string, int, bool, object, Type>("La Ferme Laroche", 17, true, new List<JobsData.FarmLarocheData>() {
                new JobsData.FarmLarocheData() {
                    GetService = new Vector3(2455.244f, 4970.954f, 46.14954f),
                    CoffrePosition = new Vector3(2444.14f, 4966.346f, 46.15307f),
                    ComputerPosition = new Vector3(2442.72f, 4964.832f, 46.15307f),
                    IPL = "",
                    State = 0,
                },
            }, typeof(List<JobsData.FarmLarocheData>)
                ),
            new Tuple<string, int, bool, object, Type>("Transporteur", 18, true, new List<JobsData.TransportData>() {
                new JobsData.TransportData() {
                    GetService = new Vector3(575.5547f, -3126.39f, 18.10829f),
                    CoffrePosition = new Vector3(575.46f, -3121.113f, 18.10829f),
                    ComputerPosition = new Vector3(565.7637f, -3124.604f, 18.12081f),
                    GarbageVehicle = new Vector3(1218.256f, -3325.881f, 4.862376f),
                    SpawnVehicle = new Vector3(1218.256f, -3339.327f, 5.135035f),
                    IPL = "",
                    State = 0,
                },
            }, typeof(List<JobsData.TransportData>)
                ),
            new Tuple<string, int, bool, object, Type>("Banks", 19, true, new List<JobsData.BankData>() {
                new JobsData.BankData() {
                    CoffrePosition = new Vector3(244.3014f, 232.3488f, 105.62f),
                    ComputerPosition = new Vector3(264.6719f, 211.2591f, 110.0929f),
                    IPL = "",
                    State = 0,
                },
            }, typeof(List<JobsData.BankData>)
                ),
            new Tuple<string, int, bool, object, Type>("LSPD", 20, true, new List<JobsData.LSPDData>() {
                new JobsData.LSPDData() {
                    GetService = new Vector3(459.1298f, -991.0494f, 30.03043f),
                    GarbageVehicle = new Vector3(458.5923f, -1008.049f, 27.64287f),
                    SpawnVehicle = new Vector3(455.1372f, -1014.711f, 27.77201f),
                    IPL = "",
                    State = 0,
                },
            }, typeof(List<JobsData.LSPDData>)
                ),
             new Tuple<string, int, bool, object, Type>("Gouvernement", 21, true, new List<JobsData.GouvernementData>() {
                new JobsData.GouvernementData() {
                    Inside = new Vector3(-598.3453f, -929.8484f, 23.20639f),
                    Out = new Vector3(1173.377f, -3196.656f, -39.67186f),
                    GetService = new Vector3(724.9796f, -1069.167f, 27.64651f),
                    ComputerPosition = new Vector3(1162.936f, -3196.596f, -39.40295f),
                    CoffrePosition = new Vector3(727.0012f, -1065.203f, 27.64651f),
                    GarbageVehicle = new Vector3(733.905f, -1057.322f, 21.39324f),
                    SpawnVehicle = new Vector3(740.3875f, -1054.981f, 21.2744f),
                    GarbageHeli = new Vector3(-583.0386f, -923.396f, 36.17921f),
                    SpawnHeli = new Vector3(-583.4398f, -930.6013f, 36.17921f),
                    InsideTop = new Vector3(-589.8537f, -912.5399f, 23.23489f),
                    OutTop = new Vector3(-568.6429f, -927.7338f, 36.17921f),
                    IPL = "",
                    State = 0,
                },
            }, typeof(List<JobsData.GouvernementData>)
                ),
             new Tuple<string, int, bool, object, Type>("LSDH", 22, true, new List<JobsData.LSDHData>() {
                new JobsData.LSDHData() {
                    Inside = new Vector3(-598.3453f, -929.8484f, 23.20639f),
                    Out = new Vector3(1173.377f, -3196.656f, -39.67186f),
                    GetService = new Vector3(724.9796f, -1069.167f, 27.64651f),
                    ComputerPosition = new Vector3(1162.936f, -3196.596f, -39.40295f),
                    CoffrePosition = new Vector3(727.0012f, -1065.203f, 27.64651f),
                    GarbageVehicle = new Vector3(733.905f, -1057.322f, 21.39324f),
                    SpawnVehicle = new Vector3(740.3875f, -1054.981f, 21.2744f),
                    GarbageHeli = new Vector3(-583.0386f, -923.396f, 36.17921f),
                    SpawnHeli = new Vector3(-583.4398f, -930.6013f, 36.17921f),
                    InsideTop = new Vector3(-589.8537f, -912.5399f, 23.23489f),
                    OutTop = new Vector3(-568.6429f, -927.7338f, 36.17921f),
                    IPL = "",
                    State = 0,
                },
            }, typeof(List<JobsData.LSDHData>)
                ),
             new Tuple<string, int, bool, object, Type>("Pole Emploi", 23, true, new List<JobsData.PoleEmploiData>() {
                new JobsData.PoleEmploiData() {
                    Inside = new Vector3(-598.3453f, -929.8484f, 23.20639f),
                    Out = new Vector3(1173.377f, -3196.656f, -39.67186f),
                    GetService = new Vector3(724.9796f, -1069.167f, 27.64651f),
                    ComputerPosition = new Vector3(1162.936f, -3196.596f, -39.40295f),
                    CoffrePosition = new Vector3(727.0012f, -1065.203f, 27.64651f),
                    GarbageVehicle = new Vector3(733.905f, -1057.322f, 21.39324f),
                    SpawnVehicle = new Vector3(740.3875f, -1054.981f, 21.2744f),
                    GarbageHeli = new Vector3(-583.0386f, -923.396f, 36.17921f),
                    SpawnHeli = new Vector3(-583.4398f, -930.6013f, 36.17921f),
                    InsideTop = new Vector3(-589.8537f, -912.5399f, 23.23489f),
                    OutTop = new Vector3(-568.6429f, -927.7338f, 36.17921f),
                    IPL = "",
                    State = 0,
                },
            }, typeof(List<JobsData.PoleEmploiData>)
                ),
             new Tuple<string, int, bool, object, Type>("Marshal", 24, true, new List<JobsData.MarshalData>() {
                new JobsData.MarshalData() {
                    Inside = new Vector3(-598.3453f, -929.8484f, 23.20639f),
                    Out = new Vector3(1173.377f, -3196.656f, -39.67186f),
                    GetService = new Vector3(724.9796f, -1069.167f, 27.64651f),
                    ComputerPosition = new Vector3(1162.936f, -3196.596f, -39.40295f),
                    CoffrePosition = new Vector3(727.0012f, -1065.203f, 27.64651f),
                    GarbageVehicle = new Vector3(733.905f, -1057.322f, 21.39324f),
                    SpawnVehicle = new Vector3(740.3875f, -1054.981f, 21.2744f),
                    GarbageHeli = new Vector3(-583.0386f, -923.396f, 36.17921f),
                    SpawnHeli = new Vector3(-583.4398f, -930.6013f, 36.17921f),
                    InsideTop = new Vector3(-589.8537f, -912.5399f, 23.23489f),
                    OutTop = new Vector3(-568.6429f, -927.7338f, 36.17921f),
                    IPL = "",
                    State = 0,
                },
            }, typeof(List<JobsData.MarshalData>)
                ),

             new Tuple<string, int, bool, object, Type>("Concessionaire Automatique", 25, true, new List<JobsData.MarshalData>() {
                new JobsData.MarshalData() {
                    Inside = new Vector3(-598.3453f, -929.8484f, 23.20639f),
                    Out = new Vector3(1173.377f, -3196.656f, -39.67186f),
                    GetService = new Vector3(724.9796f, -1069.167f, 27.64651f),
                    ComputerPosition = new Vector3(1162.936f, -3196.596f, -39.40295f),
                    CoffrePosition = new Vector3(727.0012f, -1065.203f, 27.64651f),
                    GarbageVehicle = new Vector3(733.905f, -1057.322f, 21.39324f),
                    SpawnVehicle = new Vector3(740.3875f, -1054.981f, 21.2744f),
                    GarbageHeli = new Vector3(-583.0386f, -923.396f, 36.17921f),
                    SpawnHeli = new Vector3(-583.4398f, -930.6013f, 36.17921f),
                    InsideTop = new Vector3(-589.8537f, -912.5399f, 23.23489f),
                    OutTop = new Vector3(-568.6429f, -927.7338f, 36.17921f),
                    IPL = "",
                    State = 0,
                },
            }, typeof(List<JobsData.MarshalData>)
                ),
        };



        public JobsTicks() {
            Events.Tick += OnTick;
        }

        private void OnTick(List<Events.TickNametagData> nametags)
        {
            dynamic data = null;
            if (!Active)
                OnResourcesLoad();
            for (int i = 0; i < Jobs.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        data = (List<JobsData.ClothShopData>)Jobs[i].Item4;
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (ListJobs.EventClothShop.instance != null)
                                ListJobs.EventClothShop.instance.Draw(data[j]);
                        }
                        break;
                    case 1:
                        data = (List<JobsData.MarketShopData>)Jobs[i].Item4;
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (ListJobs.EventMarketShop.instance != null)
                                ListJobs.EventMarketShop.instance.Draw(data[j]);
                        }
                        break;
                    case 2:
                        data = (List<JobsData.BennysCustomData>)Jobs[i].Item4;
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (ListJobs.EventBennysCustom.instance != null)
                                ListJobs.EventBennysCustom.instance.Draw(data[j]);
                        }
                        break;
                    /*case 3:
                        data = (List<JobsData.WeazelNewsData>)Jobs[i].Item4;
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (ListJobs.EventWeazelNews.instance != null)
                                ListJobs.EventWeazelNews.instance.Draw(data[j]);
                        }
                        break;
                    case 4:
                        data = (List<JobsData.FishData>)Jobs[i].Item4;
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (ListJobs.EventFish.instance != null)
                                ListJobs.EventFish.instance.Draw(data[j]);
                        }
                        break;
                    case 5:
                        data = (List<JobsData.RenssonConcessData>)Jobs[i].Item4;
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (ListJobs.EventRenssonConcess.instance != null)
                                ListJobs.EventRenssonConcess.instance.Draw(data[j]);
                        }
                        break;
                    case 6:
                        data = (List<JobsData.BlackKnightData>)Jobs[i].Item4;
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (ListJobs.EventBlackKnight.instance != null)
                                ListJobs.EventBlackKnight.instance.Draw(data[j]);
                        }
                        break;
                    case 7:
                        data = (List<JobsData.LostData>)Jobs[i].Item4;
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (ListJobs.EventLost.instance != null)
                                ListJobs.EventLost.instance.Draw(data[j]);
                        }
                        break;
                    case 8:
                        data = (List<JobsData.TaxiData>)Jobs[i].Item4;
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (ListJobs.EventTaxi.instance != null)
                                ListJobs.EventTaxi.instance.Draw(data[j]);
                        }
                        break;
                    case 9:
                        data = (List<JobsData.DAndCData>)Jobs[i].Item4;
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (ListJobs.EventDAndC.instance != null)
                                ListJobs.EventDAndC.instance.Draw(data[j]);
                        }
                        break;
                    case 10:
                        data = (List<JobsData.BrinksData>)Jobs[i].Item4;
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (ListJobs.EventBrinks.instance != null)
                                ListJobs.EventBrinks.instance.Draw(data[j]);
                        }
                        break;
                    case 11:
                        data = (List<JobsData.OrganizData>)Jobs[i].Item4;
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (ListJobs.EventOrganiz.instance != null)
                                ListJobs.EventOrganiz.instance.Draw(data[j]);
                        }
                        break;
                    case 12:
                        data = (List<JobsData.NigloTattooData>)Jobs[i].Item4;
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (ListJobs.EventNigloTattoo.instance != null)
                                ListJobs.EventNigloTattoo.instance.Draw(data[j]);
                        }
                        break;
                    case 13:
                        data = (List<JobsData.BurnsData>)Jobs[i].Item4;
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (ListJobs.EventBurns.instance != null)
                                ListJobs.EventBurns.instance.Draw(data[j]);
                        }
                        break;
                    case 14:
                        data = (List<JobsData.BarioData>)Jobs[i].Item4;
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (ListJobs.EventBario.instance != null)
                                ListJobs.EventBario.instance.Draw(data[j]);
                        }
                        break;
                    case 15:
                        data = (List<JobsData.PetrolData>)Jobs[i].Item4;
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (ListJobs.EventClothShop.instance != null)
                                ListJobs.EventClothShop.instance.Draw(data[j]);
                        }
                        break;
                    case 16:
                        data = (List<JobsData.VigneronData>)Jobs[i].Item4;
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (ListJobs.EventVigneron.instance != null)
                                ListJobs.EventVigneron.instance.Draw(data[j]);
                        }
                        break;
                    case 17:
                        data = (List<JobsData.FarmLarocheData>)Jobs[i].Item4;
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (ListJobs.EventFarmLaroche.instance != null)
                                ListJobs.EventFarmLaroche.instance.Draw(data[j]);
                        }
                        break;
                    case 18:
                        data = (List<JobsData.TransportData>)Jobs[i].Item4;
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (ListJobs.EventTransport.instance != null)
                                ListJobs.EventTransport.instance.Draw(data[j]);
                        }
                        break;
                    case 19:
                        data = (List<JobsData.BankData>)Jobs[i].Item4;
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (ListJobs.EventBank.instance != null)
                                ListJobs.EventBank.instance.Draw(data[j]);
                        }
                        break;
                    case 20:
                        data = (List<JobsData.LSPDData>)Jobs[i].Item4;
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (ListJobs.EventLSPD.instance != null)
                                ListJobs.EventLSPD.instance.Draw(data[j]);
                        }
                        break;
                    case 21:
                        data = (List<JobsData.GouvernementData>)Jobs[i].Item4;
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (ListJobs.EventGouvernement.instance != null)
                                ListJobs.EventGouvernement.instance.Draw(data[j]);
                        }
                        break;
                    case 22:
                        data = (List<JobsData.LSDHData>)Jobs[i].Item4;
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (ListJobs.EventLSDH.instance != null)
                                ListJobs.EventLSDH.instance.Draw(data[j]);
                        }
                        break;
                    case 23:
                        data = (List<JobsData.PoleEmploiData>)Jobs[i].Item4;
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (ListJobs.EventPoleEmploi.instance != null)
                                ListJobs.EventPoleEmploi.instance.Draw(data[j]);
                        }
                        break;
                    case 24:
                        data = (List<JobsData.MarshalData>)Jobs[i].Item4;
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (ListJobs.EventMarshal.instance != null)
                                ListJobs.EventMarshal.instance.Draw(data[j]);
                        }
                        break;*/
                }
            }
        }

        private void OnResourcesLoad()
        {
            Active = false;
        }
    }
}
