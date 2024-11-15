const express = require('express');
var bodyParser = require('body-parser');

const app = express();
const travelRoutes = require('./routes/travelRoutes');

app.use(bodyParser.json());
app.use(bodyParser.urlencoded());

app.use(bodyParser.urlencoded({ extended: true }));

app.set('view engine', 'ejs');
app.use('/', travelRoutes);

app.listen(3000, () => {
    console.log('Server is running on port 3000');
});
