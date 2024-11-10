using CsvHelper;
using Newtonsoft.Json;
using StocksPriceServiceExercise.DataReceiver.DataParser;
using System;
using System.Data;
using System.Globalization;

namespace StocksPriceServiceExercise.DataManagement.DataParser
{
    internal class CsvDataParser : IDataParser
    {
        public async Task<IEnumerable<StockData>> ParseDataAsync(string data)
        {
            using var reader = new StringReader(data);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var stocksData = new List<StockData>();
            await foreach (var stock in csv.GetRecordsAsync<StockData>())
            {
                stocksData.Add(stock);
            }

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
