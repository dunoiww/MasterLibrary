﻿#pragma checksum "..\..\..\..\..\Views\Customer\BorrowBookPage\BorrowBookPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7A3163228DF2C2108CB55BE734D3593D0159281D482184FBDB99EA700568D478"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MasterLibrary.Utils.ConverterValue;
using MasterLibrary.Views.Customer.BorrowBookPage;
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


namespace MasterLibrary.Views.Customer.BorrowBookPage {
    
    
    /// <summary>
    /// BorrowBookPage
    /// </summary>
    public partial class BorrowBookPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\..\Views\Customer\BorrowBookPage\BorrowBookPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MasterLibrary.Views.Customer.BorrowBookPage.BorrowBookPage BorrowBookPageML;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\..\Views\Customer\BorrowBookPage\BorrowBookPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FilterBox;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\..\..\Views\Customer\BorrowBookPage\BorrowBookPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox OutlinedComboBoxStatusBookInBorrow;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\..\..\Views\Customer\BorrowBookPage\BorrowBookPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvBookBorrow;
        
        #line default
        #line hidden
        
        
        #line 287 "..\..\..\..\..\Views\Customer\BorrowBookPage\BorrowBookPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ShadowMask;
        
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
            System.Uri resourceLocater = new System.Uri("/MasterLibrary;component/views/customer/borrowbookpage/borrowbookpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Customer\BorrowBookPage\BorrowBookPage.xaml"
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
            this.BorrowBookPageML = ((MasterLibrary.Views.Customer.BorrowBookPage.BorrowBookPage)(target));
            return;
            case 2:
            this.FilterBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 82 "..\..\..\..\..\Views\Customer\BorrowBookPage\BorrowBookPage.xaml"
            this.FilterBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FilterBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.OutlinedComboBoxStatusBookInBorrow = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.lvBookBorrow = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            this.ShadowMask = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

