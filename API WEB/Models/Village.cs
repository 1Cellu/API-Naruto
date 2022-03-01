using API_WEB.Models.Enuns;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_WEB.Models
{
    public class Village
    {
    
        public long Id { get; set; }
     
        public string Name { get; set; }
      
        public OrderCountry Country { get; set; }
    }
}
