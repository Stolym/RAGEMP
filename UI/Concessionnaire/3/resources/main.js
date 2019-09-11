// ID des voitures affichées
var displayedID = {}

// véhicules disponibles
var cars = {
    "Compact": {
        "Brioso":          			 {prix: 15000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Felon":           			 {prix: 38000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Felon GT":        			 {prix: 39000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Oracle":          			 {prix: 28000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Oracle XS":       			 {prix: 39000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Sentinel":        			 {prix: 42000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Sentinel XS":     			 {prix: 45000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Zion":            			 {prix: 38000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Zion Cabrio":     			 {prix: 39000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
    },
    "Muscle" : {
        "Blade":           			 {prix: 42000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Buccaneer":       			 {prix: 27000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Chino":           			 {prix: 16000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Dukes":           			 {prix: 29000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Ellie":           			 {prix: 50000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Faction":         			 {prix: 19000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Faction Custom":  			 {prix: 19000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Dominator":       			 {prix: 39000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Gauntlet":        			 {prix: 37000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Impaler":         			 {prix: 27000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Moonbeam":        			 {prix: 22000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Nightshade":      			 {prix: 80000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Phoenix":         			 {prix: 38000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Picador":         			 {prix: 15000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Rat-Truck":       			 {prix: 13000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Ruiner":          			 {prix: 22000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "SabreGT":         			 {prix: 24000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "SlamVan":         			 {prix: 30000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "SlamVan Custom":            {prix: 32000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Tampa":                     {prix: 35000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Declasse Tulip":            {prix: 65000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Declasse Vamos":            {prix: 32000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Vigero":                    {prix: 17000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Virgo":                     {prix: 15000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Virgo Classique":           {prix: 17000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Virgo Classique Custom":    {prix: 20000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Voodoo":                    {prix: 7000,   selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Yosemite":                  {prix: 30000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
    },
    "Tout terrain": {
        "Injection":                 {prix: 12000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Bodhi":                     {prix: 5000,   selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Brawler":                   {prix: 53000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Duneloader":                {prix: 3000,   selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Kalahari":                  {prix: 4500,   selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Mesa":                      {prix: 23000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Mesa tout-terrain":         {prix: 38000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Rancher XL":                {prix: 6000,   selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Rebel V2":                  {prix: 18000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Riata":                     {prix: 33000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Sandking SWB":              {prix: 35000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Sandking XL":               {prix: 35000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
    },
    "SUV": {
        "BeeJay XL":                 {prix: 30000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Baller":                    {prix: 35000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Baller V2":                 {prix: 45000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Cavalcade":                 {prix: 30000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Cavalcade V2":              {prix: 38000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Dubsta":                    {prix: 45000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "FQ 2":                      {prix: 24000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Gresley":                   {prix: 34000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Habanero":                  {prix: 17000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Huntley S":                 {prix: 53000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Landstalker":     	         {prix: 33000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Patriot":         	         {prix: 45000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Radius":                    {prix: 29000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Rocoto":                    {prix: 31000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Seminole":                  {prix: 30000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Benefactor Serrano":        {prix: 24000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "XLS":                       {prix: 60000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
    },
    "Sedans": {
        "Asterope":                  {prix: 4100,   selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Cognoscenti":               {prix: 55000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Emperor":                   {prix: 5000,   selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Fugitive":                  {prix: 34000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Glendale":                  {prix: 25000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Karin Intruder":            {prix: 16000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Premier":                   {prix: 21000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Primo Custom":              {prix: 19000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Stanier":                   {prix: 12000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Stratum":                   {prix: 10000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Surge":                     {prix: 16000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Tailgater":                 {prix: 31000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Warrener":                  {prix: 20000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Washington":                {prix: 25000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
    },
    "Sportive": {
        "Alpha":                     {prix: 132000, selectedColor: 21, hasAnimatedImg: true, hashcode: 0x01},
        "Banshee":                   {prix: 180000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Buffalo":                   {prix: 78000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Carbonizzare":              {prix: 128000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Comet":                     {prix: 142000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Comet Rétro Custom":        {prix: 170000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Coquette":                  {prix: 139000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Elegy RH8":                 {prix: 154000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Feltzer":                   {prix: 101000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Furore GT":                 {prix: 139000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Fusilade":                  {prix: 75000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Futo":                      {prix: 35000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Vapid GB200":               {prix: 100000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Lynx":                      {prix: 156000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Jester":                    {prix: 170000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Khamelion":                 {prix: 144000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Lynx":                      {prix: 178000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Massacro":                  {prix: 167000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "9F":                        {prix: 136000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "9F Cabrio":                 {prix: 136000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Penumbra":                  {prix: 76000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Raiden":                    {prix: 120000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Rapid GT":                  {prix: 113000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Rapid GT V2":               {prix: 125000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Revolter":                  {prix: 178000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Ruston":                    {prix: 141000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Schafter":                  {prix: 89000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Schlagen":                  {prix: 178000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Schwarzer":                 {prix: 93000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Sentinel Classique":        {prix: 74000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Seven70":                   {prix: 145000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Specter":                   {prix: 179000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Specter2":                  {prix: 185000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Streiter":                  {prix: 85000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Sultan":                    {prix: 89000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Surano":                    {prix: 101000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Verlierer2":                {prix: 108000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "ZR380":                     {prix: 140000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
    },
    "Sportive classic": {	
        "Truffade Z-Type":           {prix: 215000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Casco":                     {prix: 180000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Cheburek":                  {prix: 28000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Coquette classique":        {prix: 231000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Coquette BlackFin":         {prix: 245000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Deluxo":                    {prix: 89000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Fagaloa":                   {prix: 5000,   selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Jester classique":          {prix: 115000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Manana":                    {prix: 25000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Michelli":                  {prix: 75000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Peyote":                    {prix: 25000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Pigalle":                   {prix: 23000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Rapid GT classique":        {prix: 135000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Retinue":                   {prix: 39000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Savestra":                  {prix: 89000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Stinger":                   {prix: 205000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Tornado":                   {prix: 19000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Tornado V2":                {prix: 24000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
        "Tornado Custom":            {prix: 29000,  selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
		"Sentinel Classique":        {prix: 325000, selectedColor: 21, hasAnimatedImg: false, hashcode: 0x01},
    }
}

// couleurs disponibles
var couleurs = {
    "Classique": {
        "c132": {color: "#fefff9", name: "Blanc"},
        "c21":  {color: "#1a212b", name: "Noir"},
        "c43":  {color: "#99131c", name: "Rouge"},
        "c126": {color: "#eac630", name: "Jaune taxi"},
        "c57":  {color: "#215843", name: "Vert"},
        "c77":  {color: "#264f8d", name: "Bleu"}
    }
}

// toutes couleurs existantes
var toutesCouleurs = {
    "Métallique":{
        "c111": {color: "#fefff7", name: "Blanc"},
        "c112": {color: "#e8e8e8", name: "Blanc de givre"},
        "c0":   {color: "#0f1219", name: "Noir"},
        "c147": {color: "#10131a", name: "Noir spécial"},
        "c1":   {color: "#222325", name: "Noir graphite"},
        "c141": {color: "#0d1321", name: "Noir bleu"},
        "c2":   {color: "#30353b", name: "Steal Black "},
        "c3":   {color: "#434b4e", name: "Argent foncé"},
        "c4":   {color: "#969a9d", name: "Argent"},
        "c5":   {color: "#c0c4c5", name: "Bleu Silver"},
        "c146": {color: "#09131f", name: "Bleu Foncé"},
        "c6":   {color: "#949695", name: "Gris acier"},
        "c7":   {color: "#5f6f7c", name: "Gris ombre"},
        "c8":   {color: "#5f5e59", name: "Pierre d'argent"},
        "c9":   {color: "#3a3f45", name: "Argent minuit"},
        "c10":  {color: "#414c52", name: "Métal"},
        "c11":  {color: "#1e212a", name: "Gris anthracite"},
        "c27":  {color: "#b8121e", name: "Rouge"},
        "c28":  {color: "#d41a1f", name: "Rouge Torino"},
        "c29":  {color: "#ab1926", name: "Rouge formule 1"},
        "c30":  {color: "#a12024", name: "Rouge blaze"},
        "c31":  {color: "#781b25", name: "Rouge gracieux "},
        "c32":  {color: "#881b21", name: "Rouge grenat "},
        "c33":  {color: "#721a19", name: "Rouge du désert"},
        "c34":  {color: "#45131f", name: "Rouge cabernet "},
        "c35":  {color: "#ae1228", name: "Rouge bonbon "},
        "c143": {color: "#10101a", name: "Rouge noir"},
        "c36":  {color: "#d04719", name: "Orange soleil"},
        "c37":  {color: "#bb8e4b", name: "Gold"},
        "c38":  {color: "#f48116", name: "Orange"},
        "c137": {color: "#dd5891", name: "Rose vermillon"},
        "c135": {color: "#ee1f93", name: "Rose chaud"},
        "c136": {color: "#fccfcc", name: "Rose saumon"},
        "c49":  {color: "#13242b", name: "Vert foncé"},
        "c50":  {color: "#122f2b", name: "Vert racing"},
        "c51":  {color: "#14393f", name: "Vert mer"},
        "c52":  {color: "#303e3e", name: "Vert olive"},
        "c53":  {color: "#185b32", name: "Vert"},
        "c92":  {color: "#a6dc2e", name: "Vert chaux"},
        "c125": {color: "#80bf64", name: "Vert teint"},
        "c54":  {color: "#1c666f", name: "Essence bleu"},
        "c61":  {color: "#28344c", name: "Bleu foncé"},
        "c62":  {color: "#253358", name: "Bleu nuit"},
        "c63":  {color: "#36517c", name: "Bleu de Saxe"},
        "c64":  {color: "#566493", name: "Bleu"},
        "c65":  {color: "#7389ae", name: "Bleu marine"},
        "c66":  {color: "#394761", name: "Bleu gris"},
        "c67":  {color: "#d4e5ef", name: "Bleu diamant"},
        "c68":  {color: "#74acbd", name: "Blue surf"},
        "c69":  {color: "#315a6e", name: "Bleu nautique"},
        "c70":  {color: "#0b95ed", name: "Bleu vif"},
        "c71":  {color: "#2d2b52", name: "Bleu violet"},
        "c72":  {color: "#292c4d", name: "Bleu Spinnaker"},
        "c73":  {color: "#2955a0", name: "Blue ultra"},
        "c74":  {color: "#669abf", name: "Bleu clair"},
        "c88":  {color: "#feca1f", name: "Jaune Taxi"},
        "c89":  {color: "#fadf16", name: "Jaune"},
        "c91":  {color: "#e5e643", name: "Jaune pousin"},
        "c90":  {color: "#895e33", name: "Bronze"},
        "c93":  {color: "#988b78", name: "Champagne"},
        "c94":  {color: "#4c301a", name: "Beige"},
        "c95":  {color: "#463d2c", name: "Ivoire foncé "},
        "c96":  {color: "#201a1a", name: "Marron choco"},
        "c97":  {color: "#613d23", name: "Marron doré "},
        "c98":  {color: "#74593e", name: "Marron clair "},
        "c99":  {color: "#b4a27e", name: "Beige paille "},
        "c100": {color: "#6d6c4d", name: "Marron"},
        "c101": {color: "#3e2e2e", name: "Marron biston"},
        "c102": {color: "#9e915d", name: "Bois de hêtre "},
        "c103": {color: "#542f27", name: "Bois de hêtre foncé "},
        "c104": {color: "#762b16", name: "Orange choco"},
        "c105": {color: "#bdac78", name: "Sable de plage "},
        "c106": {color: "#e1d4b2", name: "Sable  soleil"},
        "c107": {color: "#f4ead1", name: "Crème"},
        "c142": {color: "#0f1521", name: "Violet noir"},
        "c145": {color: "#5f1375", name: "Violet"},
        "c145": {color: "#5f1375", name: "Violet"}
    },
    "Mat": {
        "c131": {color: "#faf7f0", name: "Blanc"},
        "c12":  {color: "#101721", name: "Noir"},
        "c13":  {color: "#1d2025", name: "Gris"},
        "c14":  {color: "#494e51", name: "Gris clair"},
        "c39":  {color: "#c81318", name: "Rouge"},
        "c40":  {color: "#6c171a", name: "Rouge foncé"},
        "c41":  {color: "#ec7318", name: "Orange"},
        "c42":  {color: "#ffc418", name: "Jaune"},
        "c55":  {color: "#62b622", name: "Vert lime"},
        "c82":  {color: "#15204d", name: "Bleu foncé"},
        "c83":  {color: "#1c30a0", name: "Bleu "},
        "c84":  {color: "#182f4f", name: "Bleu midnight"},
        "c128": {color: "#4f6445", name: "Vert"},
        "c129": {color: "#bdac90", name: "Marron"},
        "c149": {color: "#16171c", name: "Violet "},
        "c148": {color: "#691e79", name: "Violet foncé"},
        "c150": {color: "#bb1819", name: "Rouge de lave"},
        "c151": {color: "#293126", name: "Vert forée"},
        "c152": {color: "#5f6040", name: "Vert Olive"},
        "c153": {color: "#7b6c55", name: "Marron desert"},
        "c154": {color: "#bfb08f", name: "Vert tan"},
        "c155": {color: "#505849", name: "Vert foilage"}
    },
    "Classique": {
        "c132": {color: "#fefff9", name: "Blanc"},
        "c134": {color: "#fffff7", name: "Blanc pure"},
        "c121": {color: "#e3e0d7", name: "Blanc cassé"},
        "c122": {color: "#dddbcf", name: "Blanc gris"},
        "c21":  {color: "#1a212b", name: "Noir"},
        "c15":  {color: "#131925", name: "Noir bleu"},
        "c16":  {color: "#1e222b", name: "Noir poly"},
        "c86":  {color: "#52668b", name: "Bleu"},
        "c85":  {color: "#475b80", name: "Bleu foncé"},
        "c87":  {color: "#6db1d4", name: "Bleu clair"},
        "c113": {color: "#ada78f", name: "Beige miel"},
        "c18":  {color: "#818590", name: "Argent"},
        "c24":  {color: "#cdcdcf", name: "Argenté"},
        "c17":  {color: "#323941", name: "Argent foncé"},
        "c19":  {color: "#37444d", name: "Argent métal"},
        "c25":  {color: "#b2b8c4", name: "Gris"},
        "c22":  {color: "#34373c", name: "Gris foncé"},
        "c23":  {color: "#9a9b95", name: "Gris argenté"},
        "c20":  {color: "#4c5d71", name: "Gris ombre"},
        "c26":  {color: "#708290", name: "Gris bleu"},
        "c144": {color: "#9b9a88", name: "Gris vert"},
        "c43":  {color: "#99131c", name: "Rouge"},
        "c44":  {color: "#da1119", name: "Rouge vif"},
        "c45":  {color: "#8c1f18", name: "Rouge grenat"},
        "c46":  {color: "#a64443", name: "Rouge délavé"},
        "c47":  {color: "#ac694f", name: "Rouge doré"},
        "c48":  {color: "#341d25", name: "Rouge foncé"},
        "c123": {color: "#efa92d", name: "Orange"},
        "c124": {color: "#f59d53", name: "Orange clair"},
        "c138": {color: "#f4ab21", name: "Orange vif"},
        "c126": {color: "#eac630", name: "Jaune taxi"},
        "c130": {color: "#f8b658", name: "Orange"},
        "c57":  {color: "#215843", name: "Vert"},
        "c56":  {color: "#22393f", name: "Vert foncé"},
        "c59":  {color: "#42564a", name: "Vert militaire"},
        "c58":  {color: "#2c403f", name: "Vert foncé"},
        "c60":  {color: "#63837e", name: "Vert eau"},
        "c133": {color: "#707240", name: "Vert Olive"},
        "c139": {color: "#a8eb6a", name: "Vert éclatant"},
        "c77":  {color: "#264f8d", name: "Bleu"},
        "c75":  {color: "#112351", name: "Bleu foncé"},
        "c76":  {color: "#1b1f3c", name: "Bleu nuit"},
        "c78":  {color: "#5d838e", name: "Bleu mer"},
        "c157": {color: "#abd2e1", name: "Bleu très clair"},
        "c79":  {color: "#2343a6", name: "Bleu éclair"},
        "c80":  {color: "#3d6ddc", name: "Bleu poly"},
        "c81":  {color: "#3739db", name: "Bleu brillant"},
        "c140": {color: "#0de4f9", name: "Bleu pétant"},
        "c108": {color: "#41301e", name: "Marron"},
        "c109": {color: "#745b33", name: "Marron moyen"},
        "c110": {color: "#b6a07b", name: "Marron clair"},
        "c114": {color: "#433832", name: "Marron terne"},
        "c115": {color: "#433832", name: "Marron foncé"},
        "c116": {color: "#766b57", name: "Beige paille"}
    },
    "Métal": {
        "c117": {color: "#798595", name: "Acier"},
        "c118": {color: "#555b67", name: "Acier noir"},
        "c119": {color: "#99a0a6", name: "Aluminium"},
        "c120": {color: "#a7c3ea", name: "Chrome"},
        "c158": {color: "#7a6343", name: "Pure Gold"},
        "c159": {color: "#776757", name: "Brushed Gold"},
        "c127": {color: "#49c0d8", name: "Bleu police"}
    }
}




init("Concessionnaire automobile");

function init(title){
    document.getElementById("pageTitle").innerHTML = title;
    var shopContainer = document.getElementById("shopContainer")

    for (var key in cars){
        displayedID[key] = 0;
        var slot = document.createElement("div");
        slot.classList.add("slot");
        slot.dataset.name = key;
        displaySlot(slot, 0);
        shopContainer.appendChild(slot);
    }
}

function displaySlot(slot, carnum){
    var categName = slot.dataset.name;
    displayedID[categName] = (displayedID[categName] + carnum) % Object.keys(cars[categName]).length;
    if(displayedID[categName]<0) displayedID[categName] = Object.keys(cars[categName]).length-1;
    var carName = Object.keys(cars[categName])[displayedID[categName]];
    
    if(slot.innerHTML == ""){
        slot.innerHTML = `<div class="slotTitle">${categName}</div><div class="itemPreview"><div class="navArrow">&#x2BC7;</div><div class="itemDesc"><span class="bolditemDesc">${carName}</span><br/>${cars[categName][carName].prix.toLocaleString()} $</div><img class="previewImg" src="assets/static/${carName}.png"><div class="navArrow">&#x2BC8;</div></div>`;
        
        // image click pour ouvrir menu
        slot.childNodes[1].childNodes[2].addEventListener("click", function(e){
            // e.stopPropagation();
            var ss = document.getElementsByClassName("activeslot");
            for(var i=0; i<ss.length; i++) ss[i].classList.remove("activeslot");
            e.currentTarget.parentNode.parentNode.classList.add("activeslot");
            
            //destroyPanier();
            categName = slot.dataset.name;
            carName = Object.keys(cars[categName])[displayedID[categName]];
            panier(categName, carName);
        });

        // navArrow gauche
        slot.childNodes[1].childNodes[0].addEventListener("click", function(e){
            // e.stopPropagation();
            displaySlot(e.currentTarget.parentNode.parentNode, -1);
        });

        // navArrow droite
        slot.childNodes[1].childNodes[3].addEventListener("click", function(e){
            // e.stopPropagation();
            displaySlot(e.currentTarget.parentNode.parentNode, 1);
        });
    }
    else{
        slot.childNodes[1].childNodes[1].innerHTML = `<span class="bolditemDesc">${carName}</span><br/>${cars[categName][carName].prix.toLocaleString()} $`;
        slot.childNodes[1].childNodes[2].src=`assets/static/${carName}.png`;
    }
}


function destroyPanier(){
    document.getElementById("panier").style.display = "none";
    document.getElementById("panier").innerHTML = "";
};

function panier(categName, carName){
    document.getElementById("panier").innerHTML = `<div class="containerTitle">${carName}</div>
    <div id="panierContent" class="containerContents">
        <div class="box">
            <img class="bigPreviewImg" src="${cars[categName][carName].hasAnimatedImg ? `assets/animated/${carName}.gif` : `assets/static/${carName}.png`}">
        </div>
        <div id="colorSelectorBox" class="box">
            <div class="boxTitle">Couleur</div>
        </div>
        <div class="box buttonBox" id="acheterButtonBox">
            <div id="titlePanier">Acheter ${cars[categName][carName].prix.toLocaleString()} $</div>
        </div>
    </div>`;
    
    for(var colorCat in couleurs){
        document.getElementById("colorSelectorBox").innerHTML += `<div class="box"><div class="boxTitle">${colorCat}</div><div id="innerColorSelectorBox${colorCat}" class="colorChoiceBox"></div></div>`;

        console.log(Object.keys(couleurs[colorCat]))

        for(var i=0; i<Object.keys(couleurs[colorCat]).length; i++){

            var color = Object.keys(couleurs[colorCat])[i];

           
            var colorbx = document.createElement('div');
            
            colorbx.classList.add("colorChoice");
            colorbx.style.backgroundColor = couleurs[colorCat][color].color;
            colorbx.dataset.value = color;
            colorbx.innerHTML = `<span>${couleurs[colorCat][color].name}</span>`;

            if(cars[categName][carName].selectedColor == color){
                colorbx.classList.add("selectedColorChoice");
            }

            document.getElementById(`innerColorSelectorBox${colorCat}`).appendChild(colorbx);
        }
    }

    document.getElementById("colorSelectorBox").addEventListener("click", function(e){
        if(e.target.classList.contains("colorChoice")){
            var ss = document.getElementsByClassName("selectedColorChoice");
            for(var i=0; i<ss.length; i++){
                ss[i].classList.remove("selectedColorChoice");
            }
            e.target.classList.add("selectedColorChoice");
            cars[categName][carName].selectedColor = parseInt(e.target.dataset.value.substring(1), 10);
        }
    });

    document.getElementById("acheterButtonBox").addEventListener('click', function(e){
        document.getElementById("checkout").play();
        alert(JSON.stringify({
            category: categName,
            model: carName,
            price: cars[categName][carName].prix,
            color: cars[categName][carName].selectedColor,
            hashcode: cars[categName][carName].hashcode
        }));
    });

    document.getElementById("panier").style.display = "block";
}