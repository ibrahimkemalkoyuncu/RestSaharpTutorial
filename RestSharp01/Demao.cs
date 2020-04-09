using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestSharp01
{
    public class Demao
    {
        public ListOfUsersDTO GetUsers()
        {
            var restClient = new RestClient("https://reqres.in"); // base Url
            
            var restRequest = new RestRequest("/api/users?page=2",Method.GET); // Endpoint

            restRequest.AddHeader("Accept","application/json");
            restRequest.RequestFormat = DataFormat.Json;


            IRestResponse response = restClient.Execute(restRequest);
            var content = response.Content;


            var users = JsonConvert.DeserializeObject<ListOfUsersDTO>(content);



            return users;
        }
    }
}
