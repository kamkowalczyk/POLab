using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace kursyNBP
{
    public class NBP { 
    public List<XDocument> document(/*string */)
    {
        WebClient client = new WebClient();

        client.Headers.Add("Accept", "application/json");
        var link = client.DownloadString($"https://www.nbp.pl/kursy/xml/dir.aspx?tt=C");

        List<string> list = new List<string>();
        var splittedLink = link.Split("<pre")[1].Split("<a href=\"");


        return new List<XDocument>() { };
    }
}
}
