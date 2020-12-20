using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using RestaurantsRecommendation.Models;
using RestSharp;

namespace RestaurantsRecommendation
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        List<Restaurant> restaurants = new List<Restaurant>();
        List<string> restaurantNames = new List<string>();
        Dictionary<string, string> restaurantsDictionary = new Dictionary<string, string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            loadRestaurants();
        }
        List<Restaurant> loadRestaurants ()
        {
            using (StreamReader sr = new StreamReader(Server.MapPath("restaurantes.json")))
            {
                restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(sr.ReadToEnd());
            }
            restaurantNames = MapRestaurantNames();
            foreach (var item in restaurants)
            {
                restaurantsDictionary.Add(item.ID, item.Name);
            }
            RestauranID.DataTextField = "Value";
            RestauranID.DataValueField = "Key";
            RestauranID.DataSource = restaurantsDictionary;
            RestauranID.DataBind();
            return restaurants;
        }
        protected List<string> MapRecommendationResults (string modelResult)
        {
            Root rawRecommendations = new Root();
            rawRecommendations = JsonConvert.DeserializeObject<Root>(modelResult);
            List<string> mappedRecommendations = rawRecommendations.Results.output1.value.Values.SelectMany(x => x).ToList();
            List<string> recommendations = restaurants.Where(x => mappedRecommendations.Contains(x.ID)).Select(v => v.Name).ToList();
            return recommendations;
        }
        protected List<string> MapRestaurantNames()
        {
            List<string> restaurantNames = restaurants.Select(v => v.Name).ToList();
            return restaurantNames;
        }
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Clear();
            var client = new RestClient("https://ussouthcentral.services.azureml.net/workspaces/bb8a08c8c38f416aa3a883951de0ff4f/services/d0924fd4b0434428be9ca81b23a815af/execute?api-version=2.0&details=true");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer lfnl7CdyI6C+d2FZv/G9RxlP1as3YTa6RLJCygYKX+A1kkF9FpN2Xs2w7ypscAtCpMbSlBTCfuHBsRFmfS0i0g==");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\r\n  \"Inputs\": {\r\n    \"input1\": {\r\n      \"ColumnNames\": [\r\n        \"Iduser\",\r\n        \"Rating\",\r\n        \"RestauranID\",\r\n        \"date\"\r\n      ],\r\n      \"Values\": [\r\n        [\r\n          \"" + Iduser.Value + "\",\r\n          \""+ Rating.Value +"\",\r\n          \"" + RestauranID.SelectedValue + "\",\r\n          \"" + date.Value + "\"\r\n        ]\r\n      ]\r\n    }\r\n  },\r\n  \"GlobalParameters\": {}\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            List<string> results = MapRecommendationResults(response.Content.ToString());
            foreach (var item in results)
            {
                ListBox1.Items.Add(item);
            }
          
        }
    }
}