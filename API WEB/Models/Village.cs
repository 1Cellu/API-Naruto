using API_WEB.Models.Enuns;

namespace API_WEB.Models
{
    public class Village
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public OrderGraduation Graduation { get; set; }
        public OrderCountry Country { get; set; }
    }
}
