using ListinTelefonico.Core;
using System;
using System.Windows.Forms;

namespace ListinTelefonico.View
{
    class MainWindowCore
    {
        public MainWindowCore()
        {
            this.registro = RegistroContactos.RecuperarXml();
            this.MainWindowsView = new MainWindowView();
            this.MainWindowsView.ResizeWindow();
            this.MainWindowsView.OpInsertaContacto.Click += (sender, e) => this.InsertarContacto();
            this.MainWindowsView.grdLista.Click += (sender, e) => this.Acciones();
            this.MainWindowsView.OpSalir.Click += (sender, e) => this.Salir();
            this.MainWindowsView.Shown += (sender, e) => this.Actualiza();
            this.MainWindowsView.Closed += (sender, e) => this.Salir();
        }

        /// <summary>
        /// Metodo de insertar Contacto
        /// Valida que el dni no exista, en caso de que exista lanza un mensaje
        /// </summary>
        void InsertarContacto()
        {
            var vInsertaContacto = new InsertarContactoView();

            if (vInsertaContacto.ShowDialog() == DialogResult.OK)
            {
                var dnis = registro.getDnis();
                bool existe = false;
                foreach (String d in dnis)
                {
                    if (vInsertaContacto.Dni == d)
                    {
                        existe = true;
                    }
                }
                if (existe == false)
                {
                    Contacto contacto = new Contacto(vInsertaContacto.Dni, vInsertaContacto.Nombre, vInsertaContacto.Telefono, vInsertaContacto.Email, vInsertaContacto.Direccion);
                    this.registro.Add(contacto);
                }
                else
                {
                    DialogResult result;
                    string mensaje = "Error al insertar, el DNI ya existe:" + vInsertaContacto.Dni + ".";
                    string tittle = "Warning";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    result = MessageBox.Show(mensaje, tittle, buttons);
                }
            }
            this.Actualiza();
        }

        /// <summary>
        /// Acciones permitidas: Eliminar y Modificar contacto
        /// </summary>
        void Acciones()
        {
            if (this.MainWindowsView.grdLista.CurrentCell.ColumnIndex == 5)
            {
                this.Eliminar();
            }
            else if (this.MainWindowsView.grdLista.CurrentCell.ColumnIndex == 6)
            {
                string dni = (string)this.MainWindowsView.grdLista.CurrentRow.Cells[0].Value;
                this.Modificar(dni);
            }
        }

        /// <summary>
        /// Acción eliminar
        /// Contiene mensaje de confirmación antes de realizar la acción
        /// </summary>
        void Eliminar()
        {
            string dni = (string)this.MainWindowsView.grdLista.CurrentRow.Cells[0].Value;
            DialogResult result;
            string mensaje = "¿Esta usted seguro de que quiere eliminar el cliente " + dni + "?";
            string tittle = "Eliminar Cliente";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            result = MessageBox.Show(mensaje, tittle, buttons);

            if (result == DialogResult.Yes)
            {
                registro.Remove(registro.getContacto(dni));
                this.Actualiza();
            }

        }

        /// <summary>
        /// Modificar un contacto a partir del dni del mismo
        /// </summary>
        /// <param name="dni">El parámetro para saber que contacto modificar</param>
        void Modificar(string dni)
        {
            Contacto contacto = this.registro.getContacto(dni);
            var vModificaContacto = new ModificarContactoView(contacto);
            if (vModificaContacto.ShowDialog() == DialogResult.OK)
            {
                this.registro.Remove(contacto);

                Contacto contactoEdit = new Contacto(dni,
                                                   vModificaContacto.Nombre,
                                                   vModificaContacto.Telefono,
                                                   vModificaContacto.Email,
                                                   vModificaContacto.Direccion);
                this.registro.Add(contactoEdit);

            }
            this.Actualiza();
        }

        /// <summary>
        /// Actualizar la tabla una vez realizadas las acciones de insertar, modificar o eliminar
        /// </summary>
        void Actualiza()
        {
            int numElementos = this.registro.Count;
            for (int i = 0; i < numElementos; i++)
            {
                if (this.MainWindowsView.grdLista.Rows.Count <= i)
                {
                    this.MainWindowsView.grdLista.Rows.Add();
                }
                this.ActualizarFilaLista(i);
            }

            // Eliminar filas sobrantes
            int numExtra = this.MainWindowsView.grdLista.Rows.Count - numElementos;
            for (; numExtra > 0; --numExtra)
            {
                this.MainWindowsView.grdLista.Rows.RemoveAt(numElementos);
            }
        }

        private void ActualizarFilaLista(int numFila)
        {
            if (numFila < 0
              || numFila > this.MainWindowsView.grdLista.Rows.Count)
            {
                throw new System.ArgumentOutOfRangeException(
                            "fila fuera de rango: " + nameof(numFila));
            }

            DataGridViewRow fila = this.MainWindowsView.grdLista.Rows[numFila];
            Contacto contacto = this.registro[numFila];

            fila.Cells[0].Value = contacto.DNI;
            fila.Cells[1].Value = contacto.Nombre;
            fila.Cells[2].Value = contacto.Telefono;
            fila.Cells[3].Value = contacto.Email;
            fila.Cells[4].Value = contacto.DireccionPostal;
            fila.Cells[5].Value = "-";
            fila.Cells[6].Value = "*";

            foreach (DataGridViewCell celda in fila.Cells)
            {
                celda.ToolTipText = contacto.ToString();
            }

        }

        /// <summary>
        /// Salir de la aplicación
        /// </summary>
        void Salir()
        {
            this.registro.GuardarXml();
            Application.Exit();
        }



        public MainWindowView MainWindowsView
        {
            get; private set;
        }
        public RegistroContactos registro;
    }
}
