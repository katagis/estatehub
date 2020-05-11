using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Markup;

namespace EstateHub.model
{
    public class Owner : User
    {
        public List<Estate> Estates { get; } = new List<Estate>();

        public Owner(string name) : base(name) {
            Database.RegisterOwner(this);
        }
    }
}
