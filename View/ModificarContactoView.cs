using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using ListinTelefonico.Core;

namespace ListinTelefonico.View
{
    class ModificarContactoView : Form
    {

        private Contacto c;

        public ModificarContactoView(Contacto c)
        {
            this.c = c;
            this.Build();
        }

        public Panel BuildBotones()
        {
            var toret = new TableLayoutPanel()
            {
                ColumnCount = 2,
                RowCount = 1
            };

            var botonCerrar = new Button()
            {
                DialogResult = DialogResult.Cancel,
                Text = "&Cancelar"
            };

            var botonGuardar = new Button()
            {
                DialogResult = DialogResult.OK,
                Text = "&Guardar"
            };

            toret.Controls.Add(botonGuardar);
            toret.Controls.Add(botonCerrar);
            toret.Dock = DockStyle.Top;

            return toret;
        }

        /// <summary>
        /// Valida el DNI/Cif
        /// </summary>
        /// <returns>Panel</returns>
        Panel buildValidDNI()
        {
            var toret = new Panel { Dock = DockStyle.Top };
            this.editDni = new TextBox
            {
                Dock = DockStyle.Fill,
                TextAlign = HorizontalAlignment.Center,
                Text = this.c.DNI,
                ReadOnly = true
            };
            var lbDni = new Label
            {
                Text = "DNI/CIF:",
                Dock = DockStyle.Left
            };

            toret.Controls.Add(this.editDni);
            toret.Controls.Add(lbDni);
            toret.MaximumSize = new Size(int.MaxValue, editDni.Height * 2);

            return toret;
        }

        /// <summary>
        /// Valida el nombre
        /// </summary>
        /// <returns>Panel</returns>
        Panel buildValidNombre()
        {
            var toret = new Panel { Dock = DockStyle.Top };
            this.editNombre = new TextBox
            {
                Dock = DockStyle.Fill,
                TextAlign = HorizontalAlignment.Center,
                Text = this.c.Nombre
            };
            var lbNombre = new Label
            {
                Text = "Nombre:",
                Dock = DockStyle.Left
            };

            toret.Controls.Add(this.editNombre);
            toret.Controls.Add(lbNombre);
            toret.MaximumSize = new Size(int.MaxValue, editNombre.Height * 2);

            return toret;
        }

        /// <summary>
        /// Valida el número de teléfono
        /// </summary>
        /// <returns>Panel</returns>
        Panel buildValidTelefono()
        {
            var toret = new Panel();
            this.editTelefono = new TextBox
            {
                Text = System.Convert.ToString(c.Telefono),
                TextAlign = HorizontalAlignment.Center,
                Dock = DockStyle.Fill
            };

            var lbTelefono = new Label
            {
                Text = "Telefono: ",
                Dock = DockStyle.Left
            };

            toret.Controls.Add(this.editTelefono);
            toret.Controls.Add(lbTelefono);
            toret.Dock = DockStyle.Top;
            toret.MaximumSize = new Size(int.MaxValue, editTelefono.Height * 2);

            return toret;
        }

        /// <summary>
        /// Valida el email
        /// </summary>
        /// <returns>Panel</returns>
        Panel buildValidEmail()
        {
            var toret = new Panel { Dock = DockStyle.Top };
            this.editEmail = new TextBox
            {
                Dock = DockStyle.Fill,
                TextAlign = HorizontalAlignment.Center,
                Text = this.c.Email
            };
            var lbEmail = new Label
            {
                Text = "Email:",
                Dock = DockStyle.Left
            };

            toret.Controls.Add(this.editEmail);
            toret.Controls.Add(lbEmail);
            toret.MaximumSize = new Size(int.MaxValue, editEmail.Height * 2);

            return toret;
        }

        /// <summary>
        /// Valida la dirección postal
        /// </summary>
        /// <returns>Panel</returns>
        Panel buildValidDireccionPostal()
        {
            var toret = new Panel { Dock = DockStyle.Top };
            this.editDireccion = new TextBox
            {
                Dock = DockStyle.Fill,
                TextAlign = HorizontalAlignment.Center,
                Text = this.c.DireccionPostal
            };
            var lbDireccion = new Label
            {
                Text = "Dirección Postal:",
                Dock = DockStyle.Left
            };

            toret.Controls.Add(this.editDireccion);
            toret.Controls.Add(lbDireccion);
            toret.MaximumSize = new Size(int.MaxValue, editDireccion.Height * 2);

            return toret;
        }
        /// <summary>
        /// Crea el panel de Modificar Contacto
        /// </summary>
        void Build()
        {
            this.SuspendLayout();

            var panelInserta = new TableLayoutPanel { Dock = DockStyle.Fill };
            panelInserta.SuspendLayout();
            this.Controls.Add(panelInserta);

            var panelDNI = this.buildValidDNI();
            panelInserta.Controls.Add(panelDNI);
            var panelNombre = this.buildValidNombre();
            panelInserta.Controls.Add(panelNombre);
            var panelTelefono = this.buildValidTelefono();
            panelInserta.Controls.Add(panelTelefono);
            var panelEmail = this.buildValidEmail();
            panelInserta.Controls.Add(panelEmail);
            var panelDireccion = this.buildValidDireccionPostal();
            panelInserta.Controls.Add(panelDireccion);

            var panelBotones = this.BuildBotones();
            panelInserta.Controls.Add(panelBotones);

            panelInserta.ResumeLayout(true);

            this.Text = "Modificar contacto";
            this.Size = new Size(400,
                            panelDNI.Height + panelNombre.Height + panelTelefono.Height
                            + panelEmail.Height + panelDireccion.Height + panelBotones.Height);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ResumeLayout(false);
        }
        private TextBox editDni;
        private TextBox editNombre;
        private TextBox editTelefono;
        private TextBox editEmail;
        private TextBox editDireccion;


        public string Nombre => this.editNombre.Text;
        public int Telefono => System.Convert.ToInt32(this.editTelefono.Text);
        public string Email => this.editEmail.Text;
        public string Direccion => this.editDireccion.Text;
    }
}
