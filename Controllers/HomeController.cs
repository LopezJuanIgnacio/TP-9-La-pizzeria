using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TP9.Models;

namespace TP9.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            ViewBag.Pizzas = Pizzeria.ListarPizzas();
            return View();
        }
        
        public IActionResult VerPizza(int Id)
        {
            int index = DeterminarIndex(Id);
            ViewBag.Pizza = Pizzeria.ListarPizzas()[index];
            return View();
        }
        public IActionResult AgregarPizza(int Id)
        {
            ViewBag.isPizza = true;
            ViewBag.Ingredientes = Pizzeria.ListarIngredientes();
            if(Id == -1) return View();
            else if(Id >= 0){
                int index = DeterminarIndex(Id);
                ViewBag.Pizza = Pizzeria.ListarPizzas()[index];
                return View();
            }else if(Id == -2){
                ViewBag.isPizza = false;
                return View();
            }
            else return StatusCode(400);
        }
        [HttpPost]
        public ActionResult GuardarPizza(String Nombre, double Precio, String Url, String Tamaño, List<int> Ingredientes)
        {
            try{
                Pizza pizzi = new Pizza(Nombre, Precio, Url, Tamaño);
                List<Ingrediente> listaIngredientes = Pizzeria.ListarIngredientes();
                foreach(var Ingrediente in Ingredientes)
                {
                    int i = DeterminarIndexIngrediente(Ingrediente);
                    if(i != -1) pizzi.AgregarIngredientes(listaIngredientes[i]);
                }
                Pizzeria.AgregarPizza(pizzi);
                return Redirect("/Home/");
            }catch{
                return StatusCode(502);
            }
            
        }
        [HttpPost]
        public ActionResult GuardarIngrediente(String Nombre, String Url)
        {
            try{
                Ingrediente i = new Ingrediente(Nombre,Url);
                Pizzeria.AgregarIngrediente(i);
                return Redirect("/Home/");
            }catch{
                return StatusCode(502);
            }
            
        }
        public ActionResult EliminarPizza(int Id)
        {
            try{
                int index = DeterminarIndex(Id);
                if(index != -1) Pizzeria.EliminarPizza(index);
                return Redirect("/Home/");
            }catch{
                return StatusCode(502);
            }
        }
        [HttpPost]
        public ActionResult EditarPizza(int Id,String Nombre, double Precio, String Url, String Tamaño, List<int> Ingredientes)
        {
            try{
                //tecnicamente no es editar, es crear otra con los cambios, pero esto con una basse de datos de verdad se arregla
                int index = DeterminarIndex(Id);
                if(index != -1){
                    Pizzeria.EliminarPizza(index);
                    List<Ingrediente> listaIngredientes = Pizzeria.ListarIngredientes();
                    Pizza pizzi = new Pizza(Nombre, Precio, Url, Tamaño);
                    foreach (var Ingrediente in Ingredientes)
                    {
                        int i = DeterminarIndexIngrediente(Ingrediente);
                        if(i != -1) pizzi.AgregarIngredientes(listaIngredientes[i]);
                    }
                    Pizzeria.AgregarPizza(pizzi);
                } 
                return Redirect("/Home/");
            }catch{
                return StatusCode(502);
            }
        }
        public int DeterminarIndex(int Id){
            int i = 0;
            foreach (var item in Pizzeria.ListarPizzas())
            {
                if(item.IdPizza == Id) return i;
                i++;
            }
            return -1;
        }
        public int DeterminarIndexIngrediente(int Id){
            int i = 0;
            foreach (var item in Pizzeria.ListarIngredientes())
            {
                if(item.IdIngrediente == Id) return i;
                i++;
            }
            return -1;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
