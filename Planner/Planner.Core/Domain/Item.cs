using Planner.Core.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Core.Domain
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemStatus Status { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Creator { get; set; }
        public string Responsibility { get; set; }

        public Item(string name, string description, DateTime dueDate, string creator, string responsibility)
        {
            SetName(name);
            SetDescription(description);
            SetDueDate(dueDate);
            SetCreator(creator);
            SetResponsibility(responsibility);
            Status = ItemStatus.Open;
            CreatedAt = DateTime.Now;
        }

        private void SetResponsibility(string responsibility)
        {
            Responsibility = responsibility;
        }

        private void SetCreator(string creator)
        {
            if (string.IsNullOrWhiteSpace(creator))
            {
                throw new ArgumentException("Creator can not be blank", nameof(creator));
            }

            Creator = creator;
            SetUpdate();
        }

        private void SetDueDate(DateTime dueDate)
        {
            DueDate = dueDate;
            SetUpdate();
        }

        private void SetDescription(string description)
        {
            Description = description;
            SetUpdate();
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Item name can not be blank", nameof(name));
            }
            
            Name = name;
            SetUpdate();
        }

        private void SetUpdate()
        {
            this.UpdatedAt = DateTime.Now;
        }
    }
}
