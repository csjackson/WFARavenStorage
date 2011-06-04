using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WFARavenStorage
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ClientInfo());
           
            }
        
    }
    public class Person
    {
        public string Id {get ;  set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address PersonAddress { get; set; }
    }

    public class Address
    {
        public string zip { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string AddressFirstLine { get; set; }
        public string AddressSecondLine { get; set; }
    }
}
