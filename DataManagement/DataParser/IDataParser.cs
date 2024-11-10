using StocksPriceServiceExercise.DataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksPriceServiceExercise.DataReceiver.DataParser
{
    /// <summary>
    /// This handles parsing data from a specific format into the stock Name&Price format
    /// </summary>
    internal interface IDataParser
    {
        public Task<IEnumerable<StockData>> ParseData(string data);
    }
}
