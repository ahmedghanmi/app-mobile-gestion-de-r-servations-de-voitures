// controllers/reservationController.js
const reservationModel = require('../models/reservation');

module.exports = {
    // Liste toutes les réservations
    list: async (req, res) => {
        try {
            const [rows] = await reservationModel.getAll();
            res.json(rows);
        } catch (error) {
            res.status(500).json({ error: 'Erreur lors de la récupération des réservations' });
        }
    },
    // Récupère une réservation par son ID
getById: async (req, res) => {
    const { id } = req.params; 
    try {
        const [rows] = await reservationModel.getById(id); 
        if (rows.length === 0) {
            return res.status(404).json({ error: `Aucune réservation trouvée pour l'ID ${id}` });
        }
        res.json(rows[0]); 
    } catch (error) {
        console.error(`Erreur lors de la récupération de la réservation ${id}:`, error);
        res.status(500).json({ error: 'Erreur lors de la récupération de la réservation' });
    }
},
    // Liste les réservations pour une voiture spécifique
    getByVoiture: async (req, res) => {
        const voitureId = req.params.voitureId;
        try {
            const [rows] = await reservationModel.getByVoiture(voitureId);
            res.json(rows);
        } catch (error) {
            res.status(500).json({ error: `Erreur lors de la récupération des réservations pour la voiture ${voitureId}` });
        }
    },
    // Liste les réservations pour un client spécifique
    getByClient: async (req, res) => {
        const clientId = req.params.clientId;
        try {
            const [rows] = await reservationModel.getByClient(clientId);
            res.json(rows);
        } catch (error) {
            res.status(500).json({ error: `Erreur lors de la récupération des réservations pour le client ${clientId}` });
        }
    },
    // Crée une nouvelle réservation
    create: async (req, res) => {
        const { voiture_id, client_id, date_debut, date_fin } = req.body;
    
        console.log('Données reçues:', req.body); 
    
        try {
            
            if (!voiture_id || !client_id || !date_debut || !date_fin) {
                return res.status(400).json({ error: 'Les données requises sont manquantes' });
            }
    
            const reservation = { voiture_id, client_id, date_debut, date_fin };
            await reservationModel.create(reservation);
    
            res.status(201).json({ message: 'Réservation ajoutée avec succès' });
        } catch (error) {
            console.error('Erreur lors de l\'ajout de la réservation:', error); 
            res.status(500).json({ error: 'Erreur lors de l\'ajout de la réservation' });
        }
    },
    update: async (req, res) => {
        const { id } = req.params;
        const { voiture_id, client_id, date_debut, date_fin } = req.body;
    
        try {
           
            const reservation = { voiture_id, client_id, date_debut, date_fin };
            
           
            await reservationModel.update(id, reservation);
            
            res.status(200).json({ message: 'Réservation modifiée avec succès' });
        } catch (error) {
            console.error('Erreur dans le contrôleur :', error);
            res.status(500).json({ error: 'Erreur lors de la modification de la réservation' });
        }
    },    
    
    // Supprime une réservation
    delete: async (req, res) => {
        const { id } = req.params;
        try {
            await reservationModel.delete(id);
            res.status(200).json({ message: 'Réservation supprimée avec succès' });
        } catch (error) {
            res.status(500).json({ error: 'Erreur lors de la suppression de la réservation' });
        }
    }
};
