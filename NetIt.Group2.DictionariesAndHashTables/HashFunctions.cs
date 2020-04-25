using System;
using System.Diagnostics.SymbolStore;
using System.Linq;
#nullable enable

namespace NetIt.Group2.DictionariesAndHashTables
{
    public class HashFunctions
    {

        // 1231436546 -> a@fa-2adsa4a
        // 2543654    -> c!5daec^dx02
        //8erwy9vuo3gqij]5v4wu[9obtie5yjtkpbtvi-0e5obyjoml
        //fds

        public long StringToLong(string stringToBeHashed)
        {
            long sum = long.MinValue;

            foreach (var ch in stringToBeHashed)
            {
                if (ch + sum < long.MaxValue)
                {
                    sum += ch;
                }
            }

            return sum;
        }



        public int StringToIntHash(string stringToBeHashed)
        {
            int sum = 0;
            foreach (var ch in stringToBeHashed)
            {
                sum += ch * 1235;
            }

            if (sum < 1000)
            {
                return sum + 1000 - sum / 2;
            }
            else if (sum > 9999)
            {
                return sum < 11000
                    ? sum % 2
                    : sum % 10000;
            }
            else
            {
                return sum;
            }
        }

        public string HashObject<T>(T item) where T : class
        {
            return item.GetHashCode().ToString();
        }

        public string StringToStringHash(string stringToBeHashed)
        {
            string result = "";
            int whileNotInRange(int number)
            {
                while (number < 33 && (number > 126 && number < 161) && number > 511)
                {
                    if (number < 33)
                    {
                        number += 33;
                    }

                    if (number > 511)
                    {
                        number %= 2;
                    }

                    if (number > 126 && number < 161)
                    {
                        number += 30;
                    }

                    return number;
                }

                return number;
            }
            int sumAllChars(string str)
            {
                int sum = 0;
                foreach (var ch in str)
                {
                    if (sum + ch > int.MaxValue)
                    {
                        sum = sum / 2 + ch;
                    }
                    else
                    {
                        sum += ch;
                    }
                }

                return sum;
            }


            for (int i = 0; i < 4; i++)
            {
                if (stringToBeHashed.Length - 1 > i)
                {
                    result += (char)whileNotInRange(stringToBeHashed[i]);
                }
                else
                {
                    result += (char)(sumAllChars(stringToBeHashed) + i);
                }
            }


            return result; // range of "0000"-"9999" || "aaaa"-"ZZZZ" -> examples: "abef"/"ac92"/"ads1"
        }

        //"abcd" => "bcde"
        //"abcd1" => "bcde"
        //"abcd2134" => "bcde"
        //"1234" => "2345"
        public string StrToStrHash(string stringToBeHashed)
        {
            return string
                .Join("", stringToBeHashed.Select(s => s + 1))
                .Substring(0, 4);
        }


        /// <summary>
        /// Takes random length string and convert it to 4 char string
        /// </summary>
        /// <param name="stringInput"></param>
        /// <returns></returns>
        public string RandomStringTo4CharString(string stringInput)
        {
            if (stringInput.Length < 4)
            {
                for (int i = 0; i <= 4 - stringInput.Length; i++)
                {
                    stringInput += "a";
                }

                return stringInput;
            }
            else if (stringInput.Length == 4)
            {
                return stringInput;
            }
            else
            {
                return stringInput.Substring(0, 4);
            }

        }
    }
}
