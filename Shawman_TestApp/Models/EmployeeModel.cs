using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shawman_TestApp.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Date of Birth is Required")]
        public string DateOfBirth { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "User Name is Required")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "MobileNo is Required")]
        public string Designation{ get; set; }
        
        public Nullable<int> DesignationId { get; set; }
        public List<DesignationModel> designationModels { get; set; }

    }
    public class DesignationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    }