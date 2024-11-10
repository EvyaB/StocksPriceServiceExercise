using Newtonsoft.Json;
using StocksPriceServiceExercise.DataReceiver.DataParser;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksPriceServiceExercise.DataManagement.DataParser
{
    internal class JsonDataParser : IDataParser
    {
        public async Task<IEnumerable<StockData>> ParseDataAsync(string data)
        {
            // Asynchronously deserialize JSON to List of Stock data
            var stocksData = await Task.Run(() => JsonConvert.DeserializeObject<List<StockData>>(data));

            ValidataStocksData(stocksData);

            return stocksData;
        }

        // Assistant method to report and possibly fix any issues in the data
        private void ValidataStocksData(IEnumerable<StockData>? stocksData) 
        {
            if (stocksData == null)
            {
                throw new DataException("Data was not in valid json format for stocks price");
            }
            else
            {
                foreach (var stock in stocksData)
                {
                    stock.ValidateData();
                }
            }
        }
    }
}
