using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using car_management_app.Models;

namespace car_management_app.Services
{
    public class ReservationService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private const string BaseUrl = "http://192.168.1.19:3000/";

        public async Task<List<Reservation>> GetAllReservationsAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"{BaseUrl}reservations");
                return JsonConvert.DeserializeObject<List<Reservation>>(response);
            }
            catch
            {
                return new List<Reservation>();
            }
        }

        public async Task<List<Voiture>> GetAllVoituresAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"{BaseUrl}voitures");
                return JsonConvert.DeserializeObject<List<Voiture>>(response);
            }
            catch
            {
                return new List<Voiture>();
            }
        }

        public async Task<List<Client>> GetAllClientsAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"{BaseUrl}clients");
                return JsonConvert.DeserializeObject<List<Client>>(response);
            }
            catch
            {
                return new List<Client>();
            }
        }

        public async Task<bool> CreateReservationAsync(Reservation reservation)
        {
            try
            {
                var json = JsonConvert.SerializeObject(reservation);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                Console.WriteLine($"Données envoyées : {json}");

                var response = await _httpClient.PostAsync($"{BaseUrl}reservations", content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Réservation ajoutée avec succès.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Erreur lors de l'ajout de la réservation. Code de statut : {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateReservationAsync(Reservation reservation)
        {
            try
            {
                var json = JsonConvert.SerializeObject(reservation);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"{BaseUrl}reservations/{reservation.Id}", content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la mise à jour : {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteReservationAsync(int reservationId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{BaseUrl}reservations/{reservationId}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
                return false;
            }
        }
        public async Task<Reservation> GetReservationByIdAsync(int reservationId)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"{BaseUrl}reservations/{reservationId}");
                return JsonConvert.DeserializeObject<Reservation>(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
                return null;
            }
        }


        public async Task<List<Reservation>> GetReservationsByVoitureAsync(int voitureId)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"{BaseUrl}reservations/voiture/{voitureId}");
                return JsonConvert.DeserializeObject<List<Reservation>>(response);
            }
            catch
            {
                return new List<Reservation>();
            }
        }

        public async Task<List<Reservation>> GetReservationsByClientAsync(int clientId)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"{BaseUrl}reservations/client/{clientId}");
                return JsonConvert.DeserializeObject<List<Reservation>>(response);
            }
            catch
            {
                return new List<Reservation>();
            }
        }


    }
}
