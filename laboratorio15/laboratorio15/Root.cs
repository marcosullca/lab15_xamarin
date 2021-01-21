using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Xamarin.Forms;

namespace laboratorio15
{

    public class User
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }



    }

    public class Root 
    {
        public List<User> users { get; set; }

        
    }
}