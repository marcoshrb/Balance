const bodyParser = require('body-parser');
const person = require('./person.js');

module.exports = (app) => {
    app.use(
        bodyParser.json(),
        person
    )
}