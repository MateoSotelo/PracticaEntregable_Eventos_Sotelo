namespace EntidadesDepositos_PE
{
    public class Elemento
    {
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int NumeroDeSerie { get; set; }
        public string Identificador { get { return $"{Modelo}-{Marca}-{NumeroDeSerie.ToString()}"; } }
    }
}