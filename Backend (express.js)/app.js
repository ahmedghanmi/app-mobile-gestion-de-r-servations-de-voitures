const express = require('express');
const app = express();
const voitureRoutes = require('./routes/voitureRoutes');
const clientRoutes = require('./routes/clientRoutes');
const reservationRoutes = require('./routes/reservationRoutes');  // Importation de la route des réservations
const cors = require('cors');

app.use(cors());

// Utilisation de express.json() pour analyser les données JSON dans les requêtes
app.use(express.json());

// Routes
app.use('/voitures', voitureRoutes);
app.use('/clients', clientRoutes);
app.use('/reservations', reservationRoutes);

const port = 3000;
app.listen(port, () => {
    console.log(`Server is running on port ${port}`);
});
