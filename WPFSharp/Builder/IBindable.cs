using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFSharp.Builder {
    public interface IBindable<T> {
        T V { get; set; }

    }
}
