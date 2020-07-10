using ListinTelefonico.Core;
using System;

namespace ListinTelefonico.View
{
    class Menu
    {
        public static int MenuPrincipal()
        {
            int toret = 0;

            Console.WriteLine("Listín Telefónico");
            Console.WriteLine("1. Lista clientes");
            Console.WriteLine("2. Insertar nuevo cliente");
            Console.WriteLine("0. Salir");

            do
            {
                Console.WriteLine("\nSelecciona (0-2): ");

                if (!int.TryParse(Console.ReadLine(), out toret))
                {
                    toret = -1;
                }
            } while (toret < 0 && toret > 2);

            return toret;
        }

        public static Contacto ReadContacto()
        {
            string entrada;
            string dni;
            string nombre;
            int telefono;
            string email;
            string direccionPostal;

            do
            {
                Console.WriteLine("\n\nIntroduce DNI o CIF: ");
                dni = Console.ReadLine();

            } while (dni == null);

            do
            {
                Console.WriteLine("\n\nIntroduce nombre: ");
                nombre = Console.ReadLine();

            } while (nombre == null);


            do
            {
                Console.WriteLine("\n\nIntroduce número de teléfono: ");
                entrada = Console.ReadLine();
                if (!int.TryParse(entrada, out telefono))
                {
                    telefono = -1;
                }
            } while (telefono <= 100000000 && telefono > 999999999);

            do
            {
                Console.WriteLine("\n\nIntroduce email: ");
                email = Console.ReadLine();

            } while (email == null);

            do
            {
                Console.WriteLine("\n\nIntroduce dirección postal: ");
                direccionPostal = Console.ReadLine();
            } while (direccionPostal == null);

            Contacto c = new Contacto(dni, nombre, telefono, email, direccionPostal);
            return c;
        }

        public static void MainLoop(string[] args)
        {
            int op;
            RegistroContactos clientes = RegistroContactos.RecuperarXml();

            op = MenuPrincipal();
            while (op != 0)
            {
                switch (op)
                {
                    case 1:
                        Console.WriteLine(clientes.ToString());
                        break;
                    case 2:
                        clientes.Add(ReadContacto());
                        break;
                }

                op = MenuPrincipal();
            }

            clientes.GuardarXml();
            return;
        }
    }
}
