using System.ComponentModel.DataAnnotations;

namespace WebApi.Controllers
{
    public class Model
    {
        [Required]
        public string Text { get; set; }
    }
}