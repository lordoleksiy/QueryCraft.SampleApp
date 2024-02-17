# QueryCraft Demo Application

## Overview

Explore the capabilities of QueryCraft with our Demo Application - a showcase designed to demonstrate the seamless integration of dynamic JSON-based filtering into LINQ queries in C# web applications. QueryCraft simplifies complex filtering logic, allowing you to express intricate criteria in a clear and flexible JSON format.

## Features

- **Expressive Filtering:** Craft detailed filter conditions using intuitive JSON structures.
  
- **Dynamic Query Building:** Experience dynamic LINQ expression construction, adapting queries to changing criteria at runtime.

- **Operator Rich:** QueryCraft supports a range of operators, enabling diverse filtering conditions, from basic equality checks to advanced operations.

# Getting Started with QueryCraft

To get started with QueryCraft, install the NuGet package in your C# project. To do this you can find it on nuget or using the following command:

```bash
dotnet add package QueryCraft
```
Then register it using di:
```csharp
builder.Services.RegisterQueryCraft(opt =>
{
    // you can add here your custom configs
});
```
Now, you can use it in your controllers or services:
```csharp
using Microsoft.AspNetCore.Mvc;
using QueryCraft.Interfaces;
using QueryCraft.SampleApp.Data;
using QueryCraft.SampleApp.Models;

namespace QueryCraft.SampleApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        public QueryCraftContext _dbContext;
        private IParser _parser;

        public ProductController(QueryCraftContext dbContext, IParser parser)
        {
            _parser = parser;
            _dbContext = dbContext;
        }

        [HttpPost(Name = "GetProducts")]
        public IActionResult Get(Dictionary<string, object> model)
        {
            try
            {
                var operand = _parser.Parse(model, typeof(Product));
                return Ok(_dbContext.Products.Where(operand.GetPredicate<Product>()));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

```
# Running the Project
## To run the QueryCraft Demo Application:
1) Clone the repository to your local machine.
2) Open the project in your preferred IDE (such as Visual Studio or Visual Studio Code).
3) Run the following commad in Package Manager Console to migrate database:
```bash
update-database
```
4) Build and run the application.
5) Access the ProductController endpoint, for example: https://localhost:5001/Product/GetProducts (adjust the port number based on your configuration).
6) Experiment with dynamic filtering and observe the QueryCraft library in action.


Now, you're ready to leverage QueryCraft's powerful features for dynamic filtering in your C# web applications!
