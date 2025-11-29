using Newtonsoft.Json;

namespace car_management_app.Models
{
    public class Reservation
    {
    [JsonProperty("reservation_id")]
    public int Id { get; set; }

    [JsonProperty("date_debut")]
    public string DateDebut { get; set; }

    [JsonProperty("date_fin")]
    public string DateFin { get; set; }

    [JsonProperty("voiture_marque")]
    public string VoitureMarque { get; set; }

    [JsonProperty("voiture_modele")]
    public string VoitureModele { get; set; }

    [JsonProperty("client_nom")]
    public string ClientNom { get; set; }

    [JsonProperty("client_prenom")]
    public string ClientPrenom { get; set; }

    [JsonProperty("voiture_id")]
    public int VoitureId { get; set; }

    [JsonProperty("client_id")]
    public int ClientId { get; set; }
    }
}
