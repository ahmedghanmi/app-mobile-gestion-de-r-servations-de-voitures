const db = require('../config/db');

module.exports = {
    getById: async (id) => {
        const query = 'SELECT * FROM voitures WHERE id = ?';
        return db.execute(query, [id]);
    },
    getAll: () => {
        return db.promise().query('SELECT * FROM voitures');
    },
    getById: (id) => {
        return db.promise().query('SELECT * FROM voitures WHERE id = ?', [id]);
    },
    create: (voiture) => {
        return db.promise().query('INSERT INTO voitures SET ?', voiture);
    },
    update: (id, voiture) => {
        return db.promise().query('UPDATE voitures SET ? WHERE id = ?', [voiture, id]);
    },
    delete: (id) => {
        return db.promise().query('DELETE FROM voitures WHERE id = ?', [id]);
    }
};
