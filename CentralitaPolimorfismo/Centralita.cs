using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaPolimorfismo
{
    public class Centralita
    {
        
        private List<Llamada> _listaDeLlamadas;
        protected string _razonSocial;

       
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
        }

        
        public Centralita()
        {
            this._listaDeLlamadas = new List<Llamada>();
        }

        public Centralita(string nombreEmpresa)
            : this()
        {
            this._razonSocial = nombreEmpresa;
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
    }
}
