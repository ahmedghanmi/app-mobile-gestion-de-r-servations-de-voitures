using Newtonsoft.Json;
using System;

namespace car_management_app.Models
{
    public class Voiture
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("marque")]
        public string Marque { get; set; }

        [JsonProperty("modele")]
        public string Modele { get; set; }

        [JsonProperty("annee")]
        public int Annee { get; set; }

        [JsonProperty("prix")]
        public decimal Prix { get; set; }

       
    }
}