using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace MigracjaDanychViaXML
{
    public class ExportImport
    {
      

        public ExportImport(string path)
        {
            XDocument oldDocument = XDocument.Load(path);
            CreateArticle(oldDocument);
        }

        public void CreateArticle(XDocument oldDocument)
        {
       
            XNamespace _schemaLocation = "http://pkp.sfu.ca";
            XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";

            string number = Convert.ToInt32(oldDocument.Element("issues").Element("issue").Element("number").Value.Split("(")[0]).ToString();
            string abbrev = oldDocument.Element("issues").Element("issue").Element("section").Element("abbrev").Value.ToString();
            string datePublish = oldDocument.Element("issues").Element("issue").Element("date_published").Value;
            string locale;
            string[] tags;
            string myPrefix;



            string doi;
            int count = 0;




      
            List<XElement> articles = oldDocument.Descendants("article").ToList();

            foreach (XElement el in articles)
            {
                if (el.Attribute("locale") == new XAttribute("locale", "pl_PL"))
                    articles.Remove(el);
            }

            for (int i = 0; i < articles.Count(); i++)
            {
               
                locale = articles[i].Parent.Parent.Element("cover").Attribute("locale").Value.ToString();
                tags = articles[i].Element("indexing").Element("subject").Value.ToString().Split("; ");
                string[] doiArr = articles[i].Element("galley").Element("file").Element("remote").Attribute("src").Value.Split("-");
                doi = doiArr[1] + doiArr[2];

              
                myPrefix = "";

                string titles = articles[i].Element("title").Value;
                string titlesForm = titles;
                if (titles.Contains("The "))
                {
                    char[] mchar = { 'T', 'h', 'e', ' ' };
                    titlesForm = titles.TrimStart(mchar);
                    myPrefix = "The";
                }
                if (titles.Contains("A "))
                {
                    char[] mchar = { 'A', ' ' };
                    titlesForm = titles.TrimStart(mchar);
                    myPrefix = "A";
                }
                if (titles.Contains("An "))
                {
                    char[] mchar = { 'A', 'n', ' ' };
                    titlesForm = titles.TrimStart(mchar);
                    myPrefix = "An";
                }
                Console.WriteLine(titles);
                Console.WriteLine(titlesForm);
                Console.ReadKey();

              
                XmlDocument document = new XmlDocument();
               
                XmlNode decl = document.CreateXmlDeclaration("1.0", null, null);
                document.AppendChild(decl);

               
                XmlElement Rootarticles = document.CreateElement("articles");
                Rootarticles.SetAttribute("xmlns:xsi", xsi.ToString());
                Rootarticles.SetAttribute("xmlns", _schemaLocation.ToString());
                Rootarticles.SetAttribute("access_status", "0");
                Rootarticles.SetAttribute("seq", "1");
                Rootarticles.SetAttribute("section_ref", abbrev);
                Rootarticles.SetAttribute("date_published", datePublish);
                Rootarticles.SetAttribute("stage", "production");
                Rootarticles.SetAttribute("date_submitted", DateTime.Today.ToString("yyyy-MM-dd"));
                Rootarticles.SetAttribute("locale", locale);

         
                XmlElement id = document.CreateElement("id");
                id.SetAttribute("type", "internal");
                id.SetAttribute("advice", "ignore");
                id.InnerText = doi;
                Rootarticles.AppendChild(id);

             
                XmlElement title = document.CreateElement("title");
                title.SetAttribute("locale", locale);
                title.InnerText = titlesForm;
                Rootarticles.AppendChild(title);

                
                XmlElement prefix = document.CreateElement("prefix");
                prefix.SetAttribute("locale", locale);
                prefix.InnerText = myPrefix;
                Rootarticles.AppendChild(prefix);

               
                XmlElement abstractEl = document.CreateElement("abstract");
                abstractEl.SetAttribute("locale", locale);
                abstractEl.InnerText = articles[i].Element("abstract").Value;
                Rootarticles.AppendChild(abstractEl);

               
                XmlElement licenseUrl = document.CreateElement("licenseUrl");
                licenseUrl.InnerText = "https://creativecommons.org/licenses/by-nc-nd/4.0/";
                Rootarticles.AppendChild(licenseUrl);

              
                XmlElement keywords = document.CreateElement("keywords");
                keywords.SetAttribute("locale", locale);

                foreach (string tag in tags)
                {
                    XmlElement keyword = document.CreateElement("keyword");
                    keyword.InnerText = tag;
                    keywords.AppendChild(keyword);
                }
                Rootarticles.AppendChild(keywords);

              
                XmlElement authors = document.CreateElement("authors");
                XmlAttribute autattr = document.CreateAttribute("xsi:schemaLocation", xsi.NamespaceName);
                autattr.Value = _schemaLocation.NamespaceName + " native.xsd";
                authors.Attributes.Append(autattr);
                authors.SetAttribute("xmlns:xsi", xsi.ToString());

                foreach (XElement author in articles[i].Elements("author"))
                {
                    XmlElement subauthor = document.CreateElement("author");
                    if (!(author.Attribute("primary_contact") is null))
                        subauthor.SetAttribute("primary_contact", author.Attribute("primary_contact").Value);
                    subauthor.SetAttribute("include_in_browse", "true");
                    subauthor.SetAttribute("user_group_ref", "Author");

                    XmlElement givenname = document.CreateElement("givenname");
                    givenname.SetAttribute("locale", locale);
                    givenname.InnerText = author.Element("firstname").Value;
                    subauthor.AppendChild(givenname);

                    XmlElement familyname = document.CreateElement("familyname");
                    familyname.SetAttribute("locale", locale);
                    familyname.InnerText = author.Element("lastname").Value;
                    subauthor.AppendChild(familyname);

                    XmlElement affiliation = document.CreateElement("affiliation");
                    affiliation.SetAttribute("locale", locale);
                    affiliation.InnerText = author.Element("affiliation").Value;
                    subauthor.AppendChild(affiliation);

                    if (!(author.Element("country") is null))
                    {
                        XmlElement country = document.CreateElement("country");
                        country.InnerText = author.Element("country").Value;
                        subauthor.AppendChild(country);
                    }

                    XmlElement email = document.CreateElement("email");
                    email.InnerText = author.Element("email").Value;
                    subauthor.AppendChild(email);

                    authors.AppendChild(subauthor);
                }

                Rootarticles.AppendChild(authors);

               
                XmlElement galley = document.CreateElement("article_galley");
                XmlAttribute galattr = document.CreateAttribute("xsi:schemaLocation", xsi.NamespaceName);
                galattr.Value = _schemaLocation.NamespaceName + " native.xsd";
                galley.Attributes.Append(galattr);
                galley.SetAttribute("xmlns:xsi", xsi.ToString());
                galley.SetAttribute("approved", "false");

                foreach (XElement gall in articles[i].Elements("galley"))
                {
                    XmlElement idgal = document.CreateElement("id");
                    idgal.SetAttribute("advice", "ignore");
                    idgal.SetAttribute("type", "internal");
                    count++;
                    idgal.InnerText = count.ToString();
                    galley.AppendChild(idgal);

                    XmlElement namegal = document.CreateElement("name");
                    namegal.SetAttribute("locale", locale);
                    namegal.InnerText = gall.Element("label").Value;
                    galley.AppendChild(namegal);

                    XmlElement seq = document.CreateElement("seq");
                    seq.InnerText = "1";
                    galley.AppendChild(seq);

                    XmlElement remote = document.CreateElement("remote");
                    remote.SetAttribute("src", gall.Element("file").Element("remote").Attribute("src").Value);
                    galley.AppendChild(remote);
                }

                Rootarticles.AppendChild(galley);
               

                XmlElement issueId = document.CreateElement("issue_idenrification");

                XmlElement volume = document.CreateElement("volume");
                volume.InnerText = oldDocument.Element("issues").Element("issue").Element("volume").Value;
                issueId.AppendChild(volume);

                XmlElement numb = document.CreateElement("number");
                numb.InnerText = number;
                issueId.AppendChild(numb);

                XmlElement year = document.CreateElement("year");
                year.InnerText = oldDocument.Element("issues").Element("issue").Element("year").Value;
                issueId.AppendChild(year);

                Rootarticles.AppendChild(issueId);
              

                XmlElement pages = document.CreateElement("pages");
                pages.InnerText = articles[i].Element("pages").Value;
                Rootarticles.AppendChild(pages);


            
                document.AppendChild(Rootarticles);


                string Root = doiArr[1] + "-" + doiArr[2] + ".xml";
                string pathb = AppDomain.CurrentDomain.BaseDirectory + Root;
                document.Save(pathb);
            }
        }
    }

}
