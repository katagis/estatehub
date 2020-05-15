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
            Estatehub.RegisterOwner(this);
            AddDummyEstates();
        }

        public void AddDummyEstates() {
            Random r = new Random();
            for (int i = 0; i < 4; i++) {
                Estates.Add(new Estate() { Title = "Estate " + r.Next() + "" });
            }
        }
    }
}
