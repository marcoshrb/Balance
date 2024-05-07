const express = require('express');
const router = express.Router();

let tempoProva = "";
let ProvaLiberada = false;

router
    .get('/', (req, res) => {
        res.json({ 
            tempoProva, 
            ProvaLiberada
        });
    })
    .post('/', (req, res) => {
        const {tempo_Prova, prova_Liberada} = req.body;
        tempoProva = tempo_Prova;
        ProvaLiberada = prova_Liberada;
        res.send('Estado da prova atualizado!');
    })

module.exports = router;