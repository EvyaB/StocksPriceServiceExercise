using StocksPriceServiceExercise.DataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksPriceServiceExercise.Service
{
    /// <summary>
    /// This class allows access to the stock prices
    /// </summary>
    public static class StockPriceController
    {
        public static float GetLowestPrice(string stock)
        {
            var stockData = StocksDataManager.GetInstance.GetStockData(stock);

            if (stockData == null)
            {
                Console.WriteLine($"Failed to find price for stock {stock}");
                return -1.0f;
            }
            else 
            { 
                return stockData.Price; 
            }
        }

        public static IDictionary<string, StockData> GetAllLowestPrices() 
        {
            return StocksDataManager.GetInstance.GetAllStocksData();
        }
    }
}
