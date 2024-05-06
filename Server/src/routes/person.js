const express = require('express');
const router = express.Router();

// router
//     .get('/api/person/first', (req, res) => {
//         console.log("Hello in console");
//         return
//     })

// router
//     .get('/api/person/first', (req, res) => {
//         console.log(8 + 5);
//         return
//     })

// router.get('/:numero?', (req, res) => { // "?" serve para o dado ser opcional
//     const { numero } = req.params
//     res.send(`Número recebido: ${numero}`);
//     });

// router
//     .get('/:numero?', (req, res) => { // "?" serve para o dado ser opcional
//         const { numero } = req.query
//         res.send(`Número recebido: ${numero}`); //http://localhost:8080/?numero=25
//     });

// const people = [{}];

// router
//     .post('/api/person', (req, res) => {
//         console.log(req.body);
//         return;
//     });

const people = [];

router
    .post('/api/person', (req, res) => {
        const { name, lastname, salary } = req.body;

        const person = {
            id: people.length,
            name: name,
            lastname: lastname,
            salary: salary
        }

        if (!name || !lastname || !salary)
            return res.status(400).send({ message: "Dados inválidos" })

        people.push(person);
        return res.status(201).send({ message: "Pessoa inserida com sucesso" });
    })

router
    .get('/api/person', (req, res) => {
        return res.status(200).send({ data: people });
    })

module.exports = router