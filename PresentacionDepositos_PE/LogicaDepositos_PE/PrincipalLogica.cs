using PersistenciaDepositos_PE;
using EntidadesDepositos_PE;
using EventosDepositos_PE;

namespace LogicaDepositos_PE
{
   
    public class PrincipalLogica
    {
        public EventHandler<ProductoAgregadoEliminadoEventsArgs> productoAgregadoEliminadoHandler;
        public EventHandler<ProductoAgregadoModificadoEventsArgs> productoAgregadoModificadoHandler;
        Principal persistencia = new Principal();

        public void GuardarListados()
        {
            persistencia.GuardarListadoComputadoras(SingletonListas.Instancia.computadoras);
            persistencia.GuardarListadoMonitores(SingletonListas.Instancia.pantallas);
        }
        public void ActualizarListados()
        {
            SingletonListas.Instancia.computadoras = persistencia.LeerListadoComputadoras();
            SingletonListas.Instancia.pantallas = persistencia.LeerListadoMonitores();
        }
        public void AgregarElemento(string modelo, string marca, int numeroDeSerie, short añoFabricacion, int? pulgadas)
        {
            Pantalla pantalla = new Pantalla(modelo, marca, numeroDeSerie, añoFabricacion, pulgadas);

            ActualizarListados();
            SingletonListas.Instancia.pantallas.Add(pantalla);
            
            this.productoAgregadoEliminadoHandler(this, new ProductoAgregadoEliminadoEventsArgs("Monitor", pantalla.Identificador));
            GuardarListados();
        }
        public void AgregarElemento(string modelo, string marca, int numeroDeSerie, string descripcionProcesador, byte numMemoriaRAM)
        {
            Computadora computadora = new Computadora(modelo, marca, numeroDeSerie, descripcionProcesador, numMemoriaRAM.ValidarRAM());

            ActualizarListados();

            if (computadora.MemoriaRAM != tipoMemoriaRAM.Invalido)
            {
                SingletonListas.Instancia.computadoras.Add(computadora);
                this.productoAgregadoEliminadoHandler(this, new ProductoAgregadoEliminadoEventsArgs("Computadora", computadora.Identificador));
                GuardarListados();
            }
            else
            {
                throw new Exception("Memoria RAM invalida");
            }   

        }
        public bool EliminarElemento(string ID)
        {
            ActualizarListados();

            if (SingletonListas.Instancia.computadoras.Find(x => x.Identificador == ID) != null)
            {
                SingletonListas.Instancia.computadoras.RemoveAll(x => x.Identificador == ID);
                this.productoAgregadoEliminadoHandler(this, new ProductoAgregadoEliminadoEventsArgs("Computadora", ID));
                GuardarListados();

                return true;
            }
            else
            {
                if (SingletonListas.Instancia.pantallas.Find(x => x.Identificador == ID) != null)
                {
                    SingletonListas.Instancia.pantallas.RemoveAll(x => x.Identificador == ID);
                    this.productoAgregadoEliminadoHandler(this, new ProductoAgregadoEliminadoEventsArgs("Monitor", ID));
                    GuardarListados();

                    return true;
                }
            }

            return false;
        }
        public List<string> ObtenerDescripcionElementos()
        {
            List<string> Descripciones = new List<string>();

            ActualizarListados();

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
            ActualizarListados();

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
        public void OrdenarListaPorTipoProducto()
        {
            List<string> elementosString = new List<string>();
            List<Elemento> elementos = ObtenerListaElementos();

            elementos = elementos.OrderBy(x => x.Identificador).ToList();

            foreach (Elemento elemento in elementos)
            {
                elementosString.Add(elemento.Identificador);
            }

            int cantidadMonitores = SingletonListas.Instancia.pantallas.Count();
            int cantidadComputadoras = SingletonListas.Instancia.computadoras.Count();

            for (int i = 0; i < elementos.Count; i++)
            {
                bool Ultimo = i == elementos.Count() - 1? true: false;
                this.productoAgregadoModificadoHandler(this, new ProductoAgregadoModificadoEventsArgs(Ultimo, elementosString[i],cantidadMonitores, cantidadComputadoras, (double)cantidadMonitores / (double)elementos.Count(), (double)cantidadComputadoras / (double)elementos.Count()));
            }

        }
    }
}