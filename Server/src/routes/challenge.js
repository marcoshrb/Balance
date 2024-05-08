const express = require('express');
const router = express.Router();

let tempoProva = "30";
let ProvaLiberada = false;
let f1 = 10;
let f2 = 20;
let f3 = 30;
let f4 = 40;
let f5 = 50;

router
    .get('/', (req, res) => {
        try {
            console.log(tempoProva, 
                ProvaLiberada,
                f1,
                f2,
                f3,
                f4,
                f5)
            return res.json({ 
                tempoProva, 
                ProvaLiberada,
                f1,
                f2,
                f3,
                f4,
                f5
            });
        } catch (err) {
            console.error("Erro ao processar requisição GET:", err);
            res.status(500).send("Erro interno ao processar requisição GET.");
        }
    })
    .post('/', (req, res) => {
        try {
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
        } catch (err) {
            console.error("Erro ao processar requisição POST:", err);
            res.status(500).send("Erro interno ao processar requisição POST.");
        }
    });

module.exports = router;
