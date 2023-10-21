using CRUDMVC.Models;

namespace CRUDMVC.Servicios
{
    public interface IServicioApi
    {
        Task<List<Producto>> Lista();
        Task<Producto> Obtener(int idProducto);
        Task<bool> Guardar(Producto producto);
        Task<bool> Editar(Producto producto);
        Task<bool> Eliminar(Producto producto);
    }
}
