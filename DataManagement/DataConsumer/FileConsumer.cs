using StocksPriceServiceExercise.DataReceiver.DataConsumer;

namespace StocksPriceServiceExercise.DataManagement.DataConsumer
{
    internal class FileConsumer : IDataConsumer
    {
        private readonly string filePath;

        public FileConsumer(string filePath)
        {
            this.filePath = filePath ?? throw new ArgumentNullException("filePath", "Missing path to target json file");
        }

        public async Task<string> GetDataAsync()
        {
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
