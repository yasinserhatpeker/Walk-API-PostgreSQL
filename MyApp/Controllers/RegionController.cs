using System.Net.WebSockets;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.CustomActionFilters;
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

        private readonly IRegionRepository _regionRepository;
        private readonly ILogger<RegionController> _logger;

        private readonly IMapper _mapper;
        public RegionController(IRegionRepository regionRepository, IMapper mapper, ILogger<RegionController> logger)
        {
            
            _regionRepository = regionRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        [ValidateModel]
         [Authorize(Roles ="Writer")]
        public async Task<IActionResult> Create(AddRegionRequestDTO addRegionRequestDTO)
        {
           

                var regionDomainModel = _mapper.Map<Region>(addRegionRequestDTO);


                regionDomainModel = await _regionRepository.CreateAsync(regionDomainModel);


                var regionDTO = _mapper.Map<RegionDTO>(regionDomainModel);


                return CreatedAtAction(nameof(GetById), new { id = regionDTO.Id }, regionDTO);

            
        }

        [HttpGet]
        [Authorize(Roles ="Reader")]
        public async Task<IActionResult> GetAll()
        {
            var regions = await _regionRepository.GetAllAsync();
            return Ok(_mapper.Map<List<RegionDTO>>(regions));

        }

        [HttpGet]
        [Route("{id}")]
         [Authorize(Roles ="Reader")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var regionDomain = await _regionRepository.GetByIdAsync(id);
           
            if(regionDomain == null) {
                return NotFound();
            }
            
            return Ok(_mapper.Map<RegionDTO>(regionDomain));

        }
      
        [HttpPut]
        [Route("{id}")]
         [Authorize(Roles ="Writer")]
        [ValidateModel]
        public  async Task<IActionResult> Update(Guid id, UpdateRegionRequestDTO updateRegionRequestDTO)
        {
           
                var regionDomainModel = _mapper.Map<Region>(updateRegionRequestDTO);

                regionDomainModel = await _regionRepository.UpdateAsync(regionDomainModel, id);
                if (regionDomainModel == null)
                {
                    return NotFound();
                }

                // Convert DomainModel to DTO
                var regionDTO = _mapper.Map<RegionDTO>(regionDomainModel);

                return Ok(regionDTO);

            
            


        }
        [HttpDelete]
        [Authorize(Roles ="Writer")]
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
