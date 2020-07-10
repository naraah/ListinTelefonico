using System.Text;

namespace ListinTelefonico.Core
{
    public class Contacto {

        /// <summary>
        /// Clase principal Contacto
        /// </summary>
        /// <param name="dni">El dni/cif del contacto</param>
        /// <param name="nombre">El nombre del contacto</param>
        /// <param name="telefono">El teléfono del contacto</param>
        /// <param name="email">El email del contacto</param>
        /// <param name="direccionPostal">La dirección postal del contacto</param>
        public Contacto (string dni, string nombre, int telefono, string email, string direccionPostal)
        {
            this.DNI = dni;
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Email = email;
            this.DireccionPostal = direccionPostal;
        }

        public string DNI
        {
            get; set;
        }

        public string Nombre
        {
            get; set;
        }

        public int Telefono
        {
            get; set;
        }

        public string Email
        {
            get; set;
        }

        public string DireccionPostal
        {
            get; set;
        }

        /// <summary>
        /// Constructor de la clase Contacto
        /// </summary>
        /// <returns>Contacto</returns>
        public override string ToString()
        {
            StringBuilder toret = new StringBuilder();
            toret.AppendLine("DNI: " + this.DNI);
            toret.AppendLine("Nombre: " + this.Nombre);
            toret.AppendLine("Telefono: " + this.Telefono);
            toret.AppendLine("Email: " + this.Email);
            toret.AppendLine("Dirección postal: " + this.DireccionPostal);
            return toret.ToString();
        }

    }
}
