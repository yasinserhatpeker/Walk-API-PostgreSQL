using System.Net.WebSockets;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;
using MyApp.Models.DTOs;
using MyApp.Repositories;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly NZWalkDbContext _context;
        private readonly IRegionRepository _regionRepository;

        private readonly IMapper _mapper;
        public RegionController(NZWalkDbContext context, IRegionRepository regionRepository, IMapper mapper)
        {
            _context = context;
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regions = await _regionRepository.GetAllAsync();
            return Ok(_mapper.Map<List<RegionDTO>>(regions));

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var regionDomain = await _regionRepository.GetByIdAsync(id);
           
            if(regionDomain == null) {
                return NotFound();
            }
            
            return Ok(_mapper.Map<RegionDTO>(regionDomain));

        }
        [HttpPost]
        public async Task<IActionResult> Create(AddRegionRequestDTO addRegionRequestDTO)
        {
            var regionDomainModel = _mapper.Map<Region>(addRegionRequestDTO);
           

          regionDomainModel = await _regionRepository.CreateAsync(regionDomainModel);


            var regionDTO = _mapper.Map<RegionDTO>(regionDomainModel);


            return CreatedAtAction(nameof(GetById), new { id = regionDTO.Id }, regionDTO);
        }
        [HttpPut]
        [Route("{id}")]
        public  async Task<IActionResult> Update(Guid id, UpdateRegionRequestDTO updateRegionRequestDTO)
        {
            var regionDomainModel = _mapper.Map<Region>(updateRegionRequestDTO);

            regionDomainModel = await _regionRepository.UpdateAsync(regionDomainModel,id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }

           // Convert DomainModel to DTO
            var regionDTO = _mapper.Map<RegionDTO>(regionDomainModel);

            return Ok(regionDTO);



        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var regionDomainModel = await _regionRepository.DeleteAsync(id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }
            var regionDTO = _mapper.Map<RegionDTO>(regionDomainModel);
    
           
            return Ok(regionDTO);
            
        }
    }
}
