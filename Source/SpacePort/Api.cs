using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using SpacePort.DataModels;

namespace SpacePort
{
    class Api
    {
        public async Task<bool> ValidateName(string name)
        {
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest("people/", DataFormat.Json);

            var peopleResponse =  client.GetAsync<PersonsResponse>(request);

            peopleResponse.Result.Next = "INTE NULL";
            
            int i = 2;
            while (peopleResponse.Result.Next != null)
            {
                foreach (var p in peopleResponse.Result.Results)
                {
                    if (p.Name.ToLower() == name.ToLower())
                    {
                        return true;
                    }
                }
                request = new RestRequest("people/?page=" + i);
                peopleResponse = client.GetAsync<PersonsResponse>(request);
                i++;
            }
            return false;
        }
    }
}
