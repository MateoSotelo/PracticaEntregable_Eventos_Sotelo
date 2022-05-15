
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
        public void AgregarElemento(string modelo, string marca, int numeroDeSerie, string descripcionProcesador, byte numMemoriaRAM, string fabricante)
        {
            Computadora computadora = new Computadora(modelo, marca, numeroDeSerie, descripcionProcesador, numMemoriaRAM.ValidarRAM(), fabricante);
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
                Descripciones.Add(computadora.Describirse());
            }
            foreach (Pantalla pantalla in SingletonListas.Instancia.pantallas)
            {
                Descripciones.Add(pantalla.Describirse());
            }

            return Descripciones;
        }

        public List<Elemento> ObtenerListaElementos()
        {
            List<Elemento> elementos = new List<Elemento>();

            foreach (Pantalla pantalla in SingletonListas.Instancia.pantallas)
            {
                elementos.Add(pantalla);
            }
            foreach (Computadora computadora in SingletonListas.Instancia.computadoras)
            {
                elementos.Add(computadora);
            }

            return elementos;
        }
        public List<string> OrdenarListaPorTipoProducto()
        {
            List<string> elementosString = new List<string>();
            List<Elemento> elementos = ObtenerListaElementos();

            elementos.Sort();

            foreach (Elemento elemento in elementos)
            {
                elementosString.Add($"{elemento.Identificacor}");
            }

            return elementosString;
        }
    }
}