using System.ComponentModel.DataAnnotations;

namespace asp_net_web_mvc_1.Models
{
    public class Client
    {
        public int Client_Id { get; set; }
        [Required(ErrorMessage = "El campo: nombre, es obligatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El campo: nit, es obligatorio")]
        public string Nit { get; set; }
        public string Phone_Number { get; set; }
        [Required(ErrorMessage = "El campo: dirección, es obligatorio")]
        public string Direction { get; set; }
        public string E_Mail { get; set; }
    }
}