using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFSharp.Builder {
    public class Control {
        public System.Windows.Controls.Control C { get; set; }

        public Control() {
        }

        public Control AllowDrop( Bind<bool> allowDrop ) {
            C.AllowDrop = allowDrop.V;
            return this;
        }

        public Control Background( Bind<System.Windows.Media.Brush> background ) {
            C.Background = background;
            return this;
        }

        public Control Height( Bind<double> height ) {
            C.Height = height.V;
            return this;
        }

        public Control Width( Bind<double> width ) {
            C.Width = width.V;
            return this;
        }
    }
}
