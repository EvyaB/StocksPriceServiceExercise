using StocksPriceServiceExercise.DataReceiver.DataConsumer;

namespace StocksPriceServiceExercise.DataManagement.DataConsumer
{
    internal class FileConsumer : IDataConsumer
    {
        public async Task<string> GetDataAsync(string filePath)
        {
            if (filePath == null)
            {
                Console.WriteLine("Path to file cannot be empty. Stopping file consumer");
                return "";
            }

            // Try to get data from filePath
            try
            {
                string fileData;
                using (var reader = new StreamReader(filePath))
                {
                    fileData = await reader.ReadToEndAsync();
                }
                return fileData;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to read file {filePath} with error: {ex.Message}");
                return "";
            }
        }
    }
}
