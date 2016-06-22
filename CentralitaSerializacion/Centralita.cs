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
    public class Centralita:ISerializable   
    {
        
        private List<Llamada> _listaDeLlamadas;
        private string _razonSocial;
        private string _ruta;


       
        public float GananciaPorLocal
        {
            get { return this.CalcularGanancia(TipoLlamada.Local); }
        }

        public float GananciaPorProvincial
        {
            get { return this.CalcularGanancia(TipoLlamada.Provincial); }
        }

        public float GananciaTotal
        {
            get { return this.CalcularGanancia(TipoLlamada.Todas); }
        }

        public List<Llamada> Llamadas
        {
            get { return this._listaDeLlamadas; }
            set { this._listaDeLlamadas = value; }
        }

        public string RazonSocial
        {
            get { return this._razonSocial; }
            set { this._razonSocial = value; }
        }

        public string RutaDeArchivo
        {
            get { return this._ruta; }
            set { this._ruta = value; }
        }

        public Centralita()
        {
            
        }

        public Centralita(string nombreEmpresa)
            : this()
        {
            this._razonSocial = nombreEmpresa;
            this._listaDeLlamadas = new List<Llamada>();
        }

        
        private void AgregarLlamada(Llamada nuevaLlamada)
        {
            this._listaDeLlamadas.Add(nuevaLlamada);
        }

        private float CalcularGanancia(TipoLlamada tipo)
        {
            float ganancia = 0;

            if (tipo == TipoLlamada.Todas)
            {
                for (int i = 0; i < this._listaDeLlamadas.Count; i++)
                {
                    if (this._listaDeLlamadas[i] is Local)
                    {
                        ganancia += ((Local)this._listaDeLlamadas[i]).CostoLlamda;
                        // gananciaLocal += ((Local)this._listaDeLlamadas[i]).CostoLlamada;
                    }
                    else
                    {
                        ganancia += ((Provincial)this._listaDeLlamadas[i]).CostoLlamda;
                        // gananciaProvincial += ((Provincial)this._listaDeLlamadas[i]).CostoLlamada;
                    }
                }

            }
            else if (tipo == TipoLlamada.Local)
            {
                for (int i = 0; i < this._listaDeLlamadas.Count; i++)
                {
                    if (this._listaDeLlamadas[i] is Local)
                    {
                        ganancia += ((Local)this._listaDeLlamadas[i]).CostoLlamda;
                        // gananciaLocal += ((Local)this._listaDeLlamadas[i]).CostoLlamada;
                    }
                }
            }
            else if (tipo == TipoLlamada.Provincial)
            {
                for (int i = 0; i < this._listaDeLlamadas.Count; i++)
                {
                    if (this._listaDeLlamadas[i] is Provincial)
                    {
                        ganancia += ((Provincial)this._listaDeLlamadas[i]).CostoLlamda;
                        // gananciaLocal += ((Local)this._listaDeLlamadas[i]).CostoLlamada;
                    }
                }
            }
            return ganancia;
        }

        public void OrdenarLlamadas()
        {
            this._listaDeLlamadas.Sort(Llamada.OrdenarPorDuracion);
        }

        public override string ToString()
        {
            StringBuilder Muestreo = new StringBuilder();

            Muestreo.AppendLine("Razon social: " + this._razonSocial)
                .AppendLine("Ganancia total: " + this.GananciaTotal)
                .AppendLine("Ganancia por Local: " + this.GananciaPorLocal)
                .AppendLine("Ganancia por Provincial: " + this.GananciaPorProvincial);

            Muestreo.AppendLine("---Detalle de llamada---");

            for (int i = 0; i < this._listaDeLlamadas.Count; i++)
            {
                if (this._listaDeLlamadas[i] is Local)
                {
                    Muestreo.AppendLine(((Local)this._listaDeLlamadas[i]).ToString());
                    
                    }
                else
                {
                    Muestreo.AppendLine(((Provincial)this._listaDeLlamadas[i]).ToString());
                }
            }

            return Muestreo.ToString();
        }

       
        public static bool operator !=(Centralita central, Llamada nuevaLlamada)
        {
            return !(central == nuevaLlamada);
        }

        public static Centralita operator +(Centralita central, Llamada nuevaLlamada)
        {
            
                


                    if (central != nuevaLlamada)
                    {
                        central.AgregarLlamada(nuevaLlamada);
                    }
                    else
                    {
                        Console.WriteLine("La llamada ya se encuentra en la lista!!!");
                    }
                
            
            return central;
        }

        public static bool operator ==(Centralita central, Llamada nuevaLlamada)
        {
            bool rta = false;

            foreach (Llamada item in central._listaDeLlamadas)
            {
                if (item == nuevaLlamada)
                {
                    rta = true;
                }
            }

            return rta;
        }


        public bool serializarse()
        {
            bool rta = false;
            try
            {
                using(XmlTextWriter escritura = new XmlTextWriter(this.RutaDeArchivo ,Encoding.UTF8))
                {
                    XmlSerializer serializar = new XmlSerializer(typeof(Centralita));
                    serializar.Serialize(escritura, this);
                    rta = true;
                }
            }
            catch //(Exception ex)
            {
                throw new CentralitaException("No se pudo serializar", "\nMetodo x", " Clase : Centralita");
            }

            try
            {
                using (XmlTextWriter escritura = new XmlTextWriter(this.RutaDeArchivo, Encoding.UTF8))
                {
                    XmlSerializer serializar = new XmlSerializer(typeof(List<Llamada>));
                    serializar.Serialize(escritura, Llamadas);
                    rta = true;
                }
            }
            catch //(Exception ex)
            {
                throw new CentralitaException("No se pudo serializar", "\nMetodo x", " Clase : Llamada");
            }

            return rta;
            
        }

        public bool DeSeralizarse()
        {
            bool rta = false;

            try 
            {
                using(XmlTextReader lector = new XmlTextReader(this.RutaDeArchivo))
                {
                    XmlSerializer deserializar = new XmlSerializer(typeof(Centralita));
                    deserializar.Deserialize(lector);
                    rta = true;
                }
            }
            catch //(Exception ex)
            {
                throw new CentralitaException("No se pudo deserializar", "\nMetodo x", " Clase : Centralita");
            }

            try
            {
                using (XmlTextReader lector = new XmlTextReader(this.RutaDeArchivo))
                {
                    XmlSerializer deserializar = new XmlSerializer(typeof(List<Llamada>));
                    deserializar.Deserialize(lector);
                    rta = true;
                }
            }
            catch //(Exception ex)
            {
                throw new CentralitaException("No se pudo deserializar", "\nMetodo x", " Clase : Llamada");
            }

            return rta;
        }

        public bool GuardarEnArchivo(Llamada unaLlamada, bool agrego)
        {
            bool rta = false;

            try 
            {
                using (StreamWriter escribir = new StreamWriter(this.RutaDeArchivo, agrego))
                    escribir.WriteLine(unaLlamada.ToString());
                rta = true;
            }
            catch
            {
                throw new CentralitaException("No se pudo guardar txt", "\nMetodo x", " Clase : Llamada");
            }

            return rta;
        }

    }
}
