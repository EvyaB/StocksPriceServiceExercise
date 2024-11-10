
using StocksPriceServiceExercise.DataReceiver;
using StocksPriceServiceExercise.Service;
using System.Runtime.InteropServices;

class Program
{
    static async Task Main()
    {
        DataSourcesManager dataSourcesManager = new DataSourcesManager();
        
        Task gatheringDataTask = dataSourcesManager.StartGatheringDataAsync();

        // Test data 
        await Task.Delay(2000);
        Console.WriteLine($"AAPL price = {StockPriceController.GetLowestPrice("AAPL")}");

        Console.WriteLine("========================");
        foreach (var stock in StockPriceController.GetAllLowestPrices())
        {
            Console.WriteLine($"Stock: {stock.Key} Price: {stock.Value.Price}");
        }
        Console.WriteLine("========================");

        // Run continously forever
        await gatheringDataTask;
    }
}
