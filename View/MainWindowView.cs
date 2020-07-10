using System.Drawing;
using System.Windows.Forms;

namespace ListinTelefonico.View
{
    /// <summary>
    /// Clase MainWindowView
    /// </summary>
    class MainWindowView : Form
    {
        public MainWindowView()
        {
            this.Build();
        }

        /// <summary>
        /// Construir la pantalla principal Listín Telefónico
        /// </summary>
        void Build()
        {
            this.BuildMenu();
            Panel ListPanel = this.BuildListPanel();

            this.SuspendLayout();

            this.pnlPpal = new Panel()
            {
                Dock = DockStyle.Fill
            };

            this.pnlPpal.SuspendLayout();
            this.Controls.Add(this.pnlPpal);
            this.pnlPpal.Controls.Add(ListPanel);
            this.pnlPpal.ResumeLayout(false);

            this.MinimumSize = new Size(600, 100);
            this.Text = "Listín Telefónico";
            this.Resize += (obj, e) => this.ResizeWindow();

            this.ResizeWindow();
            this.ResumeLayout(true);
        }

        public void ResizeWindow()
        {
            // Tomar las nuevas medidas
            int width = this.pnlPpal.ClientRectangle.Width;

            // Redimensionar la tabla
            this.grdLista.Width = width;

            this.grdLista.Columns[0].Width =
                                (int)System.Math.Floor(width * .13);
            this.grdLista.Columns[1].Width =
                                (int)System.Math.Floor(width * .13);
            this.grdLista.Columns[2].Width =
                                (int)System.Math.Floor(width * .13);
            this.grdLista.Columns[3].Width =
                                (int)System.Math.Floor(width * .18);
            this.grdLista.Columns[4].Width =
                                (int)System.Math.Floor(width * .13);
            this.grdLista.Columns[5].Width =
                                (int)System.Math.Floor(width * .10);
            this.grdLista.Columns[6].Width =
                                (int)System.Math.Floor(width * .10);
        }

        /// <summary>
        /// Construir el menú
        /// </summary>
        void BuildMenu()
        {
            this.Mpal = new MainMenu();

            this.MInsertar = new MenuItem("Insertar");
            this.OpInsertaContacto = new MenuItem("Insertar contacto");
            this.OpSalir = new MenuItem("Salir");

            this.MInsertar.MenuItems.Add(this.OpInsertaContacto);
            this.Mpal.MenuItems.Add(MInsertar);
            this.Mpal.MenuItems.Add(OpSalir);
            this.Menu = Mpal;

        }

        /// <summary>
        /// Establecer color a columnas y celdas
        /// </summary>
        /// <returns>Panel</returns>
        Panel BuildListPanel()
        {
            Panel pnlLista = new Panel();
            pnlLista.SuspendLayout();
            pnlLista.Dock = DockStyle.Fill;

            // Crear gridview
            this.grdLista = new DataGridView()
            {
                Dock = DockStyle.Fill,
                AllowUserToResizeRows = false,
                RowHeadersVisible = false,
                AutoGenerateColumns = false,
                MultiSelect = false,
                AllowUserToAddRows = false,
                EnableHeadersVisualStyles = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            this.grdLista.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            this.grdLista.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;

            var textCellTemplate0 = new DataGridViewTextBoxCell();
            var textCellTemplate1 = new DataGridViewTextBoxCell();
            textCellTemplate0.Style.BackColor = Color.LightGray;
            textCellTemplate0.Style.ForeColor = Color.Black;
            textCellTemplate1.Style.BackColor = Color.LightBlue;
            textCellTemplate1.Style.ForeColor = Color.Black;
            textCellTemplate1.Style.Alignment = DataGridViewContentAlignment.TopCenter;

            var col0 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate0,
                HeaderText = "Dni/Cif",
                Width = 50,
                ReadOnly = true
            };

            var col1 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = "Nombre",
                Width = 50,
                ReadOnly = true
            };

            var col2 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = "Teléfono",
                Width = 50,
                ReadOnly = true
            };

            var col3 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = "Email",
                Width = 50,
                ReadOnly = true
            };

            var col4 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = "Dirección",
                Width = 50,
                ReadOnly = true
            };

            var col5 = new DataGridViewButtonColumn
            {
                HeaderText = "Eliminar",
                Width = 50,
                ReadOnly = true
            };

            var col6 = new DataGridViewButtonColumn
            {
                HeaderText = "Modificar",
                Width = 50,
                ReadOnly = true
            };

            this.grdLista.Columns.AddRange(new DataGridViewColumn[] {
            col0, col1, col2, col3, col4, col5, col6
        });

            pnlLista.Controls.Add(this.grdLista);
            return pnlLista;
        }

        public MainMenu Mpal { get; set; }
        public MenuItem MInsertar { get; set; }
        public MenuItem OpInsertaContacto { get; set; }
        public MenuItem OpSalir { get; set; }

        public Panel pnlPpal;
        public DataGridView grdLista;

    }
}
