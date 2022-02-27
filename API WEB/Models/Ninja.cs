namespace API_WEB.Models
{
    public class Ninja
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Cla? Cla { get; set; }
        public Village? Village { get; set; }
        public bool IsRenegate { get; set; }
        
    }
}