using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_52
{
    enum TipoLlamada
    {
        Local, Provincial, Todas,
    }
    public class Provincial:Llamada
    {
        public  Franja _franjaHoraria = 0;
      
        
        public Provincial()
        { }

        public Provincial(Franja miFranja, Llamada unaLlamada)
        { }

        public Provincial(string origen, Franja miFranja, float duracion, string destino):base(origen,destino,duracion)
        { }

        public float CostoLlamada
        {
            get { return this.calcularCosto(); }
        }


        private float calcularCosto()
        {
            float valor = 0;
            if (this._franjaHoraria == Franja.Franja_1)
            { valor = this.Duracion * 0.99f; }

            if (this._franjaHoraria == Franja.Franja_2)
            { valor = this.Duracion * 1.25f; }

            if (this._franjaHoraria == Franja.Franja_3)
            { valor = this.Duracion * 0.66f; }

            return valor;
        }

        public void Mostrar()
        {
            base.Mostrar();
            StringBuilder texto = new StringBuilder("\nFranja : " + this._franjaHoraria + "\tCosto de la llamada : " + this.CostoLlamada);
        }
            
    }
}
