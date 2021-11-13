using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP9.Models{
    public class Ingrediente{
        private int _IdIngrediente;
        private String _Nombre;
        private String _UrlFoto;
        public static int i = 0;

        public Ingrediente(String nombre, String url){
            _IdIngrediente = ++i;
            _Nombre = nombre;
            _UrlFoto = url;
        }

        public int IdIngrediente{
            get{
                return _IdIngrediente;
            }
        }
        public String Nombre{
            get{
                return _Nombre;
            }
        }
        public String UrlFoto{
            get{
                return _UrlFoto;
            }
        }
    }
}