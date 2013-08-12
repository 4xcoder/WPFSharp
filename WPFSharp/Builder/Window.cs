using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFSharp.Builder {
    public class Window : Control {
        public System.Windows.Window W {
            get { return C as System.Windows.Window; }
            set { C = value; }
        }

        public Window() {
            W = new System.Windows.Window();
        }

        public Window Content( Control content ) {
            W.Content = content.C;
            return this;
        }

        public new Window AllowDrop( Bind<bool> allowDrop ) {
            return base.AllowDrop( allowDrop ) as Window;
        }

        public new Window Height( Bind<double> height ) {
            return base.Height( height ) as Window;
        }

        public new Window Width( Bind<double> width ) {
            return base.Width( width ) as Window;
        }

    }
}
