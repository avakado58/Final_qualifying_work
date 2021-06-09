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
    public partial class BigVue : Form
    {
        public BigVue(int id /*, string education, string age*/)
        {
            InitializeComponent();
            labelName.Text = Convert.ToString( id);
        }
    }
}
