using EntidadesDepositos_PE;
using Newtonsoft.Json;


namespace PersistenciaDepositos_PE
{
    public class Principal
    {
        const string path = @"C:\Users\msote\OneDrive\Escritorio\ListasJson\";
        public void GuardarListadoComputadoras(List<Computadora> computadoras)
        {
            if (!File.Exists(path + "computadoras.txt"))
            {
                File.Create(path + "computadoras.txt");
                using (StreamWriter writer = new StreamWriter(path + "computadoras.txt", false))
                {
                    string json = JsonConvert.SerializeObject(computadoras);
                    writer.Write(json);
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(path + "computadoras.txt", false))
                {
                    string json = JsonConvert.SerializeObject(computadoras);
                    writer.Write(json);
                }
            }
        }
        public List<Computadora> LeerListadoComputadoras()
        {
            List<Computadora> computadoras = new List<Computadora>();
            if (File.Exists(path + "computadoras.txt"))
            {
                using (StreamReader reader = new StreamReader(path + "computadoras.txt"))
                {
                    string jsonComputadoras = reader.ReadToEnd();
                    if (jsonComputadoras != "")
                    {
                        computadoras = JsonConvert.DeserializeObject<List<Computadora>>(jsonComputadoras);
                    }
                }
            }
            return computadoras;
        }
        public void GuardarListadoMonitores(List<Pantalla> monitores)
        {
            if (!File.Exists(path + "monitores.txt"))
            {
                File.Create(path + "monitores.txt");
                using (StreamWriter writer = new StreamWriter(path + "monitores.txt", false))
                {
                    string json = JsonConvert.SerializeObject(monitores);
                    writer.Write(json);
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(path + "monitores.txt", false))
                {
                    string json = JsonConvert.SerializeObject(monitores);
                    writer.Write(json);
                }
            }
        }
        public List<Pantalla> LeerListadoMonitores()
        {
            List<Pantalla> monitores = new List<Pantalla>();
            if (File.Exists(path + "monitores.txt"))
            {
                using (StreamReader reader = new StreamReader(path + "monitores.txt"))
                {
                    string jsonMonitores = reader.ReadToEnd();
                    if (jsonMonitores != "")
                    {
                        monitores = JsonConvert.DeserializeObject<List<Pantalla>>(jsonMonitores);
                    }
                }
            }
            return monitores;
        }
    }
}