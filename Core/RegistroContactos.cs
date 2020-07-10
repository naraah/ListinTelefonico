using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Collections;
using System.Xml.Linq;
using System.Collections.Generic;

namespace ListinTelefonico.Core
{
    class RegistroContactos : ICollection<Contacto>
    {

        public const string ArchivoXML = "contactos.xml";
        public const string EtqContactos = "contactos";
        public const string EtqContacto = "contacto";
        public const string EtqDni = "dni";
        public const string EtqNombre = "nombre";
        public const string EtqTelefono = "telefono";
        public const string EtqEmail = "email";
        public const string EtqDireccionPostal = "direccionPostal";

        private List<Contacto> contactos;

        public RegistroContactos()
        {
            this.contactos = new List<Contacto>();
        }

        public RegistroContactos(IEnumerable<Contacto> contactos) : this()
        {
            this.contactos.AddRange(contactos);
        }

        /// <summary>
        /// Obtener un contacto a partir de su DNI/CIF
        /// </summary>
        /// <param name="dni">El dni/cif del contacto</param>
        /// <returns>El contacto en caso de que exista, null en caso contrario</returns>
        public Contacto getContacto(string dni)
        {
            foreach (Contacto c in this.contactos)
            {
                if (c.DNI == dni)
                {
                    return c;
                }
            }
            return null;
        }

        /// <summary>
        /// Recupera los DNI/CIF registrados
        /// </summary>
        /// <returns>Lista de dni/cif</returns>
        public List<String> getDnis()
        {
            List<String> dnis = new List<string>();
            foreach (Contacto c in this.contactos)
            {
                dnis.Add(c.DNI);
            }
            return dnis;
        }

        /// <summary>
        /// Recupera el número de contactos
        /// </summary>
        public int Count
        {
            get { return this.contactos.Count; }
        }

        public bool IsReadOnly => throw new NotImplementedException();

        /// <summary>
        /// Método para añadir un contacto
        /// </summary>
        /// <param name="contacto">El contacto a añadir</param>
        public void Add(Contacto contacto)
        {
            this.contactos.Add(contacto);
        }

        /// <summary>
        /// Limpiar los contactos
        /// </summary>
        public void Clear()
        {
            this.contactos.Clear();
        }

        /// <summary>
        /// Devolver si un contacto ya existe
        /// </summary>
        /// <param name="contacto">El contacto</param>
        /// <returns>True en caso afirmativo, false en caso contrario</returns>
        public bool Contains(Contacto contacto)
        {
            return this.contactos.Contains(contacto);
        }

        public void CopyTo(Contacto[] contacto, int i)
        {
            this.contactos.CopyTo(contacto, i);
        }

        public IEnumerator<Contacto> GetEnumerator()
        {
            foreach (var contacto in this.contactos)
            {
                yield return contacto;
            }
        }

        /// <summary>
        /// Eliminar un contacto
        /// </summary>
        /// <param name="contacto">El contacto a eliminar</param>
        /// <returns></returns>
        public bool Remove(Contacto contacto)
        {
            return this.contactos.Remove(contacto);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var contacto in this.contactos)
            {
                yield return contacto;
            }
        }

        public Contacto this[int i]
        {
            get { return this.contactos[i]; }
            set { this.contactos[i] = value; }
        }

        public override string ToString()
        {
            var toret = new StringBuilder();
            foreach (Contacto c in contactos)
            {
                toret.Append(c);
            }

            return toret.ToString();
        }

        public void GuardarXml()
        {
            this.GuardarXml(ArchivoXML);
        }

        /// <summary>
        /// Guardar el archibo XML generado
        /// </summary>
        /// <param name="n">archivoXML</param>
        public void GuardarXml(String n)
        {
            var doc = new XDocument();
            var root = new XElement(EtqContactos);

            foreach (Contacto c in contactos)
            {
                XElement contacto = new XElement(EtqContacto,
                                            new XAttribute(EtqDni, c.DNI),
                                            new XAttribute(EtqNombre, c.Nombre),
                                            new XAttribute(EtqTelefono, c.Telefono),
                                            new XAttribute(EtqEmail, c.Email),
                                            new XAttribute(EtqDireccionPostal, c.DireccionPostal)

                                            );

                root.Add(contacto);
            }
            doc.Add(root);
            doc.Save(n);
        }

        /// <summary>
        /// Recuperar el XML con los contactos
        /// </summary>
        /// <returns>Archivo XML con los contactos</returns>
        public static RegistroContactos RecuperarXml()
        {
            return RecuperarXml(ArchivoXML);
        }

        /// <summary>
        /// Recupera los datos de un archivo XML
        /// </summary>
        /// <param name="n">archivoXML</param>
        /// <returns>El contacto</returns>
        public static RegistroContactos RecuperarXml(String n)
        {
            var toret = new RegistroContactos();
            try
            {
                var doc = XDocument.Load(n);
                if (doc.Root != null && doc.Root.Name == EtqContactos)
                {
                    var contactos = doc.Root.Elements(EtqContacto);
                    foreach (XElement contacto in contactos)
                    {
                        var c = GetcontactoXML(contacto);
                        toret.Add(c);
                    }
                }
            }
            catch (XmlException)
            {
                toret.Clear();
            }
            catch (IOException)
            {
                toret.Clear();
            }
            return toret;
        }

        /// <summary>
        /// Recupera el contacto XML
        /// </summary>
        /// <param name="c">El contacto a recuperar</param>
        /// <returns>El contacto</returns>
        public static Contacto GetcontactoXML(XElement c)
        {
            return new Contacto(
                (string)c.Attribute(EtqDni),
                (string)c.Attribute(EtqNombre),
                (int)c.Attribute(EtqTelefono),
                (string)c.Attribute(EtqEmail),
                (string)c.Attribute(EtqDireccionPostal)
            );
        }
    }
}
