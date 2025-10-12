using System;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Repositories;

public class SQLWalkRepository : IWalkRepository
{
    private readonly NZWalkDbContext _DbContext;

    public SQLWalkRepository(NZWalkDbContext DbContext)
    {
        _DbContext = DbContext;
    }

    public async Task<Walk> CreateAsync(Walk walk)
    {
        await _DbContext.Walks.AddAsync(walk);
        await _DbContext.SaveChangesAsync();
        return walk;
    }

    public async Task<Walk> DeleteAsync(Guid id)
    {
        var existingRegion = _DbContext.Walks.FirstOrDefault(x => x.Id == id);
        if (existingRegion == null)
        {
            return null!;
        }
        _DbContext.Walks.Remove(existingRegion);
        await _DbContext.SaveChangesAsync();
        return existingRegion;


    }

    public async Task<List<Walk>> GetAllAsync(string? filterOn=null, string? filterQuery=null, string? sortBy=null, bool isAscending=true)
    {
        var walks = _DbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();

        // filtering
        if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
        {
            if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                walks = walks.Where(x => x.Name.Contains(filterQuery));
            }
        }

        // sorting 
        if(string.IsNullOrWhiteSpace(sortBy)== false)
        {
            if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
            }
            else if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
            {
                walks = isAscending ? walks.OrderBy(x => x.LengthinKm) : walks.OrderByDescending(x => x.LengthinKm);
            }
            
        }

        return await walks.ToListAsync();

       //  return await _DbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
        
    }

    public async Task<Walk?> GetByIdAsync(Guid id)
    {
        return await _DbContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Walk> UpdateAsync(Walk walk, Guid id)
    {
        var existingWalk = await _DbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
        if (existingWalk == null)
        {
            return null!;
        }
        existingWalk.Name = walk.Name;
        existingWalk.Description = walk.Description;
        existingWalk.LengthinKm = walk.LengthinKm;
        existingWalk.WalkImageUrl = walk.WalkImageUrl;
        existingWalk.DifficultyId = walk.DifficultyId;
        existingWalk.RegionId = walk.RegionId;

        await _DbContext.SaveChangesAsync();
        return existingWalk;

    }
}
