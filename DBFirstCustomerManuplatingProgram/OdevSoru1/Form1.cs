using Microsoft.EntityFrameworkCore;
using OdevSoru1.Model;
using System.Drawing.Text;

namespace OdevSoru1
{
    public partial class Form1 : Form
    {
        NorthwndContext _db;
        public Form1()
        {
            InitializeComponent();
            _db = new NorthwndContext();
            
        }
        private Customer _customer = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            var listCustomers = _db.Customers.ToList();
            dgwCustomers.DataSource = listCustomers;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Customer customer = new Customer()
                {
                    CustomerId = tbID.Text,
                    CompanyName = tbCustomerName.Text,
                };
                _db.Customers.Add(customer);
                _db.SaveChanges();
                dgwCustomers.DataSource= _db.Customers.ToList();
                MessageBox.Show("Add Completed.");
            }
            catch (Exception)
            {
                throw new Exception("Please Check Your Value!!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = dgwCustomers.SelectedCells[0].RowIndex;
                string customerID = dgwCustomers.Rows[selectedIndex].Cells[0].Value.ToString();
                var deletedCustomer = _db.Customers.Where(x => x.CustomerId == customerID).FirstOrDefault();
                _db.Customers.Remove(deletedCustomer);
                Customer newCustomer = new Customer();
                newCustomer.CustomerId=tbID.Text;
                newCustomer.CompanyName=tbCustomerName.Text;
                _db.Customers.Add(newCustomer);
                _db.SaveChanges();
                dgwCustomers.DataSource= _db.Customers.ToList();
            }
            catch (Exception)
            {
                throw new Exception("Please Check Your Value!!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = dgwCustomers.SelectedCells[0].RowIndex;
                string customerID = dgwCustomers.Rows[selectedIndex].Cells[0].Value.ToString();
                var customer = _db.Customers.Where(c => c.CustomerId == customerID!).SingleOrDefault();
                _db.Customers.Remove(customer!);
                _db.SaveChanges();
                dgwCustomers.DataSource = _db.Customers.ToList();
                MessageBox.Show("Delete is Successful.");
            }
            catch (Exception)
            {
                throw new Exception("Please Check Your Value!!");
            }
        }

        private void dgwCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgwCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgwCustomers.SelectedRows.Count>0)
            {
                _customer = ((Customer)dgwCustomers.SelectedRows[0].DataBoundItem);

            }
        }
    }
}