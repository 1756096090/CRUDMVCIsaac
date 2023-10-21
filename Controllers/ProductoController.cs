using CRUDMVC.Models;
using CRUDMVC.Servicios;
using CRUDMVC.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDMVC.Controllers
{
    public class ProductoController : Controller
    {
        // GET: ProductoController
        private readonly IServicioApi servicioAPI;

        public ProductoController(IServicioApi servicioAPI)
        {
            this.servicioAPI = servicioAPI;
        }

        public async Task<IActionResult> Index()
        {


            var lista = await servicioAPI.Lista();
            return View(lista);



        }

        private IActionResult View(Func<Task<List<Producto>>> lista)
        {
            throw new NotImplementedException();
        }

        // GET: ProductoController/Details/5

        [HttpGet]
        public async Task<IActionResult> Details(int IdProducto)
        {
            Producto producto = await servicioAPI.Obtener(IdProducto);

            if (producto != null)
            {
                return View(producto);
            }
            return RedirectToAction("Index");
        }

        // GET: ProductoController/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: ProductoController/Create
        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            producto.IdProducto = 0;
            await servicioAPI.Guardar(producto);
            Console.WriteLine("funciona");
            return RedirectToAction("Index");
        }



        // GET: ProductoController/Edit/5

        public async Task<IActionResult> EditAsync(int IdProducto)
        {
            Producto producto = await servicioAPI.Obtener(IdProducto);
            if (producto != null)
            {
                return View(producto);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> EditAsync(Producto producto)
        {
            if (producto == null)
            {
                return BadRequest("El producto es nulo");
            }

            Producto productoExistente = await servicioAPI.Obtener(producto.IdProducto); 

            if (productoExistente == null)
            {
                return NotFound("El producto no fue encontrado");
            }

            await servicioAPI.Editar(producto);

            return RedirectToAction("Index");
        }

        // GET: ProductoController/Delete/5
        public async Task<IActionResult> Delete(int IdProducto)
        {
            Producto producto = await servicioAPI.Obtener(IdProducto); ;
            if (producto != null) 
            {
                await servicioAPI.Eliminar(producto);
            }
            return RedirectToAction("Index");
        }
    }
}
