using System;
using MyApp.Models;

namespace MyApp.Repositories;

public interface IWalkRepository
{
   Task<Walk> CreateAsync(Walk walk);

   Task<List<Walk>> GetAllAsync();

   Task<Walk?> GetByIdAsync(Guid id);

   Task<Walk> UpdateAsync(Walk walk, Guid id);

} 
