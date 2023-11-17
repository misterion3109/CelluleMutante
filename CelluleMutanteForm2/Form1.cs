using CelluleMutanteForm2.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CelluleMutanteForm2
{
    public partial class Form1 : Form
    {
        // Déclaration des attributs Panel et Button que l’on va
        // afficher dans notre fenêtre
        Panel pnl_main;
        Button btn_simulation;
        Cell cellule;
        Timer MyTimer;
        public Form1()
        {
            InitializeComponent();

            // Initialisation d’un Panel en utilisant notre classe
            pnl_main = new MainPanel();
            pnl_main.Location = new Point((Size.Width - pnl_main.Width) / 2 - 10,
            (Size.Height - pnl_main.Height) / 2 - 40);
            pnl_main.Anchor = AnchorStyles.None;
            // Initialisation d’un Button en utilisant notre classe
            btn_simulation = new SimulationButton();
            btn_simulation.Location = new Point(190, 600);
            btn_simulation.Anchor = AnchorStyles.None;
            // Ajout des éléments à notre fenêtre
            Controls.Add(pnl_main);
            Controls.Add(btn_simulation);
            pnl_main.Anchor = AnchorStyles.None;
            pnl_main.Paint += new PaintEventHandler(pnl_main_Paint);
            //click du bouton simulation
            btn_simulation.Anchor = AnchorStyles.None;
            btn_simulation.Click += new EventHandler(btn_simulation_Click);
            //initialisation d'une nouvelle cellule
            cellule = new Cell();
            //Timer
            MyTimer = new Timer();
            MyTimer.Interval = (600);
            MyTimer.Tick += new EventHandler(UpdateCell);
        }
        private void UpdateCell(object sender, EventArgs e)
        {
            
            cellule.Mutation();
            this.Refresh();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // Définir la taille et le titre de la fenêtre
            Size = new Size(800, 1000);
            Text = "Cellule Mutante";
        }
        private void btn_simulation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La simulation commence");
            MyTimer.Start();
        }
        private void pnl_main_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(pnl_main.BackColor);

            int cellSize = cellule._size;
            Color cellColor = cellule._color;
           
            int centerX = pnl_main.Width / 2 - cellSize / 2;
            int centerY = pnl_main.Height / 2 - cellSize / 2;

            SolidBrush coloredBrush = new SolidBrush(cellColor);
            g.FillEllipse(coloredBrush, centerX, centerY, cellSize, cellSize);

            coloredBrush.Dispose();
            g.Dispose();
        }
    }
}
