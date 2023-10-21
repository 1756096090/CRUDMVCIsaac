using CRUDMVC.Models;

namespace CRUDMVC.Servicios
{
    public class Servicio_API : IServicioApi

    {
        


        public async Task<List<Producto>> Lista()
        {
            List<Producto>? lista = new List<Producto>();
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:5015/api/Producto");

            if (response.IsSuccessStatusCode)
            {
                lista = await response.Content.ReadAsAsync<List<Producto>>();
            }

            return lista;
        }

        public async Task<bool> Editar(Producto producto)
        {
            var client = new HttpClient();
            var response = await client.PutAsJsonAsync($"http://localhost:5015/api/Producto/{producto.IdProducto}", producto);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Eliminar(Producto producto)
        {
            var client = new HttpClient();
            var response = await client.DeleteAsync($"http://localhost:5015/api/Producto/{producto.IdProducto}");

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Guardar(Producto producto)
        {
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync("http://localhost:5015/api/Producto", producto);
            if (response.IsSuccessStatusCode)
            {

            return response.IsSuccessStatusCode;
            }
            return false;
        }

        public async Task<Producto> Obtener(int idProducto)
        {
            Producto producto = null;
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"http://localhost:5015/api/Producto/{idProducto}");

            if (response.IsSuccessStatusCode)
            {
                producto = await response.Content.ReadAsAsync<Producto>();
            }

            return producto;
        }


    }
}