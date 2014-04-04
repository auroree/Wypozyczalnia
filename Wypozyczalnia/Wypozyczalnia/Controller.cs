using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wypozyczalnia.View;

namespace Wypozyczalnia
{
    public class Controller
    {
        private BaseView clients, employees;
        private BaseView activeForm;

        public Boolean Closing { get; set; }

        public Controller(BaseView initForm)
        {
            activeForm = initForm;
            clients = initForm;
            employees = new EmployeesView();

            clients.SetController(this);
            employees.SetController(this);
            Closing = false;
        }

        public void ShowClientsView()
        {
            if (activeForm != clients)
            {
                activeForm.Hide();
                activeForm = clients;
                clients.Show();
            }
        }

        public void ShowEmployeesView()
        {
            if (activeForm != employees)
            {
                activeForm.Hide();
                activeForm = employees;
                employees.Show();
            }
        }

        public void ShowForm()
        {
            ClientForm form = new ClientForm();
            ClientFormController formController = new ClientFormController(form);
            form.ShowDialog();
        }
    }
}
