namespace Project_3___Personal_GPA_Tracker.DataContexts.GradesMigrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Project_3___Personal_GPA_Tracker.DataContexts.GradesDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"DataContexts\GradesMigrations";
        }

        protected override void Seed(Project_3___Personal_GPA_Tracker.DataContexts.GradesDb context)
        {
            context.Grades.AddOrUpdate(g => g.LetterGrade,
                new Grade { LetterGrade = "A", GradePoints = 4.0 },
                new Grade { LetterGrade = "A-", GradePoints = 3.7 },
                new Grade { LetterGrade = "B+", GradePoints = 3.3 },
                new Grade { LetterGrade = "B", GradePoints = 3.0 },
                new Grade { LetterGrade = "B-", GradePoints = 2.7 },
                new Grade { LetterGrade = "C+", GradePoints = 2.3 },
                new Grade { LetterGrade = "C", GradePoints = 2.0 },
                new Grade { LetterGrade = "C-", GradePoints = 1.7 },
                new Grade { LetterGrade = "D+", GradePoints = 1.3 },
                new Grade { LetterGrade = "D", GradePoints = 1.0 },
                new Grade { LetterGrade = "F", GradePoints = 0.0 },
                new Grade { LetterGrade = "U", GradePoints = 0.0 }
            );
        }
    }
}
