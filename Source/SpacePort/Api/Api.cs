using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using SpacePort.DataModels;

namespace SpacePort
{
    public static class Api
    {
        public static async Task<bool> ValidateName(string name)
        {
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest("people/", DataFormat.Json);

            var peopleResponse = await client.GetAsync<PersonsResponse>(request);

            peopleResponse.Next = "INTE NULL";
            
            int i = 2;
            while (peopleResponse.Next != null)
            {
                foreach (var p in peopleResponse.Results)
                {
                    if (p.Name.ToLower() == name.ToLower())
                    {
                        return true;
                    }
                }
                request = new RestRequest("people/?page=" + i);
                peopleResponse = await client.GetAsync<PersonsResponse>(request);
                i++;
            }
            return false;
        }
        public static async Task<List<Starship>> GetStarShips()
        {
            List<Starship> starships = new List<Starship>();
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest("starships/", DataFormat.Json);

            var starshipResponse = await client.GetAsync<Starships>(request);

            starshipResponse.Next = "INTE NULL";

            int i = 2;
            while (starshipResponse.Next != null)
            {
                foreach (var p in starshipResponse.Results)
                {
                    starships.Add(p);
                }
                request = new RestRequest("starships/?page=" + i);
                starshipResponse = await client.GetAsync<Starships>(request);
                i++;
            }
            return starships;
        }


    }
}
