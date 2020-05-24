using System;
using System.Collections.Generic;
using System.Text;

namespace EstateHub.model
{
    public class Review
    {
        public string Comment { get; set; }
        public int Stars { get; set; }
        public Owner FromOwner { get; set; }
        public Manager ForManager { get; set; }
        

    }
}
