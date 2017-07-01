/////////////////////////////////////////////////////////////////////////////////////
//
// Company Name	    : Brandon Jones
// Department Name	: Computer and Information Sciences 
// File Name		: Course.cs
// Purpose          : To store information relating to courses taken
// Author			: Brandon Jones, E-Mail: zbej4@etsu.edu
// Create Date		: Friday, November 25, 2016
//
//-----------------------------------------------------------------------------------
//
// Modified Date	: Sunday, November 27, 2016
// Modified By		: Brandon Jones
//
/////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_3___Personal_GPA_Tracker.Models
{
    public class Course
    {
        [Key]
        [Display(Name ="Course Code")]
        [RegularExpression(@"^[A-z]{4}\d{4}$", ErrorMessage = "Course Code must be 4 letters followed by 4 digits.")]
        public string CourseCode { get; set; }

        [Required]
        [Display(Name ="Course Title")]
        public string CourseTitle { get; set; }

        [Required]
        [Display(Name ="Credit Hours")]
        [Range(1,6)]
        public int CreditHours { get; set; }

        [Required]
        [Display(Name ="Course Grade [Grade Points]")]
        [ForeignKey("Grade")]
        public string CourseGrade { get; set; }
        public virtual Grade Grade { get; set; }
    }
}