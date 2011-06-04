using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Raven.Client.Document;

namespace WFARavenStorage
{
    public partial class ClientInfo : Form
    {
        public ClientInfo()
        {
            InitializeComponent();
        }

        private void StoreIt_Click(object sender, EventArgs e)
        {
            using (var store = new DocumentStore { Url = "http://localhost:8080" })
            {
                store.Initialize();
                using (var session = store.OpenSession())
                {
                    Person person;
                    IQueryable<Person> ExistingPerson = from Person in session.Query<Person>()
                                                        where (Person.FirstName == FistNameBox.Text && Person.LastName == LastNameBox.Text)
                                                        select Person;
                    
                    person = new Person
                    {
                        FirstName = FistNameBox.Text,
                        LastName = LastNameBox.Text,
                        PersonAddress = new Address
                        {
                            zip = ZipBox.Text,
                            State = StateBox.Text,
                            City = CityBox.Text,
                            AddressFirstLine = AddressFirstBox.Text,
                            AddressSecondLine = AddressSecondBox.Text,
                        }
                    };
                    if (ExistingPerson != null)
                    {
                        person.Id = session.Advanced.GetDocumentId(ExistingPerson);
                    }
                    Confirmation.Text = String.Format("{0} {1}", person.FirstName, person.LastName);
                    session.Store(person);
                    session.SaveChanges();
                }
            }
        }

    
    }
}
