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
    [XmlInclude(typeof(Local))]
    [XmlInclude(typeof(Provincial))]

    public abstract class Llamada
    {
        

        protected float _duracion;
        protected string _nroDestino;
        protected string _nroOrigen;

        public abstract float CostoLlamda
        { get; }
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

        protected virtual string Mostrar()
        {
            StringBuilder texto = new StringBuilder();
            texto.AppendLine("Duracion: " + this._duracion)
                .AppendLine("Destino: " + this._nroDestino)
                .AppendLine("Origen: " + this._nroOrigen);

            return texto.ToString();   
            
        }

        
        public static int OrdenarPorDuracion(Llamada uno, Llamada dos)
        { 
            //Consultar si este metodo debe ordenar por mayor a menor, y que debe devolver exactamente.
            return dos.Duracion.CompareTo(uno.Duracion);
        }

       

        public static bool operator ==(Llamada uno, Llamada dos)
        {
            bool rta = false;

            if ((uno._nroOrigen == dos._nroOrigen) && (uno._nroDestino == dos._nroDestino) && (uno.Equals(dos)))
                rta = true;

            return rta;
        }

        public static bool operator !=(Llamada uno, Llamada dos)
        {
            return !(uno == dos);
        }

     }


}

 

