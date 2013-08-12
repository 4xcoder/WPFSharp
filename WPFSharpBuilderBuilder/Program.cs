using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.IO;

namespace WPFSharpBuilderBuilder {
    class Program {
        static Type BaseType = typeof( System.Windows.FrameworkElement );
        //static  System.Windows.Controls.Control BaseClass = new System.Windows.Controls.Control();

        #region Controls
        static Type[] Controls = {
                                 typeof( System.Windows.Window ),
                                 typeof( System.Windows.Controls.AccessText ),
                                 typeof( System.Windows.Controls.Border ),
                                 typeof( System.Windows.Controls.Button ),
                                 typeof( System.Windows.Controls.Calendar ),
                                 typeof( System.Windows.Controls.Canvas ),
                                 typeof( System.Windows.Controls.CheckBox ),
                                 typeof( System.Windows.Controls.ComboBox ),
                                 typeof( System.Windows.Controls.ComboBoxItem ),
                                 typeof( System.Windows.Controls.DataGrid ),
                                 typeof( System.Windows.Controls.DatePicker ),
                                 typeof( System.Windows.Controls.DockPanel ),
                                 typeof( System.Windows.Shapes.Ellipse ),
                                 typeof( System.Windows.Controls.Expander ),
                                 typeof( System.Windows.Controls.Grid ),
                                 typeof( System.Windows.Controls.GridSplitter ),
                                 typeof( System.Windows.Controls.GroupBox ),
                                 typeof( System.Windows.Controls.Image ),
                                 typeof( System.Windows.Controls.Label ),
                                 typeof( System.Windows.Shapes.Line ),
                                 typeof( System.Windows.Controls.ListBox ),
                                 typeof( System.Windows.Controls.ListBoxItem ),
                                 typeof( System.Windows.Controls.ListView ),
                                 typeof( System.Windows.Controls.ListViewItem ),
                                 typeof( System.Windows.Controls.MediaElement ),
                                 typeof( System.Windows.Controls.Menu ),
                                 typeof( System.Windows.Controls.MenuItem ),
                                 typeof( System.Windows.Controls.PasswordBox ),
                                 typeof( System.Windows.Controls.ProgressBar ),
                                 typeof( System.Windows.Controls.RadioButton ),
                                 typeof( System.Windows.Shapes.Rectangle ),
                                 typeof( System.Windows.Controls.RichTextBox ),
                                 typeof( System.Windows.Controls.ScrollViewer ),
                                 typeof( System.Windows.Controls.Separator ),
                                 typeof( System.Windows.Controls.Slider ),
                                 typeof( System.Windows.Controls.StackPanel ),
                                 typeof( System.Windows.Controls.TabControl ),
                                 typeof( System.Windows.Controls.TabItem ),
                                 typeof( System.Windows.Controls.TextBlock ),
                                 typeof( System.Windows.Controls.TextBox ),
                                 typeof( System.Windows.Controls.ToolBar ),
                                 typeof( System.Windows.Controls.TreeView ),
                                 typeof( System.Windows.Controls.TreeViewItem ),
                                 typeof( System.Windows.Controls.UserControl ),
                                 typeof( System.Windows.Controls.Viewbox ),
                                 typeof( System.Windows.Controls.Viewport3D ),
                                 typeof( System.Windows.Controls.WebBrowser ),
                                 typeof( System.Windows.Controls.WrapPanel ),
                                 typeof( System.Windows.Forms.Integration.WindowsFormsHost ),

                                   };
        #endregion

        #region Ignore Property Names
        static string[] Ignore = {
                                     "AreAnyTouchesCaptured",
                                     "AreAnyTouchesCapturedWithin",
                                     "AreAnyTouchesDirectlyOver",
                                     "AreAnyTouchesOver",
                                     "BindingGroup",
                                     "BitmapEffect",
                                     "BitmapEffectInput",
                                     "CacheMode",
                                     "CellsPanelHorizontalOffset",
                                     "Clip",
                                     "ContentHorizontalOffset",
                                     "ContentVerticalOffset",
                                     "DependencyObjectType",
#if !ANIMATION
                                     "Effect",
                                     "HasAnimatedProperties",
#endif
                                     "HorizontalOffset",
                                     "InheritanceBehavior",
                                     "InputBindings",
                                     "InputScope",
                                     "IsArrangeValid",
                                     "IsDragging",
                                     "IsEnabledCore",
                                     "IsHitTestVisible",
                                     "IsHighlighted",
                                     "IsInitialized",
                                     "IsInputMethodEnabled",
                                     "IsKeyboardFocused",
                                     "IsKeyboardFocusWithin",
                                     "IsLoaded",
                                     "IsManipulationEnabled",
                                     "IsMeasureValid",
                                     "IsPressed",
                                     "IsSealed",
#if !STYLUS
                                     "IsStylusCaptured",
                                     "IsStylusCaptureWithin",
                                     "IsStylusDirectlyOver",
                                     "IsStylusOver",
#endif
                                     "IsSuspendingPopupAnimation",
                                     "IsTabStop",
                                     "LogicalChildren",
                                     "NonFrozenColumnsViewportHorizontalOffset",
                                     "Parent",
                                     "PersistId",
                                     "RenderSize",
                                     "RowHeaderActualWidth",
                                     "SelectionBoxItem",
                                     "SelectionBoxItemTemplate",
                                     "SelectionBoxItemStringFormat",
                                     "SelectedContent",
                                     "SelectedContentStringFormat",
                                     "SelectedContentTemplate",
                                     "SelectedContentTemplateSelector",

                                     "TemplatedParent",
#if !TOUCHES
                                     "TouchesCaptured",
                                     "TouchesCapturedWithin",
                                     "TouchesDirectlyOver",
                                     "TouchesOver",
#endif
                                     "VerticalOffset",
                                     "VisualBitmapEffect",
                                     "VisualBitmapEffectInput",
                                     "VisualBitmapScalingMode",
                                     "VisualCacheMode",
                                     "VisualChildrenCount",
                                     "VisualParent",
                                     "VisualScrollableAreaClip",
                                     "VisualTextHintingMode",
                                     "VisualTextRenderingMode",
                                     "VisualXSnappingGuidelines",
                                     "VisualYSnappingGuidelines",

        };
        #endregion


        static string Dock = @"
        public {0} DockAt( Bind<System.Windows.Controls.Dock> bind ) {{
            System.Windows.Controls.DockPanel.SetDock( C, bind.V );;
            return this;
        }}
";
        static void Main( string[] args ) {
            var properties = BaseType.GetProperties();
            var events = BaseType.GetEvents();

            using ( StreamWriter writer = new StreamWriter( File.Open( @"..\..\..\WPFSharp\Builder\Builder.cs", FileMode.Create, FileAccess.Write, FileShare.ReadWrite ) ) ) {
                writer.WriteLine( "using System;" );
                writer.WriteLine();
                writer.WriteLine( "namespace WPFSharp.Builder {" );
                writer.WriteLine( "    public abstract partial class {0} {{", BaseType.Name );
                writer.WriteLine( "        public {0} C {{ get; set; }}", BaseType.FullName );
                writer.WriteLine();
                
                writer.WriteLine( Dock, BaseType.Name );

                writer.Write( @"
        public {0} GridSetRowColumn( int row, int column ) {{
            System.Windows.Controls.Grid.SetColumn( C, column );
            System.Windows.Controls.Grid.SetRow( C, row );
            return this;
        }}
",

            BaseType.Name );

                foreach ( var e in events ) {
                    var eType = e.ToString();
                    string[] fields = eType.Split( '[', ']', ' '  );
                    string eventArgsType;
                    string eventName;
                    if ( fields.Length == 4 ) {
                        eventArgsType = fields[1];
                        eventName = fields[3].Trim();
                    } else if ( fields.Length == 2 ) {
                        eventArgsType = fields[0];
                        eventName = fields[1];
                    } else
                        throw new Exception();
                    writer.Write( @"
        public {0} Event{1}( {3} e ) {{
            C.{1} += e;
            return this;
        }}
"
                        , BaseType.Name, eventName, eventArgsType, eventArgsType.Contains( "EventArgs" ) ? string.Format( "EventHandler<{0}>", eventArgsType ) : eventArgsType );
                }
                foreach ( var property in properties ) {
                    if ( !Ignore.Contains( property.Name ) && property.CanWrite ) {
                        string text = string.Format( @"
        public {0} {1}( Bind<{2}> bind ) {{
            C.{1} = bind.V;
            return this;
        }}
",
                            BaseType.Name, property.Name,
                            property.PropertyType.ToString() );
                        writer.WriteLine( text );

                    }
                }


                writer.WriteLine( "   }" );

                var baseProperties = properties;

                foreach ( var control in Controls ) {
                    writer.WriteLine();
                    writer.WriteLine( "    public partial class {0} : {1} {{", control.Name, BaseType.Name );
                    writer.WriteLine( "        public new {0} C {{ get {{ return base.C as {0}; }} set {{ base.C = value; }} }}", control.FullName );
                    writer.WriteLine();
                    writer.WriteLine( @"
        public static {0} Make() {{
            return new {0}();
        }}

        public {0}() {{
            C = new {1}();
        }}

        public new {0} GridSetRowColumn( int row, int column, int colspan=0, int rowspan=0 ) {{
            System.Windows.Controls.Grid.SetColumn( C, column );
            System.Windows.Controls.Grid.SetRow( C, row );
            if ( colspan != 0 )
                System.Windows.Controls.Grid.SetColumnSpan( C, colspan );
            if ( rowspan != 0 )
                System.Windows.Controls.Grid.SetRowSpan( C, rowspan );
            return this;
        }}


"
                        , control.Name, control.FullName );

                    writer.WriteLine();
                    properties = control.GetProperties();
                    if ( properties.FirstOrDefault( p => p.Name == "Children" ) != null && control.Name != "Viewport3D" )  {
                        var text = string.Format( @"
        public {0} {1}( params Bind<{2}>[] bind ) {{
           foreach( var b in bind ) {{
                C.Children.Add( ( ({4}) b.V ).C);
            }}
            return this;
        }}

",
                           control.Name, "Children",
                          BaseType.Name, control.Name[0].ToString(),
                          BaseType.Name );
                        writer.Write( text );
                    }

                    events = control.GetEvents();
                    foreach ( var e in events ) {
                        var eType = e.ToString();
                        string[] fields = eType.Split( '[', ']', ' ' );
                        string eventArgsType;
                        string eventName;
                        if ( fields.Length == 4 ) {
                            if ( fields[0].Contains( "RoutedPropertyChangedEventHandler" ) )
                                eventArgsType = String.Format( "System.Windows.RoutedPropertyChangedEventHandler<{0}>", fields[1] );
                            else
                                eventArgsType = fields[1];
                            eventName = fields[3].Trim();
                        } else if ( fields.Length == 2 ) {
                            eventArgsType = fields[0];
                            eventName = fields[1];
                        } else
                            throw new Exception();
                        writer.Write( @"
        public new {4} Event{1}( {3} e ) {{
            C.{1} += e;
            return this;
        }}
"
                            , BaseType.Name, eventName, eventArgsType, eventArgsType.Contains( "EventArgs" ) ? string.Format( "EventHandler<{0}>", eventArgsType ) : eventArgsType,
                            control.Name );
                    }


                    foreach ( var property in properties ) {
                        if ( !Ignore.Contains( property.Name )) {
                            string typeName = property.PropertyType.ToString();
                            if ( typeName == "System.Nullable`1[System.Boolean]" )
                                typeName = "bool?";
                            else if ( typeName == "System.Nullable`1[System.DateTime]" )
                                typeName = "DateTime?";
                            if ( baseProperties.FirstOrDefault( p => p.Name == property.Name ) == null ) {
                                string text = "";
                                if ( property.Name == "Content" ) {
                                    text = string.Format( @"
        public {0} {1}( Bind<{2}> bind ) {{
            if ( bind.V is {4} )
                C.{1} = (({4}) bind.V).C;
            else
                C.{1} = bind.V;
            return this;
        }}

",
                                       control.Name, property.Name,
                                      typeName, control.Name[0].ToString(),
                                      BaseType.Name );
                                } else if ( property.Name == "ItemsSource" ) {
                                    text = string.Format( @"
        public {0} {1}( params Bind<object>[] bind ) {{
            System.Collections.Generic.List<object> source = new System.Collections.Generic.List<object>();
           foreach( var b in bind ) {{
                if ( b.V is {4} )
                    source.Add( ( ({4}) b.V ).C );
                else
                    source.Add( b.V );
            }}
            C.ItemsSource = source;
            return this;
        }}

",
                                       control.Name, property.Name,
                                      typeName, control.Name[0].ToString(),
                                      BaseType.Name );
                                } else if ( property.Name == "ColumnDefinitions" ) {

                                    text = string.Format( @"
        public {0} ColumnDefinitions( params Bind<object>[] bind ) {{
             System.Windows.GridLengthConverter converter = new  System.Windows.GridLengthConverter();
           foreach( var b in bind ) {{
               var width = (System.Windows.GridLength) converter.ConvertFrom( b.V );
               C.ColumnDefinitions.Add( new System.Windows.Controls.ColumnDefinition() {{ Width = width }} );
            }}
            return this;
        }}

        public {0} RowDefinitions( params Bind<object>[] bind ) {{
             System.Windows.GridLengthConverter converter = new  System.Windows.GridLengthConverter();
           foreach( var b in bind ) {{
               var height = (System.Windows.GridLength) converter.ConvertFrom( b.V );
                C.RowDefinitions.Add(  new System.Windows.Controls.RowDefinition() {{ Height = height }} );
            }}
            return this;
        }}
",
                                       control.Name, property.Name,
                                      typeName, control.Name[0].ToString(),
                                      BaseType.Name, property.Name == "ColumnDefinitions" ? "System.Windows.Controls.ColumnDefinition" : "System.Windows.Controls.RowDefinition" );
                                } else if ( property.CanWrite ) {

                                    text = string.Format( @"
        public {0} {1}( Bind<{2}> bind ) {{
            C.{1} = bind.V;
            return this;
        }}

",
                                        control.Name, property.Name,
                                       typeName, control.Name[0].ToString() );
                                }
                                writer.WriteLine( text );
                            } else if ( property.CanWrite ) {
                                string text = string.Format( @"
        public new {0} {1}( Bind<{2}> bind ) {{
           return  base.{1}( bind ) as {0};
        }}

",
                                  control.Name, property.Name,
                                 typeName );
                                if ( text != "" )
                                    writer.Write( text );
                            }

                        } //!Ignore.Contains( property.Name )
                    }
                    writer.WriteLine( "   }" );

                }


                writer.WriteLine( "}" );
                //..\..\..\WPFSharp\Builder\Builder.cs
            }
        }
    }
}
