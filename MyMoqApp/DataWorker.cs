using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoqApp
{
    public class DataWorker
    {
        public IDatabase Database;

        public DataWorker(IDatabase database)
        {
            Database = database;
        }

        public string[] ReverseValues()
        {
            var values = Database.GetValues();
            var reversedValues = new List<string>();
            foreach (var value in values)
            {
                var reversed = "";
                foreach (var letter in value.ToCharArray())
                {
                    reversed = letter + reversed;
                }
                reversedValues.Add(reversed);
            }
            return reversedValues.ToArray();
        }

        public string FormatCount()
        {
            var count = Database.GetCountOfVAlues();
            return  ((float)count).ToString("0.00");
        }
    }
}
