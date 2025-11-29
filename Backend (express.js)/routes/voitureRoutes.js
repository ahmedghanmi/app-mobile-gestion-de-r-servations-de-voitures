const express = require('express');
const voitureController = require('../controllers/voitureController');
const router = express.Router();

router.get('/', voitureController.list);
router.get('/:id', voitureController.getById);
router.post('/', voitureController.create);
router.put('/:id', voitureController.update);
router.delete('/:id', voitureController.delete);


module.exports = router;
