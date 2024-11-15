const express = require('express');
const router = express.Router();
const travelController = require('../controllers/travelController');

router.get('/', travelController.getTravels);
router.get('/item/:id', travelController.getTravel);
router.get('/privacy', travelController.getPrivacy);
router.get('/about', travelController.getAbout);
router.post('/create', travelController.createTravel);

module.exports = router;
