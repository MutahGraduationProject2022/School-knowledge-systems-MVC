namespace SKC_MVC.Models
{
    public class Section
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public ICollection<Student> Students { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}
