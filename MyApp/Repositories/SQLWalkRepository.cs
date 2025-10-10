using System;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Repositories;

public class SQLWalkRepository : IWalkRepository
{
    private readonly NZWalkDbContext _context;

    public SQLWalkRepository(NZWalkDbContext context)
    {
        _context = context;
    }

    public async Task<Walk> CreateAsync(Walk walk)
    {
        await _context.Walks.AddAsync(walk);
        await _context.SaveChangesAsync();
        return walk;
    }

    public async Task<List<Walk>> GetAllAsync()
    {
        return await _context.Walks.ToListAsync();
        
    }
}
