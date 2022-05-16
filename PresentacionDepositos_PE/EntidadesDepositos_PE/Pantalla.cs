using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesDepositos_PE
{
    public class Pantalla : Elemento, IDescriptible
    {
        public short AñoFabricacion { get; set; }
        public bool Nuevo { get; set; }
        public int? Pulgadas { get; set; }
        public Pantalla(string modelo, string marca, int numeroDeSerie, short añoFabricacion, int? pulgadas)
        {
            this.Modelo = modelo;
            this.Marca = marca;
            this.NumeroDeSerie = numeroDeSerie;
            this.AñoFabricacion = añoFabricacion;
            this.Nuevo = AñoFabricacion == DateTime.Now.Year ? true : false; // Si lo hago en el set, me da un error el json, imprime en bucle en consola
            this.Pulgadas = pulgadas;
        }

        public string Describirse()
        {
            return Pulgadas == null ? $"MONITOR {Marca}-{Modelo}" : $"MONITOR {Marca}-{Modelo} {Pulgadas}";
        }
    }
}
