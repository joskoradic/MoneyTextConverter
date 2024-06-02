using System;
using System.Collections.Generic;
using System.Text;

namespace projekt
{
    class MoneyTextConverter
    {
        private static string[] jedan = { "jedna","dvije","tri","četiri","pet","šest","sedam","osam","devet" };

        static string[] dvadeset = { "jedanaest", "dvanaest", "trinaest", "četrnaest" ,"petnaest" ,"šesnaest", "sedamnaest" ,"osamnaest","devetnaest" };

        static string[] deset = { "deset" ,"dvadeset" ,"trideset", "četrdeset" , "pedeset" ,  "šesdeset", "sedamdeset" ,"osamdeset" ,"devedeset" };

        static string[] sto = { "sto" , "dvjesto", "tristo" , "četristo", "petsto" , "šeststo" , "sedamsto" , "osamsto"  , "devetsto" };

        static string[] tisucu = { "tisucu" ,"dvije" ,"tri" , "četiri" ,"pet", "šest" , "sedam" ,"osam" ,"devet" ,"deset" };

        static string tisuce = "tisuce";
        static string tisuca = "tisuca";

        public string ConvertedValueKune { get; set; }
        public string ConvertedValuecenti { get; set; }

        public MoneyTextConverter(int kune, int centi)
        {
            bool whole_number = false;
            bool two_numbers = false;
            int[] array = new int[5];
            ConvertedValueKune = MoneyConverter(array,kune);


            whole_number = false;
            two_numbers = false;
            array[0] = 0;
            array[1] = 0;
            FormatArrayToHundred(ref array, centi,ref whole_number,ref two_numbers);
            ConvertedValuecenti = DoSto(array,whole_number, two_numbers);
        }


        private string MoneyConverter(int [] array, int cijena)
        {
            int result = 0;

            bool whole_numb  = false;

            bool two_numbers = false;

            string parsed_object = "";

            array[0] = 0;
            array[1] = 0;
            array[2] = 0;
            array[3] = 0;
            array[4] = 0;

            int length = 0;

            if (cijena > 0 && cijena < 10)
            {
                array[0] = cijena;
                length = 1;
            }

            if (cijena > 9 && cijena < 100)
            {
                array[0] = cijena % 10;
                result = cijena / 10;
                array[1] = result % 10;
                length = 2;

                if (array[0] == 0)
                {
                    whole_numb = true;
                }
                else
                {
                    ;
                }

                if (cijena > 10 && cijena < 20)
                {
                    two_numbers = true;
                }
                else
                {

                }
            }

            if (cijena >= 100 && cijena < 1000)
            {
                array[0] = cijena % 10;
                result = cijena / 10;
                array[1] = result % 10;
                result = result / 10;
                array[2] = result % 10;
                length = 3;
            }
            else if (cijena >= 1000 && cijena < 10000)
            {
                array[0] = cijena % 10;
                result = cijena / 10;
                array[1] = result % 10;
                result = result / 10;
                array[2] = result % 10;
                result = result / 10;
                array[3] = result % 10;
                length = 4;
            }
            else if (cijena >= 10000 && cijena < 100000)
            {
                array[0] = cijena % 10;
                result = cijena / 10;
                array[1] = result % 10;
                result = result / 10;
                array[2] = result % 10;
                result = result / 10;
                array[3] = result % 10;
                result = result / 10;
                array[4] = result % 10;
                length = 5;
            }
            else
            {
            }

            parsed_object =  MoneParseNumber(array,length, whole_numb, two_numbers);

            return parsed_object;
        }



        private int FormatArrayToHundred(ref int [] array, int cijena, ref bool whole_numb, ref bool two_numbers)
        {
            int length = 0;

            int temp = 0;

            if (cijena > 0 && cijena < 10)
            {
                array[0] = cijena;
                length = 1;
            }

            if (cijena > 9 && cijena < 100)
            {
                array[0] = cijena % 10;
                temp = cijena / 10;
                array[1] = temp % 10;
                length = 2;

                if (array[0] == 0)
                {
                    whole_numb = true;
                }
                else
                {
                    ;
                }

                if (cijena > 10 && cijena < 20)
                {
                    two_numbers = true;
                }
                else
                {

                }
            }
            return length;
        }


        private string MoneParseNumber(int [] array, int length, bool whole_numb, bool two_numbers)
        {
            string cijena_string = "";

            if (length == 1)
            {
                cijena_string += jedan[array[0] - 1];
            }
            else if (length == 2)
            {
                cijena_string = DoSto(array,whole_numb, two_numbers);
            }
            else if (length == 3)
            {
                cijena_string += sto[array[2] - 1];
                if (array[0] != 0)
                {
                    if (array[1] == 1)
                    {
                        cijena_string += dvadeset[array[0] - 1];
                    }
                    else
                    {
                        if (array[1] != 0)
                            cijena_string += deset[array[1] - 1];
                    }

                    if (array[1] != 1)
                    {
                        cijena_string += jedan[array[0] - 1];
                    }
                    else
                    {

                    }
                }
                else
                {
                    if (array[1] != 0)
                        cijena_string += deset[array[1] - 1];
                }
            }
            else if (length == 4)
            {
                cijena_string += tisucu[array[3] - 1];

                if (array[3] > 1 && array[3] < 5)
                {
                    cijena_string += tisuce;
                }
                else if (array[3] >= 5)
                {
                    cijena_string += tisuca;
                }
                else
                {

                }

                cijena_string += DoTisucu(array);
            }
            else if (length == 5)
            {
                if (array[3] == 0)
                {
                    cijena_string += deset[array[4] - 1];
                    cijena_string += tisuca;
                }
                else
                {
                    if (array[4] == 1)
                    {
                        cijena_string += dvadeset[array[3] - 1];
                        cijena_string += tisuca;
                    }
                    else
                    {
                        cijena_string += deset[array[4] - 1];
                        cijena_string += jedan[array[3] - 1];
                        if (array[3] >= 2 && array[3] <= 4)
                            cijena_string += tisuce;
                        else
                            cijena_string += tisuca;
                    }
                }

                cijena_string += DoTisucu(array);

            }
            else
            {

            }

            return cijena_string;
        }


        private string DoSto(int [] array, bool whole_numb, bool two_numbers)
        {
            string cijena_string = "";

            if (whole_numb)
            {
                cijena_string += deset[array[1] - 1];
            }
            else if (!two_numbers)
            {
                if(array[1] != 0)
                cijena_string += deset[array[1] - 1];
                if(array[0] != 0)
                cijena_string += jedan[array[0] - 1];
            }
            if (two_numbers)
            {
                cijena_string += dvadeset[array[0] - 1];
            }

            return cijena_string;
        }



        private string DoTisucu(int [] array)
        {
            string cijena_string = "";

            if (array[2] != 0)
                cijena_string += sto[array[2] - 1];
            if (array[0] != 0)
            {
                if (array[1] == 1)
                {
                    cijena_string += dvadeset[array[0] - 1];
                }
                else
                {
                    if (array[1] != 0)
                        cijena_string += deset[array[1] - 1];
                }

                if (array[1] != 1)
                {
                    cijena_string += jedan[array[0] - 1];
                }
                else
                {

                }
            }
            else
            {
                if (array[1] != 0)
                    cijena_string += deset[array[1] - 1];
            }

            return cijena_string;
        }
    }
}
