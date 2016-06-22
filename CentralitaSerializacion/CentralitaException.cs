using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentralitaSerializacion
{
    class CentralitaException:Exception
    {
        protected Exception _exceptionInterna;
        protected string _nombreClase;
        protected string _nombreMetodo;

        public Exception ExceptionInterna
        {
            get { return this._exceptionInterna; }
        }
        
        public string NombreClase
        {
            get { return this._nombreClase; }
        }

        public string NombreMetodo
        {
            get { return this._nombreMetodo; }
        }

        public CentralitaException(string mensaje, string metodo, string clase)
            : base(mensaje)
        {
            this._nombreClase = clase;
            this._nombreMetodo = metodo;
        }

        public CentralitaException(string mensaje, string metodo, string clase, Exception InnerException):base(mensaje,InnerException)
        {
            this._nombreClase = clase;
            this._nombreMetodo = metodo;
        }

       
    }
}
