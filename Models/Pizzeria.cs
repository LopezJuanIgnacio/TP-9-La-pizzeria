using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP9.Models;

namespace TP9.Models{
    public static class Pizzeria{
        private static List <Ingrediente> _ListaIngredientes = new List<Ingrediente>();
        private static List <Pizza> _ListaPizzas = new List<Pizza>();
        public static List <Ingrediente> ListarIngredientes(){
            return _ListaIngredientes;
        }
        public static List <Pizza> ListarPizzas(){
            return _ListaPizzas;
        }
        public static void AgregarPizza(Pizza unaPizza){
            _ListaPizzas.Add(unaPizza);
        }
        public static void EliminarPizza(int index){
            _ListaPizzas.RemoveAt(index);
        }
        public static void AgregarIngrediente(Ingrediente i){
            _ListaIngredientes.Add(i);
        }
    }
}