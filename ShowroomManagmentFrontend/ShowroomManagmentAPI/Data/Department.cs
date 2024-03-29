﻿using System.ComponentModel.DataAnnotations;

namespace ShowroomManagmentAPI.Data
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public IList<Empolyee> Empolyees { get; set; }
    }
}
