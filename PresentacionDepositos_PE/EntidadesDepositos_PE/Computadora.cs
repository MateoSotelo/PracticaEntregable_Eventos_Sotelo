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
        public string Fabricante { get; set; }
        public Computadora(string modelo, string marca, int numeroDeSerie, string descripcionProcesador, tipoMemoriaRAM memoriaRAM, string fabricante)
        {
            this.Modelo = modelo;
            this.Marca = marca;
            this.NumeroDeSerie = numeroDeSerie;
            this.DescripcionProcesador = descripcionProcesador;
            this.MemoriaRAM = memoriaRAM;
            this.Fabricante = fabricante;
        }
        public string Describirse()
        {
            return $"COMPUTADORA {Modelo}-{Marca}-{DescripcionProcesador} {MemoriaRAM.ToString()}-{Fabricante}";
        }
    }
}
