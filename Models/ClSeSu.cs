namespace SKC_MVC.Models
{
    public class ClSeSu
    {
        public int Id { get; set; }
        public bool Flag { get; set; }
        public int NumOfClassPerWeek { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}
