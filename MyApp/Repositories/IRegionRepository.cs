using System;
using MyApp.Models;

namespace MyApp.Repositories;

public interface IRegionRepository
{
     Task<List<Region>> GetAllAsync();
}
