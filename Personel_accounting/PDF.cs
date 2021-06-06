using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personel_accounting
{
    public partial class PDF : Form
    {
        public PDF()
        {
            InitializeComponent();

            axAcroPDF1.src = System.AppDomain.CurrentDomain.BaseDirectory + "Помощь.pdf";
        }
    }
}
