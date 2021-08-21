using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstEF.Entity
{
    public enum Gender { Female, Male }

    public class Student
    {
        [Key]
        [DatabaseGeneratedAttribute(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public Gender Gender { get; set; }
        public DateTime? BirthDay { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}