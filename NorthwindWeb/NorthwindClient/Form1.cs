using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NorthwindClient.ServiceReference1;

namespace NorthwindClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            northwindEntities proxy = new northwindEntities(new Uri("http://localhost:3717/NorthwindCustomers.svc/"));
            this.customerBindingSource.DataSource = proxy.Customers;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.northwindEntities proxy = new northwindEntities(new Uri("http://localhost:3717/NorthwindCustomers.svc/"));
            string city = textBox1.Text;

            if (!string.IsNullOrEmpty(city))
            {
                this.customerBindingSource.DataSource = from c in proxy.Customers where c.City == city select c;
            }
            
        }
    }
}
