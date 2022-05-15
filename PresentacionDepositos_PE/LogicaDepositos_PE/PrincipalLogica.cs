using PersistenciaDepositos_PE;
using EntidadesDepositos_PE;
using EventosDepositos_PE;

namespace LogicaDepositos_PE
{
    public class PrincipalLogica
    {
        public EventHandler<ProductoAgregadoEliminadoEventsArgs> productoAgregadoEliminadoHandler;
        public void AgregarElemento(string modelo, string marca, int numeroDeSerie, short añoFabricacion, int? pulgadas)
        {
            Pantalla pantalla = new Pantalla(modelo, marca, numeroDeSerie, añoFabricacion, pulgadas);
            SingletonListas.Instancia.pantallas.Add(pantalla);

            this.productoAgregadoEliminadoHandler(this, new ProductoAgregadoEliminadoEventsArgs("Monitor", pantalla.Identificador));
        }
        public void AgregarElemento(string modelo, string marca, int numeroDeSerie, string descripcionProcesador, byte numMemoriaRAM, string fabricante)
        {
            Computadora computadora = new Computadora(modelo, marca, numeroDeSerie, descripcionProcesador, numMemoriaRAM.ValidarRAM(), fabricante);
            SingletonListas.Instancia.computadoras.Add(computadora);

            this.productoAgregadoEliminadoHandler(this, new ProductoAgregadoEliminadoEventsArgs("Computadora", computadora.Identificador));
        }
        public bool EliminarElemento(string ID)
        {
            if (SingletonListas.Instancia.computadoras.Find(x => x.Identificador == ID) != null)
            {
                SingletonListas.Instancia.computadoras.RemoveAll(x => x.Identificador == ID);
                this.productoAgregadoEliminadoHandler(this, new ProductoAgregadoEliminadoEventsArgs("Computadora", ID));

                return true;
            }
            else
            {
                if (SingletonListas.Instancia.pantallas.Find(x => x.Identificador == ID) != null)
                {
                    SingletonListas.Instancia.pantallas.RemoveAll(x => x.Identificador == ID);
                    this.productoAgregadoEliminadoHandler(this, new ProductoAgregadoEliminadoEventsArgs("Monitor", ID));

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

            elementos = elementos.OrderBy(x => x.Identificador).ToList();

            foreach (Elemento elemento in elementos)
            {
                elementosString.Add($"{elemento.Identificador}");
            }

            return elementosString;
        }
    }
}