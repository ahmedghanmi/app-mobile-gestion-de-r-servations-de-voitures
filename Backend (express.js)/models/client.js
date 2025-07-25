const db = require('../config/db');

module.exports = {
    // Récupère un client par son ID
    getById: async (id) => {
        const query = 'SELECT * FROM clients WHERE id = ?';
        return db.promise().query(query, [id]);
    },

    // Récupère tous les clients
    getAll: () => {
        return db.promise().query('SELECT * FROM clients');
    },

    // Crée un nouveau client
    create: (client) => {
        return db.promise().query('INSERT INTO clients SET ?', client);
    },

    // Modifie un client existant
    update: (id, client) => {
        return db.promise().query('UPDATE clients SET ? WHERE id = ?', [client, id]);
    },

    // Supprime un client
    delete: (id) => {
        return db.promise().query('DELETE FROM clients WHERE id = ?', [id]);
    }
};
