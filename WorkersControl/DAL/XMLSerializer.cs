using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WorkersControl
{

    public class XMLSerializer
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Worker));

        FileStream fs = new FileStream("worker.xml", FileMode.OpenOrCreate);

        public void Serializer(Worker worker) => xmlSerializer.Serialize(fs, worker);


    }
 
}
