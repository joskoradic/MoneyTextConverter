This program converts numerical representation of EUR and Cents to the Croatian words
To update to your own language replace following arrays content:

        private static string[] jedan = { "jedna","dvije","tri","četiri","pet","šest","sedam","osam","devet" };
        static string[] dvadeset = { "jedanaest", "dvanaest", "trinaest", "četrnaest" ,"petnaest" ,"šesnaest", "sedamnaest" ,"osamnaest","devetnaest" };
        static string[] deset = { "deset" ,"dvadeset" ,"trideset", "četrdeset" , "pedeset" ,  "šesdeset", "sedamdeset" ,"osamdeset" ,"devedeset" };
        static string[] sto = { "sto" , "dvjesto", "tristo" , "četristo", "petsto" , "šeststo" , "sedamsto" , "osamsto"  , "devetsto" };
        static string[] tisucu = { "tisucu" ,"dvije" ,"tri" , "četiri" ,"pet", "šest" , "sedam" ,"osam" ,"devet" ,"deset" };
        static string tisuce = "tisuce";
        static string tisuca = "tisuca";


Use case:
MoneyTextConverter money = new MoneyTextConverter(kune, centi);  // create money object, Conversion is done while creating the object:
money.ConvertedValueKune // this attribute contains text converted to EUR or USD ro any other currency
money.ConvertedValuecenti // this attribute contain smaller units of the currency , for example cents
