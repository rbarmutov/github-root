using Microsoft.EntityFrameworkCore;

public class TravelService
{
    private readonly ApplicationDbContext _context;

    public TravelService(ApplicationDbContext context)
    {
        _context = context;
    }

    // Get all travels
    public async Task<List<Travel>> GetAllTravelsAsync()
    {
        return await _context.Travels.Include(p => p.Category).ToListAsync();
    }

    // Get travel by Id
    public async Task<Travel?> GetTravelByIdAsync(int id)
    {
        return await _context.Travels.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
    }

    // Create a new travel (without saving changes)
    public async Task<Travel> AddTravel(TravelEditDto model)
    {
        var categoryRef = await _context.Categories.Include(c => c.Travels).FirstOrDefaultAsync(c => c.Id == model.CategoryId);

        if (categoryRef == null)
        {
            throw new Exception("Category not found");
        }

        var travel = new Travel
        {
            Name = model.Name,
            Price = model.Price,
            CategoryId = model.CategoryId,
            Description = model.Description
        };

        _context.Travels.Add(travel);
        return travel;
    }

    // Update a travel (without saving changes)
    public Travel UpdateTravel(TravelEditDto travel)
    {
        var existingTravel = _context.Travels.Find(travel.Id);
        if (existingTravel == null)
        {
            throw new Exception("Travel not found");
        }

        existingTravel.Name = travel.Name;
        existingTravel.Price = travel.Price;
        existingTravel.Description = travel.Description;
        existingTravel.CategoryId = travel.CategoryId;

        return existingTravel;
    }

    // Delete a travel (without saving changes)
    public bool DeleteTravel(int id)
    {
        var travel = _context.Travels.Find(id);
        if (travel == null)
        {
            throw new Exception("Travel not found");
        }

        _context.Travels.Remove(travel);
        return true;
    }
}
