using System;

namespace Planner.Core.Domain
{
	public class Project
	{
		public Guid ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }

		public Project(string name, string description)
		{
			SetName(name);
			SetDescription(description);
			this.ID = new Guid();
			this.CreatedAt = DateTime.Now;
		}

		private void SetDescription(string description)
		{
			//If needed we can add here validation for the field
			this.Description = description;
		}

		private void SetName(string name)
		{
			if (String.IsNullOrEmpty(name)) throw new ArgumentException("Project's name can not be empty");

			this.Name = name;
		}

		private void SetUpdate()
		{
			this.UpdatedAt = DateTime.Now;
		}
	}
}
