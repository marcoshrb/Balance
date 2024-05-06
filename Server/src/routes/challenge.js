const express = require('express');
const ChallengeController = require('../controller/Challenge');
const router = express.Router();

const ProvaValues = [{}]

router
    .get('/challenge', ChallengeController.getAllPeople)
    .get('/challenge/:id', ChallengeController.getById)
    .post('/challenge', ChallengeController.create)
    .patch('/challenge/:id', ChallengeController.updateById)
    .delete('/challenge/:id', ChallengeController.deleteById)

module.exports = router;