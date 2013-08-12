using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFSharp.Builder {
    public class Bind<T> : IBindable<T> {
        #region IBindable<T> Members

        public T V { get; set; }

        public static implicit operator T( Bind<T> m ) {
            return m.V;
        }

        public static implicit operator Bind<T>( T t ) {
            return new Bind<T>() { V = t };
        }


        #endregion
    }
}
