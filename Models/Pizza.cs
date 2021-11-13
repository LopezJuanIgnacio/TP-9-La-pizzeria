using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP9.Models{

    public class Pizza{
        private int _IdPizza;
        private String _Nombre;
        private double _Precio;
        private Tamaños _Tamaño;
        private String _UrlFoto;
        private List <Ingrediente> _ListaIngredientes = new List<Ingrediente>();
        public static int i = 0;

        public Pizza(String Nombre, double Precio, String Url, String Tamaño){
            _Nombre = Nombre;
            _Precio = Precio;
            _UrlFoto = Url;
            _IdPizza = ++i;
            switch (Tamaño)
            {
                case "Grande":
                    _Tamaño = Tamaños.Grande;
                    break;
                case "Mediana":
                    _Tamaño = Tamaños.Mediana;
                    break;
                default:
                    _Tamaño = Tamaños.Chica;
                    break;
            }
        }
        public List <Ingrediente> ListarIngredientes(){
            return _ListaIngredientes;
        }
        public void AgregarIngredientes(Ingrediente ingrediente){
            _ListaIngredientes.Add(ingrediente);
        }
        public int IdPizza{
            get{
                return _IdPizza;
            }
        }
        public String Nombre{
            get{
                return _Nombre;
            }
        }
        public double Precio{
            get{
                return _Precio;
            }
        }
        public String UrlFoto{
            get{
                return _UrlFoto;
            }
        }
        public Tamaños Tamaño{
            get{
                return _Tamaño;
            }
        }

    }
}