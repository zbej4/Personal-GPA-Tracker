/////////////////////////////////////////////////////////////////////////////////////
//
// Company Name	    : Brandon Jones
// Department Name	: Computer and Information Sciences 
// File Name		: Grade.cs
// Purpose          : To store information relating to Grades
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
using System.Linq;
using System.Web;

namespace Project_3___Personal_GPA_Tracker.Models
{
    public class Grade
    {
        [Key]
        [RegularExpression(@"A-?|[BCD][+-]?|F|U", ErrorMessage = "Not a valid letter grade.")]
        public string LetterGrade { get; set; }

        [Required]
        [Range(0.0,4.0)]
        public double GradePoints { get; set; }
    }
}