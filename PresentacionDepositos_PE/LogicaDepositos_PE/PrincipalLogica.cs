
using EntidadesDepositos_PE;

namespace LogicaDepositos_PE
{
    public class PrincipalLogica
    {
        public void AgregarElemento(string modelo, string marca, int numeroDeSerie, short añoFabricacion, int? pulgadas)
        {
            Pantalla pantalla = new Pantalla(modelo, marca, numeroDeSerie, añoFabricacion, pulgadas);
            SingletonListas.Instancia.pantallas.Add(pantalla);
        }
        public void AgregarElemento(string modelo, string marca, int numeroDeSerie, string descripcionProcesador, tipoMemoriaRAM memoriaRAM, string fabricante)
        {
            Computadora computadora = new Computadora(modelo, marca, numeroDeSerie, descripcionProcesador, memoriaRAM, fabricante);
            SingletonListas.Instancia.computadoras.Add(computadora);
        }
        public bool EliminarElemento(string ID)
        {
            if (SingletonListas.Instancia.computadoras.Find(x => x.Identificacor == ID) != null)
            {
                SingletonListas.Instancia.computadoras.RemoveAll(x => x.Identificacor == ID);
                return true;
            }
            else
            {
                if (SingletonListas.Instancia.pantallas.Find(x => x.Identificacor == ID) != null)
                {
                    SingletonListas.Instancia.pantallas.RemoveAll(x => x.Identificacor == ID);
                    return true;
                }
            }

            return false;
        }
        public List<string> ObtenerDescripcionElementos()
        {
            List<string> Descripciones = new List<string>();

            foreach (Computadora computadora in SingletonListas.Instancia.computadoras)
            {
                Descripciones.Add(computadora.Desribirse());
            }
            foreach (Pantalla pantalla in SingletonListas.Instancia.pantallas)
            {
                Descripciones.Add(pantalla.Desribirse());
            }

            return Descripciones;
        }
    }
}