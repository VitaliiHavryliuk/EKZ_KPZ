using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using DTOs.ProjectTasksDTOs;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProjectTaskController : ControllerBase
    {
        private readonly IProjectTaskService _projectTaskService;

        public ProjectTaskController(IProjectTaskService projectTaskService, IMapper mapper)
        {
            _projectTaskService = projectTaskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _projectTaskService.GetAllAsync<ProjectTaskDTO>();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectAsync([FromRoute] int id)
        {
            await _projectTaskService.DeleteByIdAsync(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProjectAsync([FromBody] CreateProjectTaskDTO model)
        {
            var result = await _projectTaskService.CreateAsync(model);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProjectAsync([FromBody] UpdateProjectTaskDTO model)
        {
            await _projectTaskService.UpdateAsync(model);
            return Ok();
        }
    }
}
