using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WPFSharp.Builder;

namespace WPFSharpTest {
    class BuilderTest {
        Window _Wndow = Window.Make().
            Width( 800 ).
            Height( 600 ).
            Visibility( System.Windows.Visibility.Visible ).
            Content(
                DockPanel.Make().LastChildFill(false).Children(
                Button.Make().Content( "Hello, World" ).EventLoaded((o,e) => Initialized( o, e ) ).DockAt( System.Windows.Controls.Dock.Left ),
                Button.Make().Content( "Goodbye, World" ).EventClick((o,e) => Click( o, e ) ).DockAt( System.Windows.Controls.Dock.Right ),
                Button.Make().Content( "Middle" )
                )
               );

        private static void Click( object o, System.Windows.RoutedEventArgs e ) {
        }

        private static void Initialized( object o, EventArgs e ) {
        }


        public BuilderTest() {
        }


    }
}
