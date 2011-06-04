using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Raven.Client.Document;
using Twitterizer;

namespace WFARavenStorage
{
    public partial class ClientInfo : Form
    {
        public ClientInfo()
        {
            InitializeComponent();
        }

        public IQueryable<Twitterizer.Core.TwitterObject> GetTweets(string user)
        {
            var search = TwitterSearch.Search(user);
            var NeedHolding = search.ResponseObject.AsQueryable();
            return NeedHolding;
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
                                                        where (Person.FirstName == FirstNameBox.Text && Person.LastName == LastNameBox.Text)
                                                        select Person;
                    
                    person = new Person
                    {
                        FirstName = FirstNameBox.Text,
                        LastName = LastNameBox.Text,
                        TwitterAcct = TwitterBox.Text,
                        Chirps = GetTweets(TwitterBox.Text),
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
                   string AggTweet =
                       {
                       	foreach (IQueryable<Twitterizer.Core.TwitterObject> chirp in person.Chirps)
                            {"%r "+ chirp.
                       }

                   Confirmation.Text = String.Format("{0} {1}", person.FirstName, person.LastName);
                   
                    session.Store(person);
                    session.SaveChanges();
                    
                }
            }
        }

    
    }
}
