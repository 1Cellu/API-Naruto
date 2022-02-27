using API_WEB.Models.Enuns;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_WEB.Models
{
    public class Ninja
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Cla? Cla { get; set; }

        [Column(Name = "village_id")]
        public Village? Village { get; set; } //Anotação para lembrar de fazer uma anotação
        public OrderGraduation Graduation { get; set; }
        public bool IsRenegate { get; set; }
        
    }
}