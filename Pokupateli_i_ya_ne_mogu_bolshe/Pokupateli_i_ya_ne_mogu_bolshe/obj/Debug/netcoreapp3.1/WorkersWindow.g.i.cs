﻿#pragma checksum "..\..\..\WorkersWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "78B265F72BC8955BB0D474143FDD17F8B25B35EE"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Pokupateli_i_ya_ne_mogu_bolshe;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Pokupateli_i_ya_ne_mogu_bolshe {
    
    
    /// <summary>
    /// WorkersWindow
    /// </summary>
    public partial class WorkersWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\WorkersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView Customers;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\WorkersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView Orders;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\WorkersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Processed;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\WorkersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Shipped;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\WorkersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Done;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\WorkersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Active;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\WorkersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OpenOne;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\WorkersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OpenAll;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Pokupateli_i_ya_ne_mogu_bolshe;component/workerswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WorkersWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Customers = ((System.Windows.Controls.ListView)(target));
            return;
            case 2:
            this.Orders = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.Processed = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\WorkersWindow.xaml"
            this.Processed.Click += new System.Windows.RoutedEventHandler(this.Processed_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Shipped = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\WorkersWindow.xaml"
            this.Shipped.Click += new System.Windows.RoutedEventHandler(this.Shipped_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Done = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\WorkersWindow.xaml"
            this.Done.Click += new System.Windows.RoutedEventHandler(this.Done_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Active = ((System.Windows.Controls.CheckBox)(target));
            
            #line 41 "..\..\..\WorkersWindow.xaml"
            this.Active.Click += new System.Windows.RoutedEventHandler(this.Active_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.OpenOne = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\WorkersWindow.xaml"
            this.OpenOne.Click += new System.Windows.RoutedEventHandler(this.OpenOne_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.OpenAll = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\WorkersWindow.xaml"
            this.OpenAll.Click += new System.Windows.RoutedEventHandler(this.OpenAll_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

