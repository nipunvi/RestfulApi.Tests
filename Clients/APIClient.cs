using RestfulApi.Tests.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace RestfulApi.Tests.Clients
{
    internal class APIClient(string basURL)
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task <List<ObjectData>> GetAllObjects()
        {
            //returning all available objects
            return await _httpClient.GetFromJsonAsync<List<ObjectData>>(basURL);
        }

        public async Task <ObjectData> CreateNewObject(ObjectData data)
        {
            //return response after Adding a new object to the list
            var response = await _httpClient.PostAsJsonAsync(basURL, data);
            return await response.Content.ReadFromJsonAsync<ObjectData>();
           
        }

        public async Task <ObjectData> GetObjectById(string id)
        {
            //return an spesific object by its Id
            return await _httpClient.GetFromJsonAsync<ObjectData>($"{basURL}/{id}");
        }

        public async Task <ObjectData> UpdateById(string id,ObjectData newObject)
        {
            //update an spesific object as a whole by its Id
            var response = await _httpClient.PutAsJsonAsync($"{basURL}/{id}", newObject);
            return await response.Content.ReadFromJsonAsync<ObjectData>();
        }

        public async Task<DeleteResponse> DeleteById(string id)
        {
            //delete an existing data and retrun the response
            var response = await _httpClient.DeleteAsync($"{basURL}/{id}");
            return await response.Content.ReadFromJsonAsync<DeleteResponse>();
        }

    }
}
