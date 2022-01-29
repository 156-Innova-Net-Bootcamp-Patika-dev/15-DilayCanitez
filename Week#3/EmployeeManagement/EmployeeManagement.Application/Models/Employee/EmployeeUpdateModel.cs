﻿using EmployeeManagement.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Application.Models.Employee
{
    public class EmployeeUpdateModel
    {
        [Required(ErrorMessage = "{0} field is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }
    }
}
