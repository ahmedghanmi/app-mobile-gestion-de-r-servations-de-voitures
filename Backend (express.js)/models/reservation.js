const db = require('../config/db'); 

module.exports = {
    // Récupère toutes les réservations avec des détails limités des voitures et des clients
    getAll: () => {
        const query = `
            SELECT 
                r.id AS reservation_id, 
                r.date_debut, 
                r.date_fin, 
                v.marque AS voiture_marque, 
                v.modele AS voiture_modele, 
                c.nom AS client_nom, 
                c.prenom AS client_prenom 
            FROM reservations r 
            JOIN voitures v ON r.voiture_id = v.id 
            JOIN clients c ON r.client_id = c.id;
        `;
        return db.promise().query(query);
    },

    // Récupère une réservation par son ID avec des détails limités
    getById: async (id) => {
        const query = `
            SELECT 
                r.id AS reservation_id, 
                r.date_debut, 
                r.date_fin, 
                v.marque AS voiture_marque, 
                v.modele AS voiture_modele, 
                c.nom AS client_nom, 
                c.prenom AS client_prenom 
            FROM reservations r 
            JOIN voitures v ON r.voiture_id = v.id 
            JOIN clients c ON r.client_id = c.id 
            WHERE r.id = ?;
        `;
        return db.promise().query(query, [id]);
    },

    // Crée une nouvelle réservation
    create: (reservation) => {
        const query = 'INSERT INTO reservations (voiture_id, client_id, date_debut, date_fin) VALUES (?, ?, ?, ?)';
        return db.promise().query(query, [reservation.voiture_id, reservation.client_id, reservation.date_debut, reservation.date_fin]);
    },

    update: (id, reservation) => {
        return db.promise().query('UPDATE reservations SET ? WHERE id = ?', [reservation, id]);
    },
    


    // Supprime une réservation
    delete: (id) => {
        const query = 'DELETE FROM reservations WHERE id = ?';
        return db.promise().query(query, [id]);
    },

    // Récupère les réservations associées à une voiture spécifique avec des détails limités
    getByVoiture: (voitureId) => {
        const query = `
            SELECT 
                r.id AS reservation_id, 
                r.date_debut, 
                r.date_fin, 
                c.nom AS client_nom, 
                c.prenom AS client_prenom 
            FROM reservations r 
            JOIN clients c ON r.client_id = c.id 
            WHERE r.voiture_id = ?;
        `;
        return db.promise().query(query, [voitureId]);
    },

    // Récupère les réservations associées à un client spécifique avec des détails limités
    getByClient: (clientId) => {
        const query = `
            SELECT 
                r.id AS reservation_id, 
                r.date_debut, 
                r.date_fin, 
                v.marque AS voiture_marque, 
                v.modele AS voiture_modele 
            FROM reservations r 
            JOIN voitures v ON r.voiture_id = v.id 
            WHERE r.client_id = ?;
        `;
        return db.promise().query(query, [clientId]);
    }
};
