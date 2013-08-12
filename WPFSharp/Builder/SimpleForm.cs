using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFSharp.Builder {
    public class SimpleForm : Grid {
        public static new SimpleForm Make() {
            return new SimpleForm();
        }

        System.Windows.HorizontalAlignment _LabelHorizontalAlighemtn = System.Windows.HorizontalAlignment.Left;
        System.Windows.HorizontalAlignment _ControlHorizontalAlighemtn = System.Windows.HorizontalAlignment.Left;


        public SimpleForm() {
            this.ColumnDefinitions(
               "Auto",
               "3",
               "Auto",
               "*" );
        }

        public SimpleForm LabelHorizontalAlignmnt( System.Windows.HorizontalAlignment align ) {
            _LabelHorizontalAlighemtn = align;
            return this;
        }

        public SimpleForm ControlHorizontalAlignmnt( System.Windows.HorizontalAlignment align ) {
            _ControlHorizontalAlighemtn = align;
            return this;
        }

        public SimpleForm Add( params  Bind<object>[] fields ) {
            if ( ( fields.Length & 1 ) == 1 )
                throw new ArgumentException( "Add must have an even number of parameters" );

            for ( int i = 0; i < fields.Length; i += 2 ) {
                Bind<object> f1 = fields[i];
                Bind<object> f2 = fields[i + 1];
                FrameworkElement label = null;
                FrameworkElement control = null;
                if ( f1.V is string )
                    label = Label.Make().Content( (string) f1.V );
                else if ( f1.V is FrameworkElement )
                    label = f1.V as FrameworkElement;

                if ( f2.V is FrameworkElement )
                    control = f2.V as FrameworkElement;

                if ( label == null || control == null  )
                    throw new ArgumentException( string.Format( "{0} or {1} are not FrameworkElements", f1.V, f2.V ) );
               
                label.HorizontalAlignment( _LabelHorizontalAlighemtn );
                control.HorizontalAlignment( _ControlHorizontalAlighemtn );

                int row = i / 2;
                label.GridSetRowColumn( row, 0 );
                control.GridSetRowColumn( row, 2 );
                control.Margin( new System.Windows.Thickness( 0, 0, 0, 5 ) );

                C.Children.Add( label.C );
                C.Children.Add( control.C );

                RowDefinitions( "Auto" );
            }

            RowDefinitions( "*" );
            return this;
        }
    }
}
