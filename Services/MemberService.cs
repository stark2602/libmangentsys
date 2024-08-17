using Library.api.Model;
using Microsoft.EntityFrameworkCore;
namespace Library.api.Services
{
    public class MemberService : IMemberService
{
    private readonly LibraryDbContext _context;

    public MemberService(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Member>> GetAllMembersAsync()
    {
        return await _context.Members.ToListAsync();
    }

    public async Task<Member> GetMemberByIdAsync(int id)
    {
        var member = await _context.Members.FindAsync(id);

        if (member == null)
        {
            throw new KeyNotFoundException($"Member with ID {id} not found.");
        }

        return member;
    }


    public async Task<Member> AddMemberAsync(Member member)
    {
        _context.Members.Add(member);
        await _context.SaveChangesAsync();
        return member;
    }

    public async Task<Member> UpdateMemberAsync(Member member)
    {
        _context.Members.Update(member);
        await _context.SaveChangesAsync();
        return member;
    }

    public async Task DeleteMemberAsync(int id)
    {
        var member = await _context.Members.FindAsync(id);
        if (member != null)
        {
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
        }
    }
}
}