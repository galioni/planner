using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Planner.Core.Domain;
using Planner.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProjectsController : ControllerBase
	{
		private readonly PlannerContext _context;

		public ProjectsController(PlannerContext context)
		{
			_context = context;
		}

		// GET: api/Projects
		[HttpGet]
		public IEnumerable<Project> GetProjects()
		{
			return _context.Projects;
		}

		// GET: api/Projects/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetProject([FromRoute] Guid id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var project = await _context.Projects.FindAsync(id);

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

			_context.Entry(project).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ProjectExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
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

			_context.Projects.Add(project);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetProject", new { id = project.ID }, project);
		}

		// DELETE: api/Projects/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProject([FromRoute] Guid id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var project = await _context.Projects.FindAsync(id);
			if (project == null)
			{
				return NotFound();
			}

			_context.Projects.Remove(project);
			await _context.SaveChangesAsync();

			return Ok(project);
		}

		private bool ProjectExists(Guid id)
		{
			return _context.Projects.Any(e => e.ID == id);
		}
	}
}