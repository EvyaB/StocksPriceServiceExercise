using StocksPriceServiceExercise.DataManagement.DataConsumer;
using StocksPriceServiceExercise.DataManagement.DataParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksPriceServiceExercise.DataReceiver
{
    /// <summary>
    /// This class initializes the various DataSources and attach each to a specific data source
    /// </summary>
    internal class DataSourcesManager
    {
        private List<DataSource> dataSources;

        public DataSourcesManager()
        {
            dataSources = new List<DataSource>();

            // Consider initializing the data sources through configuration instead of hardcoded here
            dataSources.Add(new DataSource(new JsonDataParser(), new FileConsumer(), @"./DataFiles/stocks.json"));
            dataSources.Add(new DataSource(new CsvDataParser(), new FileConsumer(), @"./DataFiles/stocks.csv"));
            dataSources.Add(new DataSource(new JsonDataParser(), new WebConsumer(), @"https://testpublicaft.s3.amazonaws.com/stocks_url.json"));
        }

        public async Task StartGatheringDataAsync()
        {
            List<Task> dataSourceTasks = new List<Task>();

            // Start each of the tasks
            foreach (var dataSource in dataSources) 
            {
                dataSourceTasks.Add(dataSource.StartGatheringDataAsync()); 
            }

            await Task.WhenAll(dataSourceTasks);
        }
    }
}
