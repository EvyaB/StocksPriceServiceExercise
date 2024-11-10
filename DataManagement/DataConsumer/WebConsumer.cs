using Newtonsoft.Json;
using StocksPriceServiceExercise.DataReceiver.DataConsumer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksPriceServiceExercise.DataManagement.DataConsumer
{
    internal class WebConsumer : IDataConsumer
    {
        private readonly string targetUri;

        public WebConsumer(string targetUri)
        {
            this.targetUri = targetUri ?? throw new ArgumentNullException("targetUri", "Missing URI to target");
        }

        public async Task<string> GetDataAsync()
        {
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
