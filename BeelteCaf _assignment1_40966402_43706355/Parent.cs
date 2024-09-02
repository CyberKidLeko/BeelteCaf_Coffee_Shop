using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeelteCaf__assignment1_40966402_43706355
{
    public partial class Parent : Form
    {
        public Parent()
        {
            InitializeComponent();
           

        }

        private void Parent_Load(object sender, EventArgs e)
        {
            Form1 frmWelcome = new Form1();  
            frmWelcome.MdiParent= this;
            //Parent.MdiParent = this; // Set the MDI parent form
            //this.MdiParent = Parent;

        }
    }
}
