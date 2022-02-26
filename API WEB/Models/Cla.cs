namespace API_WEB.Models
{
    public class Cla
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public KekkeiGenkai KekkeiGenkai { get; set; }

        public List<Ninja> Ninjas = new List<Ninja>();

        public Village Village { get; set; }

    }
}
