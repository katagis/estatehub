using System;
using System.Collections.Generic;
using System.Text;

namespace EstateHub.model
{
    class Owner : User
    {
        public List<Estate> Estates { get; }
    }
}
