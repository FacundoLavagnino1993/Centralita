using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_52
{
    public class Llamada
    {
        protected float _duracion;
        protected string _nroDestino;
        protected string _nroOrigen;

        public float Duracion
        {
            get { return this._duracion; }
        }

        public string NroDestino
        {
            get { return this._nroDestino; }
        }

        public string NroOrigen
        {
            get { return this._nroOrigen; }
        }

        public Llamada()
        { }
        public Llamada(string origen, string destino, float duracion)
        {
            this._nroOrigen = origen;
            this._nroDestino = destino;
            this._duracion = duracion;
        }

        public void Mostrar()
        {
            StringBuilder texto = new StringBuilder("\nTel Origen : " + this.NroOrigen + "|| Tel Destino : " + this.NroDestino + "|| Duracion : " + this.Duracion);
            Console.WriteLine(texto);
        }

        
        public static int OrdenarPorDuracion(Llamada uno, Llamada dos)
        { 
            //Consultar si este metodo debe ordenar por mayor a menor, y que debe devolver exactamente.
            return dos.Duracion.CompareTo(uno.Duracion);
        }
    }
}
