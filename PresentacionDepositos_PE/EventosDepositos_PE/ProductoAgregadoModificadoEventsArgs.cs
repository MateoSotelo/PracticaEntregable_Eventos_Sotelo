using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosDepositos_PE
{
    public class ProductoAgregadoModificadoEventsArgs : EventArgs
    {
        public bool Ultimo { get; set; }
        public string Descripcion { get; set; }
        public int cantidadMonitores { get; set; }
        public int cantidadComputadoras { get; set; }
        public double porcentajeMonitores { get; set; }
        public double porcentajeComputadoras { get; set; }
        public ProductoAgregadoModificadoEventsArgs(bool ultimo, string descripcion,int cantidadMonitores, int cantidadComputadoras, double porcentajeMonitores, double porcentajeComputadoras)
        {
            this.Ultimo = ultimo;
            this.cantidadMonitores = cantidadMonitores;
            this.cantidadComputadoras = cantidadComputadoras;
            this.porcentajeMonitores = porcentajeMonitores;
            this.porcentajeComputadoras = porcentajeComputadoras;
            this.Descripcion = descripcion;
        }   
    }
}
