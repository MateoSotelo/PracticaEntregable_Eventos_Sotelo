using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesDepositos_PE
{
    public enum tipoMemoriaRAM { DosGb, CuatroGb, OchoGb, DieciseisGb, Invalido}
    public class Computadora : Elemento, IDescriptible
    {
        public string DescripcionProcesador { get; set; }
        public tipoMemoriaRAM MemoriaRAM { get; set; }
        public Computadora(string modelo, string marca, int numeroDeSerie, string descripcionProcesador, tipoMemoriaRAM memoriaRAM)
        {
            this.Modelo = modelo;
            this.Marca = marca;
            this.NumeroDeSerie = numeroDeSerie;
            this.DescripcionProcesador = descripcionProcesador;
            this.MemoriaRAM = memoriaRAM;
        }
        public string Describirse()
        {
            return $"COMPUTADORA {Modelo}-{Marca}-{DescripcionProcesador} {MemoriaRAM.ToString()}";
        }
    }
}
