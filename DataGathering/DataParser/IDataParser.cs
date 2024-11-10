using StocksPriceServiceExercise.DataManagement;

namespace StocksPriceServiceExercise.DataReceiver.DataParser
{
    /// <summary>
    /// This handles parsing data from a specific format into the stock Name&Price format
    /// </summary>
    internal interface IDataParser
    {
        public Task<IEnumerable<StockData>> ParseDataAsync(string data);
    }
}
