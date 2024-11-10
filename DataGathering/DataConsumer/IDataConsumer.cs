namespace StocksPriceServiceExercise.DataReceiver.DataConsumer
{
    /// <summary>
    /// Handle accessing data directly from data source (reading file, accessing web sources...)
    /// </summary>
    internal interface IDataConsumer
    {
        public Task<string> GetDataAsync(string dataSourceUri);
    }
}
