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

        public void UpdateStocks(IEnumerable<StockData> newStocksData)
        {
            // TODO - consider if need a lock here due to parallelization between getting existingStock and checking the price
            // TODO - consider making this whole process async?
            foreach (var newStockData in newStocksData)
            {
                // Check if the stock already exists in the data - if it is then check if its new price is lowered than the previous (only save if lower)
                if (stocksData.TryGetValue(newStockData.Name, out var existingStock))
                {
                    if (existingStock.Price > newStockData.Price)
                    {
                        stocksData[newStockData.Name] = newStockData;
                    }
                }
                // received new stock -> save as is
                else
                {
                    stocksData[newStockData.Name] = newStockData;
                }
            }    
        }

        public StockData GetStockData(string stock) 
        {
            return stocksData[stock];
        }
    }
}
