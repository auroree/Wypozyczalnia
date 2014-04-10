using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wypozyczalnia.Model;

namespace Wypozyczalnia.View
{
    public partial class EmployeeForm : BaseForm
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }

        public EmployeeForm(List<string> functions)
        {
            InitializeComponent();
            FillFunctionList(functions);
        }

        public EmployeeForm(Employee employee, List<string> functions)
        {
            InitializeComponent();

            textBox1.Text = "" + employee.Id;
            textBox2.Text = employee.Name;
            textBox3.Text = employee.Surname;
            textBox4.Text = employee.DateOfBirth.Date.ToString();
            textBox5.Text = employee.PlaceOfBirth;
            textBox6.Text = employee.Salary.ToString();
            FillFunctionList(functions);
            comboBox1.SelectedItem = employee.Function;
        }

        public override void DisableAllFields()
        {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            
        }

        public string TextBox3
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }

        public string TextBox4
        {
            get { return textBox4.Text; }
            set { textBox4.Text = value; }
        }

        public string TextBox5
        {
            get { return textBox5.Text; }
            set { textBox5.Text = value; }
        }

        public string TextBox6
        {
            get { return textBox6.Text; }
            set { textBox6.Text = value; }
        }

        public string ComboBox1
        {
            get { return comboBox1.SelectedItem.ToString(); }
            set { comboBox1.SelectedItem = value; }
        }

        private void FillFunctionList(List<string> functions)
        {
            foreach (string function in functions)
            {
                comboBox1.Items.Add(function);
            }
        }
    }
}
