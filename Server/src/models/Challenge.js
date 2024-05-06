const mongoose = require('mongoose');

const Challenge = mongoose.model('Challenge', {
    tempoProva: timerProva,
    DiaProva: { type: Date, default: Date.now }
})

module.exports = Challenge;