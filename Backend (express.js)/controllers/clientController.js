const clientModel = require('../models/client');

module.exports = {
    // Liste tous les clients
    list: async (req, res) => {
        try {
            const [rows] = await clientModel.getAll();
            res.json(rows);
        } catch (error) {
            console.error("Erreur détectée :", error);
            res.status(500).json({ error: "Erreur interne" });
        }
    },

    // Récupère un client par son ID
    getById: async (req, res) => {
        const clientId = req.params.id;
        try {
            const [rows] = await clientModel.getById(clientId);
            if (rows.length === 0) {
                return res.status(404).json({ error: 'Client non trouvé' });
            }
            res.json(rows[0]);
        } catch (error) {
            console.error("Erreur détectée :", error);
            res.status(500).json({ error: "Erreur lors de la récupération du client" });
        }
    },

    // Ajoute un nouveau client
    create: async (req, res) => {
        try {
            const client = req.body;
            await clientModel.create(client);
            res.status(201).json({ message: 'Client ajouté avec succès' });
        } catch (error) {
            res.status(500).json({ error: 'Erreur lors de l\'ajout du client' });
        }
    },

    // Modification d'un client
    update: async (req, res) => {
        const clientId = req.params.id;  
        const clientData = req.body;     
        try {
            const [result] = await clientModel.update(clientId, clientData);

            if (result.affectedRows > 0) {
                res.json({ message: 'Client modifié avec succès' });
            } else {
                res.status(404).json({ error: 'Client non trouvé' });
            }
        } catch (error) {
            res.status(500).json({ error: 'Erreur lors de la modification du client' });
        }
    },

    // Supprime un client
    delete: async (req, res) => {
        const clientId = req.params.id;  // Récupère l'ID du client à supprimer

        try {
            const [result] = await clientModel.delete(clientId);

            if (result.affectedRows > 0) {
                res.json({ message: 'Client supprimé avec succès' });
            } else {
                res.status(404).json({ error: 'Client non trouvé' });
            }
        } catch (error) {
            res.status(500).json({ error: 'Erreur lors de la suppression du client' });
        }
    },
};
