using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesDepositos_PE
{
    public static class ExtensionesRAM
    {
        public static tipoMemoriaRAM ValidarRAM(this byte RAM)
        {
            switch (RAM)
            {
                case 2:
                    return tipoMemoriaRAM.DosGb;
                case 4:
                    return tipoMemoriaRAM.CuatroGb;
                case 8:
                    return tipoMemoriaRAM.OchoGb;
                case 16:
                    return tipoMemoriaRAM.DieciseisGb;
            }

            return tipoMemoriaRAM.Invalido;
        }
    }
}
