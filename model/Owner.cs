using System;
using System.Collections.Generic;
using System.Text;

namespace EstateHub.model
{
    public class Owner : User
    {
        public List<Estate> Estates { get; }
    }
}
