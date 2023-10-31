namespace SKC_MVC.Models
{
    public class Class
    {
        public int Id { get; set; }
        public int NumberOfClassesPerWeek { get; set; }
        public int NumberOfStudents { get; set; }
        public ICollection<Section> Sections { get; set; }
        public ICollection<ClSeSu> ClSeSu { get; set; }
    }
}
