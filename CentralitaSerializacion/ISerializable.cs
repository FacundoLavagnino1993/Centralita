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
    interface ISerializable
    {
        string RutaDeArchivo
        {
            get;
            set;
        }

        bool serializarse();
        bool DeSeralizarse();

    }
}
