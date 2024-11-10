# StocksPriceServiceExercise

You are requested to write a console application in C# that reads prices of stocks from different sources and serves the lowest price of a stock upon request.
Source types:
1.	csv files (csv extension)
 
2.	json files (json extension)
 
3.	Urls - Same format as Json file. Can be identified as Url by the https prefix. Sample file can be found here: https://testpublicaft.s3.amazonaws.com/stocks_url.json

[Newtonsoft library can be used for Json parsing]

The application needs to read those sources periodically every 20 seconds (sources can be updated externally).
It also needs to implement two public methods that can be called at any time during the life cycle of the application:
GetLowestPrice(stockName);
GetAllLowestPrices();

There’s no need to implement web service logic, just implement the two method above as public methods.

Please take into consideration that there could be plenty of stocks in each source and the application needs to read and store the prices as efficiently as possible.

We will test efficiency, design (OOD), correctness and clarity of the application. 
Please ask if anything is unclear.

Here’s an implementation of reading data from Url and converting it to a list of stocks. Please use it in your code:
        public async Task<IEnumerable<Stock>> Read(string url)
        {
            using var client = new HttpClient();
            var content = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<IEnumerable<Stock>>(content) 
                   ?? throw new InvalidOperationException();
        }

Good luck!

