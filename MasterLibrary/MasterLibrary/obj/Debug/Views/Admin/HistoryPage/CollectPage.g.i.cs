﻿#pragma checksum "..\..\..\..\..\Views\Admin\HistoryPage\CollectPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1946EC6278F7EF5E742624EF92AAA5B3216F3255AFD0C33C8B88DB03C4A29CD5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MasterLibrary.Views.Admin.HistoryPage;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interactivity;
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


namespace MasterLibrary.Views.Admin.HistoryPage {
    
    
    /// <summary>
    /// CollectPage
    /// </summary>
    public partial class CollectPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\..\Views\Admin\HistoryPage\CollectPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MasterLibrary.Views.Admin.HistoryPage.CollectPage CollectPageML;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\..\Views\Admin\HistoryPage\CollectPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FilterBox;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\..\Views\Admin\HistoryPage\CollectPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox filtercbb;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\..\..\Views\Admin\HistoryPage\CollectPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbbMonth;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\..\..\Views\Admin\HistoryPage\CollectPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbbYear;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\..\..\..\Views\Admin\HistoryPage\CollectPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvCollect;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MasterLibrary;component/views/admin/historypage/collectpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Admin\HistoryPage\CollectPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.CollectPageML = ((MasterLibrary.Views.Admin.HistoryPage.CollectPage)(target));
            return;
            case 2:
            this.FilterBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 57 "..\..\..\..\..\Views\Admin\HistoryPage\CollectPage.xaml"
            this.FilterBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FilterBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.filtercbb = ((System.Windows.Controls.ComboBox)(target));
            
            #line 67 "..\..\..\..\..\Views\Admin\HistoryPage\CollectPage.xaml"
            this.filtercbb.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.filtercbb_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cbbMonth = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.cbbYear = ((System.Windows.Controls.ComboBox)(target));
            
            #line 115 "..\..\..\..\..\Views\Admin\HistoryPage\CollectPage.xaml"
            this.cbbYear.Loaded += new System.Windows.RoutedEventHandler(this.cbbYear_Loaded);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lvCollect = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

