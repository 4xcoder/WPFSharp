using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFSharp.Builder {
    public class Button : Control {
        public System.Windows.Controls.Button B {
            get { return C as System.Windows.Controls.Button; }
            set { C = value; }
        }

        public Button() {
            B = new System.Windows.Controls.Button();
        }

        public Button Content( Control content ) {
            B.Content = content.C;
            return this;
        }

        public Button Content( string content ) {
            B.Content = content;
            return this;
        }

        public new Button AllowDrop( Bind<bool> allowDrop ) {
            return base.AllowDrop( allowDrop ) as Button;
        }

        public new Button Height( Bind<double> height ) {
            return base.Height( height ) as Button;
        }

        public new Button Width( Bind<double> width ) {
            return base.Width( width ) as Button;
        }

    }
}
