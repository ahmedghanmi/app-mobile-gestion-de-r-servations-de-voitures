using car_management_app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace car_management_app.Services
{
    public class ClientService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private const string BaseUrl = "http://192.168.1.19:3000/clients";  

        public async Task<List<Client>> GetAllClientsAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync(BaseUrl);
                if (!string.IsNullOrEmpty(response))
                {
                    return JsonConvert.DeserializeObject<List<Client>>(response);
                }
                return new List<Client>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération des clients : {ex.Message}");
                return new List<Client>();
            }
        }
    

    // Méthode GET : Récupérer un client par ID
    public async Task<Client> GetClientByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"{BaseUrl}/{id}");
                return JsonConvert.DeserializeObject<Client>(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur: {ex.Message}");
                return null;
            }
        }

        // Méthode POST : Ajouter un client
        public async Task<bool> AjouterClientAsync(Client client)
        {
            try
            {
                var json = JsonConvert.SerializeObject(client);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(BaseUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                Console.WriteLine($"Erreur serveur : {response.StatusCode} - {response.ReasonPhrase}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'ajout du client : {ex.Message}");
                return false;
            }
        }

        // Méthode PUT : Modifier un client
        public async Task<bool> ModifierClientAsync(int id, Client client)
        {
            try
            {
                var json = JsonConvert.SerializeObject(client);
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

        // Méthode DELETE : Supprimer un client
        public async Task<bool> SupprimerClientAsync(int id)
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
