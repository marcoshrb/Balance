const express = require('express');
const router = express.Router();

let examState = {
    time: "",
    isReleased: false,
    w1: 0,
    w2: 0,
    w3: 0,
    w4: 0,
    w5: 0
};

router.get('/', (req, res) => {
    json = {
        time: examState.time,
        isReleased: examState.isReleased,
        wheights: [examState.w1, examState.w2, examState.w3, examState.w4, examState.w5].sort()
    }
    res.status(200).json(examState);
});

router.post('/', (req, res) => {
    const {
        examTime,
        examReleased,
        w1,
        w2,
        w3,
        w4,
        w5
    } = req.body;

    examState.examTime = examTime;
    examState.examReleased = examReleased;
    examState.w1 = w1;
    examState.w2 = w2;
    examState.w3 = w3;
    examState.w4 = w4;
    examState.w5 = w5;

    res.status(200).send('Estado da prova atualizado!');
});

module.exports = router;
