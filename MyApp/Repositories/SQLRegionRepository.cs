using System;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Repositories;

public class SQLRegionRepository : IRegionRepository
{
   private readonly NZWalkDbContext _regionRepository;
   public SQLRegionRepository (NZWalkDbContext RegionRepository)
    {
        _regionRepository = RegionRepository;
    }
    public async Task<List<Region>> GetAllAsync()
    {
       return await _regionRepository.Regions.ToListAsync();
    }
}
