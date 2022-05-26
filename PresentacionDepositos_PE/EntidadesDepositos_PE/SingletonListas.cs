using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesDepositos_PE
{
    public sealed class SingletonListas //SI LAS LISTAS SON PUBLICAS LA CLASE SINGLETON NO TIENE MUCHO SENTIDO, NO SE USA NUNCA PARA EJECUTAR ALGUN METODO
    {
        private static SingletonListas instancia = new SingletonListas();
        public List<Pantalla> pantallas { get; set; } 
        public List<Computadora> computadoras { get; set; }
        private SingletonListas() { pantallas = new List<Pantalla>(); computadoras = new List<Computadora>(); }
        public static SingletonListas Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new SingletonListas();
                }

                return instancia;
            }
        }
    }
}
