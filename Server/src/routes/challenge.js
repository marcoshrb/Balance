const express = require('express');
const router = express.Router();

let tempoProva = 30;
let ProvaLiberada = false;
let f1 = 2;
let f2 = 3;
let f3 = 5;
let f4 = 8;
let f5 = 10;

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

    .post('/values', (req, res) => {
        const {
            f1_,
            f2_,
            f3_,
            f4_,
            f5_
        } = req.body;

        f1 = f1_;
        f2 = f2_;
        f3 = f3_;
        f4 = f4_;
        f5 = f5_;
        res.send('Valores atualizados!');
    })

    .post('/begin', (req, res) => {
        const {
            tempo_Prova,
        } = req.body;

        tempoProva = tempo_Prova;
        ProvaLiberada = true;
        res.send('Valores atualizados!');
    })

    .post('/end', (req, res) => {
        ProvaLiberada = false;
        res.send('Valores atualizados!');
    })

module.exports = router;