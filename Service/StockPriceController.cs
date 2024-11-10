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
        public static int GetLowestPrice(string stock)
        {
            return StocksDataManager.GetInstance.GetStockData(stock).Price;
        }

        public static IDictionary<string, StockData> GetAllLowestPrices() 
        {
            return StocksDataManager.GetInstance.GetAllStocksData();
        }
    }
}
