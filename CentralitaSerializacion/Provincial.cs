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
    [Serializable]
        public enum TipoLlamada
        {
            Local, Provincial, Todas,
        }

        public class Provincial : Llamada
        {
            protected Franja _franjaHoraria = 0;


            public Provincial()
            { }

            public Provincial(Franja miFranja, Llamada unaLlamada)
            { }

            public Provincial(string origen, Franja miFranja, float duracion, string destino):base(origen,destino,duracion)
            { }

            public override float CostoLlamda
            {
                get { return this.calcularCosto(); }
            }


            private float calcularCosto()
            {
                float valor = 0;
                if(this._franjaHoraria == Franja.Franja_1)
                { valor = this.Duracion * 0.99f; }

                if(this._franjaHoraria == Franja.Franja_2)
                { valor = this.Duracion * 1.25f; }

                if(this._franjaHoraria == Franja.Franja_3)
                { valor = this.Duracion * 0.66f; }
                
                return valor;
            }

            protected override string Mostrar()
            {
                StringBuilder texto = new StringBuilder();
                texto.AppendLine(base.Mostrar())
                    .AppendLine("Franja horaria: " + this._franjaHoraria)
                    .AppendLine("Costo de la llamada: " + this.CostoLlamda);

                return texto.ToString();
            }

            public bool Equals(Provincial P)
            {
                bool rta = false;
                if(P is Provincial)
                {
                    rta = true;
                }
                return rta;
            }

            public string ToString()
            {
                return this.Mostrar();
            }

        }
}

