using NetIt.Group2.DictionariesAndHashTables;
using System;
using System.Collections.Generic;

namespace NetIt.Group2.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var hashFunctions = new HashFunctions();
            var hashTable = new CustomHashTable<string,string>(hashFunctions.HashObject);

            hashTable.Add("12", "Stefan Peev");
            hashTable.Add("abc", "Ivan Gabrovski");

            System.Console.WriteLine(hashTable.Find("12"));
            System.Console.WriteLine(hashTable.Find("abc"));

            foreach (var item in hashTable)
            {
                System.Console.WriteLine($"{item.Key}, {item.Value}");
            }

        }
    }
}
