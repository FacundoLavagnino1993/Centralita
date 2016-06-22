using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaPolimorfismo
{
    class Program
    {
        static void Main(string[] args)
        {

            Centralita MiCentral = new Centralita("Telefonica");
            Local LlamadaUno = new Local("Avellaneda", 30f, "Lanus", 2.65f);
            Provincial LlamadaDos = new Provincial("Rosario", Franja.Franja_1, 21f, "Catamarca");

            Local LlamadaTres = new Local("Ezpeleta", 45f, "Avellaneda", 1.99f);
            Provincial LlamadaCuatro = new Provincial("Jujuy",Franja.Franja_3, 15f,"La Pampa");

            MiCentral += LlamadaUno;
            MiCentral += LlamadaDos;
            MiCentral += LlamadaTres;
            MiCentral += LlamadaCuatro;

            


            Console.WriteLine(MiCentral.ToString());

            Console.WriteLine("\nOrdenamos Las Llamadas.");

            Console.WriteLine(MiCentral.ToString());

            Console.ReadKey();
        }
    }
}
