using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksPriceServiceExercise.DataManagement
{
    public class StockData
    {
        [CsvHelper.Configuration.Attributes.Name("Symbol")]
        public string Name { get; set; }

        [CsvHelper.Configuration.Attributes.Name("Price")]
        public float Price { get; set; }

        internal void ValidateData()
        {
            if (string.IsNullOrEmpty(Name))
            {
                // Worth considering throwing a bigger warning for this
                Console.WriteLine("Missing name for this stock!");
            }
            if (Price < 0) 
            {
                Console.WriteLine($"Stock {Name} price was somehow set to negative (was {Price}), defaulting to zero value");
                Price = 0;
            }
        }
    }
}
