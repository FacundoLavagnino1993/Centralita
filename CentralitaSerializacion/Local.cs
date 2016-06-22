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
        public class Local : Llamada
        {

            //protected float _costo;
            protected float _costo;
            public override float CostoLlamda
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

            public Local(string origen, float duracion, string destino, float costo)
                : base(origen, destino, duracion)
            {
                this._costo = costo;
            }

            public bool equals(Local L)
            {
                bool rta = false;
                if (L is Local)
                {
                    rta = true;
                }
                return rta;
            }

            protected override string Mostrar()
            {
                StringBuilder texto = new StringBuilder();
                texto.AppendLine(base.Mostrar())
                    .AppendLine("Costo de llamada: " + this.CostoLlamda);
                return texto.ToString();
            }

            public string ToString()
            {
                return this.Mostrar();
            }
            
        }
    
}
