# **SQLite Data Loader and Storage**

This project provides a way to download JSON data from a remote source, parse it into C# objects, and store it in an SQLite database. It also includes querying functionality to interact with the stored data.

## **Features**
- Downloads JSON data from a specified API.
- Maps the JSON data to a C# class (`IndexRate` in this case).
- Saves the data into an SQLite database.
- Provides functionality to query and manipulate the data.

---

## **Setup Instructions**

### **Requirements**
- Visual Studio 2022
- .NET 6 (or higher)
- NuGet packages:
  - `System.Data.SQLite`
  - `Newtonsoft.Json`

### **Steps to Set Up**
1. Clone this repository to your local machine:git clone https://github.com/jason-cobb/JsonDownloadToSQL.git
2. 2. Open the solution in Visual Studio 2022.
3. Install the required NuGet packages:Install-Package System.Data.SQLite Install-Package Newtonsoft.Json


---

## **Usage**

### **1. Download JSON Data**
- The application will fetch data from a specified API endpoint.
- Customize the URL in the `GetJsonFromDatabaseAsync` method:
```csharp
var jsonData = await GetJsonFromDatabaseAsync("your-api-endpoint");
```
### **2. Save Data into SQLite**
Run the application to parse JSON data into a list of IndexRate objects:
List<IndexRate> indexRates = JsonConvert.DeserializeObject<List<IndexRate>>(jsonData);

Store the data into SQLite:
SaveDataToSQLite(indexRates);

### **3. Query Data**
Query the SQLite database:
QueryIndexRate("specific-IndexNo");

Customize the queries to fit your requirements.

### **4. Extend the Project**
Add additional features such as periodic data updates or AI chatbot integration to query and analyze your data.
