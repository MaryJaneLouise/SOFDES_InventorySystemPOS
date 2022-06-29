using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSWithInventorySystem {
    public class DatabaseConnection {
        // Password "admin"
        //public static string Connection = @"Server=localhost;Database=posinventorysystem;Uid=root;Pwd=admin;SslMode=none ";

        // Password none, default
        public static string Connection = @"Server=localhost;Database=posinventorysystem;Uid=root;Pwd=;SslMode=none ";
    }
}
