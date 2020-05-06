using System;
using System.Collections.Generic;
using System.Text;

namespace EstateHub.model
{
    public class Review
    {
        public string Comment { get; }
        public int Stars { get; }
        public Owner FromOwner { get; }
        public Manager ForManager { get; }
        
    }
}
