using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFSharp.Builder {
    public class BindName {
        public static implicit operator String( BindName b ) {
            return b.GetType().Name;
        }

    }
}
