using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_52
{
    class Program
    {
        static void Main(string[] args)
        {
            Centralita centralita = new Centralita("Telefonica");
            Local unaLlamada = new Local("Quilmes", 30f, "Avellaneda", 0.98f);
            Provincial dosLlamada = new Provincial("Cordoba", Franja.Franja_1, 21f, "Santa Fe");
            Local tresLlamada = new Local("Bernal", 45f, "Termperley", 0.98f);
            Provincial cuatroLlamada = new Provincial("Buenos Aires",Franja.Franja_3, 14f, "Tucuman");

            //Cargamos la lista
            centralita.Lista.Add(unaLlamada);
            centralita.Lista.Add(dosLlamada);
            centralita.Lista.Add(tresLlamada);
            centralita.Lista.Add(cuatroLlamada);

            //Mostramos el contenido
            centralita.Mostrar();

            //Ordenamos la lista y la mostramos
            centralita.OrdenarLlamadas();

            Console.WriteLine("------ Lista ordenada -------");
            centralita.Mostrar();

            Console.ReadLine();
            
            
            
        }
    }
}
