using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalkController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        //Create Walk
        //POST : api/Walk
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDTO addWalkRequestDTO)
        {
            //Map Walk DTO to Walk Domain
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDTO);
            await walkRepository.CreateAsync(walkDomainModel);

            return Ok(mapper.Map<WalkDTO>(walkDomainModel));
        }
        //Get Walk
        //Get : api/walk
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walksDomainModel = await walkRepository.GetAllAsync();
            return Ok(mapper.Map<List<WalkDTO>>(walksDomainModel));
        }

        //Get Walk by ID
        //Get : api/walk/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetbyId([FromRoute] Guid id)
        {
            var WalkDomain = await walkRepository.GetByIdAsync(id);
            if (WalkDomain == null)
            {
                NotFound();
            }
            return Ok(mapper.Map<WalkDTO>(WalkDomain));
        }


        //Update Walk by Id
        //PUT: api/walk/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,UpdateWalkRequestDTO updateWalkRequestDTO)
        {
            //Map DTO to Domain Model
            var walkDomain = mapper.Map<Walk>(updateWalkRequestDTO);
            walkDomain = await walkRepository.UpdateAsync(id, walkDomain);
            if (walkDomain == null)
            {
                NotFound();
            }

            return Ok(mapper.Map<WalkDTO>(walkDomain));
        }
    }
}
