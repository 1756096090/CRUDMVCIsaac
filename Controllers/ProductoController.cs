using CRUDMVC.Models;
using CRUDMVC.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDMVC.Controllers
{
    public class ProductoController : Controller
    {
        // GET: ProductoController
        public IActionResult Index()
        {
            return View(Utils.ListaProducto);
        }

        // GET: ProductoController/Details/5

        [HttpGet]
        public IActionResult Details(int IdProducto)
        {
            Producto producto = Utils.ListaProducto.Find(x => x.IdProducto == IdProducto);
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
        public IActionResult Create(Producto producto)
        {
            int id = Utils.ListaProducto.Count() + 1;
            producto.IdProducto = id;
            Utils.ListaProducto.Add(producto);
            return RedirectToAction("Index");
        }



        // GET: ProductoController/Edit/5
        public IActionResult Edit(int IdProducto)
        {
            Producto producto = Utils.ListaProducto.Find(x => x.IdProducto == IdProducto);
            if (producto != null)
            {
                return View(producto);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Producto producto)
        {
            if (producto == null)
            {
                return BadRequest("El producto es nulo");
            }

            Producto productoExistente = Utils.ListaProducto.FirstOrDefault(p => p.IdProducto == producto.IdProducto);

            if (productoExistente == null)
            {
                return NotFound("El producto no fue encontrado");
            }

            productoExistente.Nombre = producto.Nombre;
            productoExistente.Cantidad = producto.Cantidad;
            productoExistente.Descripcion = producto.Descripcion;

            return RedirectToAction("Index");
        }

        // GET: ProductoController/Delete/5
        public IActionResult Delete(int IdProducto)
        {
            Producto producto = Utils.ListaProducto.Find(x =>  x.IdProducto == IdProducto);
            if (producto != null) 
            {
                Utils.ListaProducto.Remove(producto);
            }
            return RedirectToAction("Index");
        }
    }
}
