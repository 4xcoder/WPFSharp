﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace WPFSharpTest {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        private void Application_Startup( object sender, StartupEventArgs e ) {
            BuilderTest test = new BuilderTest();
        }
    }
}
