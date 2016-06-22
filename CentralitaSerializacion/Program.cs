using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
namespace CentralitaSerializacion
{
    public class Program
    {
        static void Main(string[] args)
        {
            Centralita MiCentral = new Centralita("Telefonica");

            Local LlamadaUno = new Local("Avellaneda", 0.30f, "Lanus", 2.65f);
            Provincial LlamadaDos = new Provincial("Rosario", Franja.Franja_1, 0.21f, "San Juan");
            Local LlamadaTres = new Local("Quilmes", 0.45f, "Gerli", 1.99f);
            Provincial LlamadaCuatro = new Provincial(Franja.Franja_2, LlamadaDos);

            MiCentral += LlamadaUno;
            MiCentral += LlamadaDos;
            MiCentral += LlamadaTres;
            MiCentral += LlamadaCuatro;

            
            MiCentral.RutaDeArchivo = "Centralita.xml";
            bool serializo = MiCentral.serializarse();
            bool guardo = MiCentral.GuardarEnArchivo(LlamadaUno, true);
            
            
            


            Console.ReadKey();

        }
    }
}
