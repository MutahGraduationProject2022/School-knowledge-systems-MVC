﻿namespace SKC_MVC.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }
        public ICollection<Grades> Grades { get; set; }
    }
}
