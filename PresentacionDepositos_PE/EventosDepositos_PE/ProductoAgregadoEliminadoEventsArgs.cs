namespace EventosDepositos_PE
{
    public class ProductoAgregadoEliminadoEventsArgs : EventArgs
    {
        public string tipoProducto { get; set; }
        public string ID { get; set; }
        public ProductoAgregadoEliminadoEventsArgs(string tipoProducto, string iD)
        {
            this.tipoProducto = tipoProducto;
            ID = iD;
        }   
    }
}