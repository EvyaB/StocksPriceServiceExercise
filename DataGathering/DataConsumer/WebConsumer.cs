using StocksPriceServiceExercise.DataReceiver.DataConsumer;

namespace StocksPriceServiceExercise.DataManagement.DataConsumer
{
    internal class WebConsumer : IDataConsumer
    {
        public async Task<string> GetDataAsync(string targetUri)
        {
            if (targetUri == null)
            {
                Console.WriteLine("Target URI cannot be empty. Stopping web consumer");
                return "";
            }

            // Try to get data from the web data source
            try
            {
                using var client = new HttpClient();
                var content = await client.GetStringAsync(targetUri);

                return content;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to read data from {targetUri} with error: {ex.Message}");
                return "";
            }
        }
    }
}
