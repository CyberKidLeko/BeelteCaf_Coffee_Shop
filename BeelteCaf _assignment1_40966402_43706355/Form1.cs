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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            picLogo.BackColor = Color.Transparent;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

           /*
            OrderForm orderForm = new OrderForm();
            this.MdiParent = mdiParentForm;
            orderForm.Show(); // Show the child form within the MDI parent*/


        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            OrderForm orderForm= new OrderForm();
            //orderForm.MdiParent= this;
            orderForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SfaffLogin staffLogin = new SfaffLogin();
            staffLogin.Show();
        }
    }
}
