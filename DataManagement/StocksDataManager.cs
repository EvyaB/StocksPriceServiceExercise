using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksPriceServiceExercise.DataManagement
{
    /// <summary>
    /// Singleton data manager that serves as a DB that holds the stocks data
    /// </summary>
    internal class StocksDataManager
    {
        private static readonly StocksDataManager instance = new StocksDataManager();
        public static StocksDataManager GetInstance
        {
            get
            {
                return instance;
            }
        }

        private ConcurrentDictionary<string, StockData> stocksData;

        private StocksDataManager()
        {
            stocksData = new ConcurrentDictionary<string, StockData>();
        }

        // TODO - consider making this whole process async?
        public void UpdateStocks(IEnumerable<StockData> newStocksData)
        {
            foreach (var newStockData in newStocksData)
            {
                // Check if the stock already exists in the data - if it is then check if its new price is lowered than the previous (only save if lower)
                // Adjust the value atomically based on a condition
                stocksData.AddOrUpdate(newStockData.Name, newStockData, (key, existingStockData) =>
                {
                    if (existingStockData.Price > newStockData.Price)
                    {
                        return newStockData;
                    }
                    else
                    {
                        return existingStockData;
                    }
                });
            }    
        }

        public StockData? GetStockData(string stock)
        {
            if (stocksData.TryGetValue(stock, out var stockData))
            {
                return stockData;
            }
            else
            {
                return null;
            }
        }

        public IDictionary<string, StockData> GetAllStocksData()
        {
            return stocksData.ToDictionary();
        }
    }
}
