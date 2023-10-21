using System.ComponentModel.DataAnnotations;

namespace CRUDMVC.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        [Required]
        public string Nombre { get; set;}
        public string Descripcion { get; set;}
        [Required]
        public int Cantidad { get; set;}

        public static implicit operator Producto(bool v)
        {
            throw new NotImplementedException();
        }
    }
}
