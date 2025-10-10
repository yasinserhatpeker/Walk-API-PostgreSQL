using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.Models.DTOs;
using MyApp.Repositories;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepository _walkRepository;

        public WalkController(IMapper mapper, IWalkRepository repository)
        {
            _mapper = mapper;
            _walkRepository = repository;
        }
        [HttpPost]

        public async Task<IActionResult> Create(AddWalkRequestDTO addWalkRequestDTO)
        {
            // Map DTO to DomainModel 
            var walkDomainModel = _mapper.Map<Walk>(addWalkRequestDTO);

            await _walkRepository.CreateAsync(walkDomainModel);

            // Convert DomainModel to DTO
            var walkDTO = _mapper.Map<WalkDTO>(walkDomainModel);

            return Ok(walkDTO);


        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walks = await _walkRepository.GetAllAsync();
            return Ok(walks);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var walkDomainModel = await _walkRepository.GetByIdAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            // Convert DomainModel to DTO
            var walkDTO = _mapper.Map<WalkDTO>(walkDomainModel);
            return Ok(walkDTO);

        }
        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> Update(Guid id, UpdateRegionRequestDTO updateRegionRequestDTO)
        {
            // Map DTO to DomainModel
            var walkDomainModel = _mapper.Map<Walk>(updateRegionRequestDTO);

            await _walkRepository.UpdateAsync(walkDomainModel, id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            // Convert DomainModel to DTO
            var walkDTO = _mapper.Map<WalkDTO>(walkDomainModel);
            return Ok(walkDTO);




        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var walkDomainModel = await _walkRepository.DeleteAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }

            // Convert DomainModel to DTO 
            var walkDTO = _mapper.Map<WalkDTO>(walkDomainModel);
            return Ok(walkDTO);

        }

    }
}
