const voitureModel = require('../models/voiture');

module.exports = {
    list: async (req, res) => {
        try {
            const [rows] = await voitureModel.getAll();
            res.json(rows);
        } catch (error) {
            console.error("Erreur détectée :", error);
            res.status(500).json({ error: "Erreur interne" });
        }
    },
    
    // Récupère une voiture par son ID
    getById: async (req, res) => {
        const voitureId = req.params.id;
        try {
            const [rows] = await voitureModel.getById(voitureId);
            if (rows.length === 0) {
                return res.status(404).json({ error: 'Voiture non trouvée' });
            }
            res.json(rows[0]);
        } catch (error) {
            console.error("Erreur détectée :", error);
            res.status(500).json({ error: "Erreur lors de la récupération de la voiture" });
        }
    },
    
    create: async (req, res) => {
        try {
            const voiture = req.body;
            await voitureModel.create(voiture);
            res.status(201).json({ message: 'Voiture ajoutée avec succès' });
        } catch (error) {
            res.status(500).json({ error: 'Erreur lors de l\'ajout de la voiture' });
        }
    },
    // Modification d'une voiture
    update: async (req, res) => {
        const voitureId = req.params.id; 
        const voitureData = req.body;    

        try {
            const [result] = await voitureModel.update(voitureId, voitureData);

            if (result.affectedRows > 0) {
                res.json({ message: 'Voiture modifiée avec succès' });
            } else {
                res.status(404).json({ error: 'Voiture non trouvée' });
            }
        } catch (error) {
            res.status(500).json({ error: 'Erreur lors de la modification de la voiture' });
        }
    },

    
    delete: async (req, res) => {
        const voitureId = req.params.id;  

        try {
            const [result] = await voitureModel.delete(voitureId);

            if (result.affectedRows > 0) {
                res.json({ message: 'Voiture supprimée avec succès' });
            } else {
                res.status(404).json({ error: 'Voiture non trouvée' });
            }
        } catch (error) {
            res.status(500).json({ error: 'Erreur lors de la suppression de la voiture' });
        }
    },
};

