const db = require('../config/db');

module.exports = {
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
