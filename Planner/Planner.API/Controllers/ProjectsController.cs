using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Planner.Core.Domain;
using Planner.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProjectsController : ControllerBase
	{
		private IProjectRepository _projectRepository;

		public ProjectsController(IProjectRepository projectRepository)
		{
			this._projectRepository = projectRepository;
		}

		// GET: api/Projects
		[HttpGet]
		public async Task<IEnumerable<Project>> GetProjects()
		{
			return await _projectRepository.GetAllProjectsAsync();
		}

		// GET: api/Projects/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetProject([FromRoute] Guid id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var project = await _projectRepository.GetProjectByIdAsync(id);

			if (project == null)
			{
				return NotFound();
			}

			return Ok(project);
		}

		// PUT: api/Projects/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutProject([FromRoute] Guid id, [FromBody] Project project)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != project.ID)
			{
				return BadRequest();
			}

			try
			{
				//await _projectRepository.UpdateProjectAsync(project);
			}
			catch (DbUpdateConcurrencyException)
			{
				//if (!ProjectExists(id))
				//{
				//	return NotFound();
				//}
				//else
				//{
				//	throw;
				//}
			}

			return NoContent();
		}

		// POST: api/Projects
		[HttpPost]
		public async Task<IActionResult> PostProject([FromBody] Project project)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await _projectRepository.AddProjectAsync(project);

			return CreatedAtAction("GetProject", new { id = project.ID }, project);
		}

		//// DELETE: api/Projects/5
		//[HttpDelete("{id}")]
		//public async Task<IActionResult> DeleteProject([FromRoute] Guid id)
		//{
		//	if (!ModelState.IsValid)
		//	{
		//		return BadRequest(ModelState);
		//	}

		//	var project = await _projectRepository.DeleteProjectAsync(project);
		//	if (project == null)
		//	{
		//		return NotFound();
		//	}

		//	_context.Projects.Remove(project);
		//	await _context.SaveChangesAsync();

		//	return Ok(project);
		//}

		//private bool ProjectExists(Guid id)
		//{
		//	return _context.Projects.Any(e => e.ID == id);
		//}
	}
}