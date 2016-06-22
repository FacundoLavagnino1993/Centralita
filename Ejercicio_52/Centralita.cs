using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_52
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

        public List<Llamada> Lista
        {
            get { return this._listaDeLlamadas; }
        }

        private float CalcularGanancia(TipoLlamada tipo)
        {
            float ganancia = 0;
            
            if(tipo == TipoLlamada.Todas)
            {
                for (int i = 0; i < this._listaDeLlamadas.Count; i++)
                {
                    if(this._listaDeLlamadas[i] is Local)
                    {
                        ganancia += ((Local)this._listaDeLlamadas[i]).CostoLlamada;
                       // gananciaLocal += ((Local)this._listaDeLlamadas[i]).CostoLlamada;
                    }
                    else
                    {
                        ganancia += ((Provincial)this._listaDeLlamadas[i]).CostoLlamada;
                       // gananciaProvincial += ((Provincial)this._listaDeLlamadas[i]).CostoLlamada;
                    }
                }
                
            }else if(tipo == TipoLlamada.Local)
            {
                for (int i = 0; i < this._listaDeLlamadas.Count; i++)
                {
                    if (this._listaDeLlamadas[i] is Local)
                    {
                        ganancia += ((Local)this._listaDeLlamadas[i]).CostoLlamada;
                        // gananciaLocal += ((Local)this._listaDeLlamadas[i]).CostoLlamada;
                    }
                }
            }else if(tipo == TipoLlamada.Provincial)
            {
                for (int i = 0; i < this._listaDeLlamadas.Count; i++)
                {
                    if (this._listaDeLlamadas[i] is Provincial)
                    {
                        ganancia += ((Provincial)this._listaDeLlamadas[i]).CostoLlamada;
                        // gananciaLocal += ((Local)this._listaDeLlamadas[i]).CostoLlamada;
                    }
                }
            }
            return ganancia;
        }

        public Centralita()
        { }

        public Centralita(string nombreEmpresa)
        {
            this._razonSocial = nombreEmpresa;
            _listaDeLlamadas = new List<Llamada>();
        }

        public void Mostrar()
        {
            StringBuilder Final = new StringBuilder();

            Final.AppendLine("Razon Social: " + this._razonSocial)
                .AppendLine("\nGanancia Total: " + this.GananciaTotal)
                .AppendLine("\nGanancia Llamadas Locales: " + this.GananciaPorLocal)
                .AppendLine("\nGanancia por llamadas provinciales: " + this.GananciaPorProvincial);

            Console.WriteLine("\n---Detalles de llamadas---");
            Console.WriteLine(Final.ToString());

            for (int i = 0; i < this._listaDeLlamadas.Count; i++)
            {
                if (this._listaDeLlamadas[i] is Local)
                {
                    ((Local)this._listaDeLlamadas[i]).Mostrar();
                }
                else
                {
                    ((Provincial)this._listaDeLlamadas[i]).Mostrar();
                }
            }
        }

        public void OrdenarLlamadas()
        {
            this._listaDeLlamadas.Sort(Llamada.OrdenarPorDuracion);
        }
    }
}
