
using RestfulApi.Tests.Clients;
using RestfulApi.Tests.Models;
using System.Text.Json;

namespace RestfulApi.Tests
{

    public class RestAPITests
    {
        private readonly APIClient _client;
        private readonly ConfigData _config;
        
        //static variable to share the ID across all the test methods
        private static string? _addedId;

        public RestAPITests()
        {
            //creating the path using base directory
            string filePath = Path.Combine(AppContext.BaseDirectory,"Config","ConfigData.json");

            //Check if file exists before read
            if (File.Exists(filePath))
            {
                //Reading Config data json as texts
                string jsonText = File.ReadAllText(filePath);

                //converting the json string in to C# object
                _config = JsonSerializer.Deserialize<ConfigData>(jsonText)!;
            }
            else
            {
                throw new FileNotFoundException($"Could not find the config file at: {filePath}");
            }
            _client = new APIClient(_config.AppSetting.BaseURL!);

        }

        [Fact]
        public async Task Test1_GetAllObjects_ShouldReturnList()
        {
            var result = await _client.GetAllObjects();

            //Verify the object list contains data
            Assert.NotNull(result);
            Assert.True(result.Count > 0,"Should return at least one object");

        }

        [Fact]
        public async Task Test2_AddAnObject_ShouldReturnNewId()
        {
            var data = new ObjectData
            {
                Name = _config.PostTestData.Name,
                Data = new Dictionary<string, object>
                { { "Price" , _config.PostTestData.Price!} }
            };
            var result = await _client.CreateNewObject(data);

            //Store the ID globally
            _addedId = result.Id;

            //Response will contains "CreatedAt" only when new object added
            Assert.NotNull(result.CreatedAt); 

            //Validate the data accuracy
            Assert.Equal(_config.PostTestData.Name, result.Name);
            Assert.Equal(_config.PostTestData.Price, result.Data?["Price"].ToString());

        }

        [Fact]
        public async Task Test3_GetObjectById_ShouldReturnObject()
        {
             var result =  await _client.GetObjectById(_addedId);

            //Validate the data accuracy
            Assert.Equal(_addedId, result.Id);
            Assert.Equal(_config.PostTestData.Name, result.Name);
            Assert.Equal(_config.PostTestData.Price, result.Data?["Price"].ToString());

        }

        [Fact]
        public async Task Test4_UpdateObjectById_ShouldReturnUpdatedAt()
        {
            var data = new ObjectData
            {
                Name = _config.PutTestData.Name,
                Data = new Dictionary<string, object>
                {{"Price", _config.PutTestData.Price! }}
            };
            var result = await _client.UpdateById(_addedId!, data);

            //Response will contains "UpdatedAt" only when an existing object updated
            Assert.NotNull(result.UpdatedAt); 
            Assert.Equal(_config.PutTestData.Name, result.Name);
            Assert.Equal(_config.PutTestData.Price, result.Data?["Price"].ToString());
        }

        [Fact]
        public async Task Test5_DeleteObjectById_ShouldReturnMessage()
        {
            var result = await _client.DeleteById(_addedId);
            Assert.NotNull(result.Message);

            //Validate content of the confirmation message
            Assert.Contains($"id = {_addedId}", result.Message);
            Assert.Contains("deleted", result.Message.ToLower());

        }

        [Fact]
        public async Task Test6_VerifyDeletedObject_ShouldBeNull() //Negetive test to confirm the deletion
        {
            var result = await _client.GetObjectById(_addedId!);

            //Validate the unavailability of deleted object
            Assert.Null(result);
        }
    }
}



