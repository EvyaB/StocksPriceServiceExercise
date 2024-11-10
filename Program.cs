
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
        Console.WriteLine($"AABA price = {StockPriceController.GetLowestPrice("AABA")}");


        await Task.Delay(20000);
        Console.WriteLine($"AABA price = {StockPriceController.GetLowestPrice("AABA")}");
        //Console.WriteLine("========================");
        //foreach (var stock in StockPriceController.GetAllLowestPrices())
        //{
        //    Console.WriteLine($"Stock: {stock.Key} Price: {stock.Value.Price}");
        //}
        //Console.WriteLine("========================");

        // Run continously forever
        await gatheringDataTask;
    }
}
