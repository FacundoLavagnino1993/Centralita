using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_52
{
    public class Local:Llamada
    {
        protected float _costo;

        public float CostoLlamada
        {
            get { return this.CalcularCosto(); }
        }

        private float CalcularCosto()
        {
            float precioFinal;
            precioFinal = this._duracion * this._costo;
            return precioFinal;
        }

        public Local()
        { }

        public Local(Llamada unaLlamada, float costo)
        {
            this._costo = costo;
        }

        public Local(string origen, float duracion, string destino, float costo):base(origen, destino, duracion)
        {
            this._costo = costo;
        }

        

        public void Mostrar()
        {
            base.Mostrar();
            StringBuilder texto = new StringBuilder();
            texto.AppendLine("\nCosto de la llamada : " + this.CostoLlamada);
            Console.WriteLine(texto);
        }
    }
}
