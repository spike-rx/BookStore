namespace BookStore.Data.Services;

public class ConduitRepository
{
    private readonly ConduitRepository _context;

    public ConduitRepository(ConduitRepository context)
    {
        _context = context;
    }
}