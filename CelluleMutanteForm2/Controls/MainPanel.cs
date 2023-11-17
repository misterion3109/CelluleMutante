using System;
using System.Windows.Forms;
using System.Drawing;


namespace CelluleMutanteForm2.Controls
{
    public class MainPanel : Panel
    {
        public MainPanel()
        {
            Name = "pnl_main";
            BackColor = Color.LightGray;
            Anchor = AnchorStyles.None;
            Size = new Size(600, 600);
            Dock = DockStyle.None;
        }
       
    }
}


