const express = require('express');
const router = express.Router();

let tempoProva = "";
let ProvaLiberada = false;
let f1 = 0;
let f2 = 0;
let f3 = 0;
let f4 = 0;
let f5 = 0;

router
    .get('/', (req, res) => {
        res.json({ 
            tempoProva, 
            ProvaLiberada,
            f1,
            f2,
            f3,
            f4,
            f5
        });
    })
    .post('/', (req, res) => {
        const {
            tempo_Prova, 
            prova_Liberada,
            f1_,
            f2_,
            f3_,
            f4_,
            f5_
        } = req.body;

        tempoProva = tempo_Prova;
        ProvaLiberada = prova_Liberada;
        f1 = f1_;
        f2 = f2_;
        f3 = f3_;
        f4 = f4_;
        f5 = f5_;
        res.send('Estado da prova atualizado!');
    })

module.exports = router;