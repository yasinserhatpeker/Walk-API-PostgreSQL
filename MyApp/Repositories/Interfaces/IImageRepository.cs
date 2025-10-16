using System;
using MyApp.Models.Entities;

namespace MyApp.Repositories.Interfaces;

public interface IImageRepository
{
   Task<Image> Upload(Image image);
}
