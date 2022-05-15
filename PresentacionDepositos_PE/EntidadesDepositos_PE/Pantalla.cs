using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesDepositos_PE
{
    public class Pantalla : Elemento
    {
        public short AñoFabricacion { get; set; }
        public bool Nuevo { get { return Nuevo; } set { Nuevo = AñoFabricacion == DateTime.Now.Year ? true : false; } }
        public int? Pulgadas { get; set; }
        public Pantalla(string modelo, string marca, int numeroDeSerie, short añoFabricacion, int? pulgadas)
        {
            this.Modelo = modelo;
            this.Marca = marca;
            this.NumeroDeSerie = numeroDeSerie;
            this.AñoFabricacion = añoFabricacion;
            this.Pulgadas = pulgadas;
        }
        public override string Desribirse()
        {
            return Pulgadas == null ? $"MONITOR {Marca}-{Modelo}" : $"MONITOR {Marca}-{Modelo} {Pulgadas}";
        }
    }
}
