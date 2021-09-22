using System.ComponentModel.DataAnnotations;

namespace asp_net_web_mvc_1.Models
{
    public class Product
    {
        public int Product_Id { get; set; }
        [Required(ErrorMessage = "El campo: codigo, es obligatorio")]
        public string Code { get; set; }
        [Required(ErrorMessage = "El campo: nombre, es obligatorio")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage ="El campo: precio, es obligatorio")]
        [Range(1,double.MaxValue, ErrorMessage = "El valor ingresado debe ser mayor a 1")]
        public double Price { get; set;  }
        [Required(ErrorMessage = "El campo: Cantidad minima, es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El valor ingresado debe ser mayor a 1")]
        public int Min_Quantity { get; set;  }
    }
}