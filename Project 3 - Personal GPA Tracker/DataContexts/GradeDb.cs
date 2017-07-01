/////////////////////////////////////////////////////////////////////////////////////
//
// Company Name	    : Brandon Jones
// Department Name	: Computer and Information Sciences 
// File Name		: GradeDb.cs
// Purpose          : To maintain the relationship between Courses and Grades
// Author			: Brandon Jones, E-Mail: zbej4@etsu.edu
// Create Date		: Friday, November 25, 2016
//
//-----------------------------------------------------------------------------------
//
// Modified Date	: Sunday, November 27, 2016
// Modified By		: Brandon Jones
//
/////////////////////////////////////////////////////////////////////////////////////

using Project_3___Personal_GPA_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project_3___Personal_GPA_Tracker.DataContexts
{
    public class GradesDb : DbContext
    {
        public GradesDb()
            : base("name=DefaultConnection")
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
}