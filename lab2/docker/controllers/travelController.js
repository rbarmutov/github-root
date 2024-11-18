const TravelModel = require('../models/travelModel');

exports.getTravels = (req, res) => {
    const travels = TravelModel.getAllTravels();
    res.render('travelListView', { travels });
};

exports.getTravel = (req, res) => {
    const travels = TravelModel.getAllTravels();
    const id = req.params['id'];
    const travel = travels.find(x => x.id == id);
    res.render('travelView', { travel });
};

exports.getPrivacy = (req, res) => {
    res.render('privacyView');
};

exports.getAbout = (req, res) => {
    res.render('aboutView');
};

exports.createTravel = (req, res) => {
    const newTravel = { id: Date.now(), name: req.body.name, description: req.body.description };
    TravelModel.addTravel(newTravel);
    res.redirect('/');
};