using Newtonsoft.Json;
using System;

namespace car_management_app.Models
{
    public class Client
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Telephone")]
        public string Telephone { get; set; }

        [JsonProperty("nom")]
        public string Nom { get; set; }

        [JsonProperty("prenom")]
        public string Prenom { get; set; }
    }
}