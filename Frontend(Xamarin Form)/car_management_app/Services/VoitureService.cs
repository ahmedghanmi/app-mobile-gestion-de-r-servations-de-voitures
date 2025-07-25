using car_management_app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace car_management_app.Services
{
    public class VoitureService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private const string BaseUrl = "http://192.168.1.19:3000/voitures"; 

        public async Task<List<Voiture>> GetAllVoituresAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync(BaseUrl);
                if (!string.IsNullOrEmpty(response))
                {
                    return JsonConvert.DeserializeObject<List<Voiture>>(response);
                }
                return new List<Voiture>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération des voitures : {ex.Message}");
                return new List<Voiture>();
            }
        }
    

    public async Task<Voiture> GetVoitureByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"{BaseUrl}/{id}");
                return JsonConvert.DeserializeObject<Voiture>(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> AjouterVoitureAsync(Voiture voiture)
        {
            try
            {
                var json = JsonConvert.SerializeObject(voiture);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(BaseUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Erreur API: {errorMessage}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> ModifierVoitureAsync(int id, Voiture voiture)
        {
            try
            {
                var json = JsonConvert.SerializeObject(voiture);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"{BaseUrl}/{id}", content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
                return false;
            }
        }

        public async Task<bool> SupprimerVoitureAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
                return false;
            }
        }

        
    }
}