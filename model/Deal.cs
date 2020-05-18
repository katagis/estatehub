using System;
using System.Collections.Generic;
using System.Text;

namespace EstateHub.model
{
    public class Deal
    {
        public int ExpirationYear { get; }

        bool HasExpired() {
            return false;
            // TODO:
        }
    }
}
