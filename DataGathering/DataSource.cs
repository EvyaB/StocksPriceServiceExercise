using StocksPriceServiceExercise.DataManagement;
using StocksPriceServiceExercise.DataReceiver.DataConsumer;
using StocksPriceServiceExercise.DataReceiver.DataParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksPriceServiceExercise.DataReceiver
{
    /// <summary>
    /// This class handles receiving and parsing data continously from a single data source
    /// </summary>
    internal class DataSource
    {
        private IDataParser dataParser;
        private IDataConsumer dataConsumer;
        private int parsingInterval; // Milliseconds
        private string dataSourceUri;

        private CancellationTokenSource dataGatheringCancellationToken;

        public DataSource(IDataParser dataParser, IDataConsumer dataConsumer, string dataSourceUri, int parsingInterval = 20 * 1000)
        {
            this.dataSourceUri = dataSourceUri;
            this.parsingInterval = parsingInterval;
            this.dataParser = dataParser;
            this.dataConsumer = dataConsumer;
        }

        public async Task StartGatheringDataAsync()
        {
            dataGatheringCancellationToken = new CancellationTokenSource();
            await GatherDataAsync(dataGatheringCancellationToken.Token);
        }

        protected async Task GatherDataAsync(CancellationToken ct)
        {
            // Run every parsingInterval until cancelled
            while (!ct.IsCancellationRequested)
            {
                // Get data from the data source
                var rawData = await dataConsumer.GetDataAsync(this.dataSourceUri);
                
                // Parse data into the stocks data
                var stocksData = await dataParser.ParseDataAsync(rawData);
                
                // Save the data
                StocksDataManager.GetInstance.UpdateStocks(stocksData);

                // Wait before gathering data again
                await Task.Delay(parsingInterval, ct);
            }
        }
    }
}
