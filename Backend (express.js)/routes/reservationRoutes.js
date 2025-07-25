// routes/reservationRoutes.js
const express = require('express');
const router = express.Router();
const reservationController = require('../controllers/reservationController');

// Liste toutes les réservations
router.get('/', reservationController.list);
// Liste les réservations pour une voiture spécifique
router.get('/voiture/:voitureId', reservationController.getByVoiture);
// Liste les réservations pour un client spécifique
router.get('/client/:clientId', reservationController.getByClient);
// Liste les réservations par id
router.get('/:id', reservationController.getById);
// Crée une nouvelle réservation
router.post('/', reservationController.create);
// Modifie une réservation existante
router.put('/:id', reservationController.update);
// Supprime une réservation
router.delete('/:id', reservationController.delete);

module.exports = router;
