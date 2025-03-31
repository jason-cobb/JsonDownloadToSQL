using DataToSQLiteAI;
using System.Text.Json;
using System.Timers;





Database.GetDataFromDatabase();

// add new Index Rate
List<IndexRate> list = new List<IndexRate>();

string url = "https://markets.newyorkfed.org/api/rates/all/latest.json";
string jsonString = await DownloadHelper.GetJsonFromDatabaseAsync(url);

list = await IndexRateService.GetIndexRates(jsonString);
Database.SaveDataToSQLite(list);


Database.GetDataFromDatabase();




