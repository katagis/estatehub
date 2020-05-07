using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace EstateHub.model
{
    class Database
    {
        public static List<User> Users { get; private set; }
        public static List<Owner> Owners { get; private set; }
        public static List<Manager> Managers { get; private set; }
        
        // Called automatically from the constructors of these classes.
        public static void RegisterUser(User user) {
            Users.Add(user);
        }

        public static void RegisterOwner(Owner owner) {
            Owners.Add(owner);
        }

        public static void RegisterManager(Manager manager) {
            Managers.Add(manager);
        }
    }
}
