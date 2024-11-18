class TravelModel {
    constructor() {
        this.travels = [{ id: 1, name: 'France', description: 'A journey to France is like stepping into a world where history, culture, and natural beauty come alive. Begin in Paris, the City of Lights, where iconic landmarks like the Eiffel Tower, the Louvre, and the charming streets of Montmartre capture the heart. Beyond the capital, the French countryside unfolds with endless vineyards in Bordeaux, lavender fields in Provence, and picturesque coastal towns along the French Riviera. Savoring French cuisine - from buttery croissants to gourmet cheeses - is an experience in itself. A trip to France offers unforgettable memories of art, architecture, and the simple joy of life, or joie de vivre, in every corner.' }];
    }

    getAllTravels() {
        return this.travels;
    }

    addTravel(travel) {
        this.travels.push(travel);
    }
}

module.exports = new TravelModel();