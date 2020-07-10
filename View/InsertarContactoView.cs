using System.Drawing;
using System.Windows.Forms;

namespace ListinTelefonico.View
{
    class InsertarContactoView : Form
    {

        public InsertarContactoView()
        {
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

            var botonGurdar = new Button()
            {
                DialogResult = DialogResult.OK,
                Text = "&Guardar"
            };
            this.AcceptButton = botonGurdar;
            this.CancelButton = botonCerrar;

            toret.Controls.Add(botonGurdar);
            toret.Controls.Add(botonCerrar);
            toret.Dock = DockStyle.Top;

            return toret;
        }

        /// <summary>
        /// Validar el DNI
        /// No puede ser null ni vacío
        /// </summary>
        /// <returns>Panel</returns>
        Panel buildValidDNI()
        {
            var toret = new Panel { Dock = DockStyle.Top };
            this.editDni = new TextBox { Dock = DockStyle.Fill };
            var lbDni = new Label
            {
                Text = "DNI/CIF:",
                Dock = DockStyle.Left
            };

            toret.Controls.Add(this.editDni);
            toret.Controls.Add(lbDni);
            toret.MaximumSize = new Size(int.MaxValue, editDni.Height * 2);

            this.editDni.Validating += (sender, cancelArgs) => {
                var btAccept = (Button)this.AcceptButton;
                bool invalid = string.IsNullOrEmpty(this.Dni);

                if (invalid || !char.IsNumber(this.Dni[0]))
                {
                    this.editDni.Text = "¿DNI?";
                }

                btAccept.Enabled = !invalid;
            };

            return toret;
        }

        /// <summary>
        /// Validar el nombre
        /// No puede ser null ni espacio en blanco
        /// </summary>
        /// <returns>Panel</returns>
        Panel buildValidNombre()
        {
            var toret = new Panel { Dock = DockStyle.Top };
            this.editNombre = new TextBox { Dock = DockStyle.Fill };
            var lbNombre = new Label
            {
                Text = "Nombre:",
                Dock = DockStyle.Left
            };

            toret.Controls.Add(this.editNombre);
            toret.Controls.Add(lbNombre);
            toret.MaximumSize = new Size(int.MaxValue, editNombre.Height * 2);

            this.editNombre.Validating += (sender, cancelArgs) => {
                var btAccept = (Button)this.AcceptButton;
                bool invalid = string.IsNullOrWhiteSpace(this.Nombre);

                invalid = invalid || !char.IsLetter(this.Nombre[0]);

                if (invalid)
                {
                    this.editNombre.Text = "¿Nombre?";
                }

                btAccept.Enabled = !invalid;
            };

            return toret;
        }

        /// <summary>
        /// Valida el número de teléfono
        /// El valor indicado es como mínimo 600000000 y como máximo 999999999 
        /// </summary>
        /// <returns>Panel</returns>
        Panel buildValidTelefono()
        {
            var toret = new Panel();
            this.editTelefono = new NumericUpDown
            {

                TextAlign = HorizontalAlignment.Left,
                Dock = DockStyle.Fill,
                Minimum = 600000000,
                Maximum = 999999999
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
        /// No puede ser nulo ni espacio en blanco
        /// </summary>
        /// <returns>Panel</returns>
        Panel buildValidEmail()
        {
            var toret = new Panel { Dock = DockStyle.Top };
            this.editEmail = new TextBox { Dock = DockStyle.Fill };
            var lbEmail = new Label
            {
                Text = "Email:",
                Dock = DockStyle.Left
            };

            toret.Controls.Add(this.editEmail);
            toret.Controls.Add(lbEmail);
            toret.MaximumSize = new Size(int.MaxValue, editEmail.Height * 2);

            this.editEmail.Validating += (sender, cancelArgs) => {
                var btAccept = (Button)this.AcceptButton;
                bool invalid = string.IsNullOrWhiteSpace(this.Email);

                invalid = invalid || !char.IsLetter(this.Email[0]);

                if (invalid)
                {
                    this.editEmail.Text = "¿Email?";
                }

                btAccept.Enabled = !invalid;
            };

            return toret;
        }

        /// <summary>
        /// Valida la dirección postal
        /// No puede ser nula ni espacio en blanco
        /// </summary>
        /// <returns>Panel</returns>
        Panel buildValidDireccionPostal()
        {
            var toret = new Panel { Dock = DockStyle.Top };
            this.editDireccion = new TextBox { Dock = DockStyle.Fill };
            var lbDireccion = new Label
            {
                Text = "Dirección Postal:",
                Dock = DockStyle.Left
            };

            toret.Controls.Add(this.editDireccion);
            toret.Controls.Add(lbDireccion);
            toret.MaximumSize = new Size(int.MaxValue, editDireccion.Height * 2);

            this.editDireccion.Validating += (sender, cancelArgs) => {
                var btAccept = (Button)this.AcceptButton;
                bool invalid = string.IsNullOrWhiteSpace(this.Direccion);

                invalid = invalid || !char.IsLetter(this.Direccion[0]);

                if (invalid)
                {
                    this.editDireccion.Text = "¿Dirección postal?";
                }

                btAccept.Enabled = !invalid;
            };

            return toret;
        }

        /// <summary>
        /// Crea el panel de Insertar Contacto
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

            this.Text = "Nuevo Contacto";
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
        private NumericUpDown editTelefono;
        private TextBox editEmail;
        private TextBox editDireccion;

        public string Dni => this.editDni.Text;
        public string Nombre => this.editNombre.Text;
        public int Telefono => (int)this.editTelefono.Value;
        public string Email => this.editEmail.Text;
        public string Direccion => this.editDireccion.Text;
    }
}
