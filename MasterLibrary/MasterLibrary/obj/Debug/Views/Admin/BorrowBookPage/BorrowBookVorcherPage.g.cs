﻿#pragma checksum "..\..\..\..\..\Views\Admin\BorrowBookPage\BorrowBookVorcherPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3F7A421D5800EEEB2D6D5264C738BC2CC8C6E2E617C77452D357A7B22E5B5FC9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MasterLibrary.Views.Admin.BorrowBookPage;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using Microsoft.Expression.Interactivity.Core;
using Microsoft.Expression.Interactivity.Input;
using Microsoft.Expression.Interactivity.Layout;
using Microsoft.Expression.Interactivity.Media;
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


namespace MasterLibrary.Views.Admin.BorrowBookPage {
    
    
    /// <summary>
    /// BorrowBookVorcherPage
    /// </summary>
    public partial class BorrowBookVorcherPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\..\Views\Admin\BorrowBookPage\BorrowBookVorcherPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MasterLibrary.Views.Admin.BorrowBookPage.BorrowBookVorcherPage BorrowBookVorcherPageML;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\..\Views\Admin\BorrowBookPage\BorrowBookVorcherPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteAllBookInBorrow;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\..\Views\Admin\BorrowBookPage\BorrowBookVorcherPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvBookBorrow;
        
        #line default
        #line hidden
        
        
        #line 273 "..\..\..\..\..\Views\Admin\BorrowBookPage\BorrowBookVorcherPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FilterBox;
        
        #line default
        #line hidden
        
        
        #line 292 "..\..\..\..\..\Views\Admin\BorrowBookPage\BorrowBookVorcherPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxBook;
        
        #line default
        #line hidden
        
        
        #line 415 "..\..\..\..\..\Views\Admin\BorrowBookPage\BorrowBookVorcherPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbMAKH;
        
        #line default
        #line hidden
        
        
        #line 590 "..\..\..\..\..\Views\Admin\BorrowBookPage\BorrowBookVorcherPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPay;
        
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
            System.Uri resourceLocater = new System.Uri("/MasterLibrary;component/views/admin/borrowbookpage/borrowbookvorcherpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Admin\BorrowBookPage\BorrowBookVorcherPage.xaml"
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
            this.BorrowBookVorcherPageML = ((MasterLibrary.Views.Admin.BorrowBookPage.BorrowBookVorcherPage)(target));
            return;
            case 2:
            this.DeleteAllBookInBorrow = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.lvBookBorrow = ((System.Windows.Controls.ListView)(target));
            return;
            case 4:
            this.FilterBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 283 "..\..\..\..\..\Views\Admin\BorrowBookPage\BorrowBookVorcherPage.xaml"
            this.FilterBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FilterBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ListBoxBook = ((System.Windows.Controls.ListBox)(target));
            return;
            case 6:
            this.tbMAKH = ((System.Windows.Controls.TextBox)(target));
            
            #line 422 "..\..\..\..\..\Views\Admin\BorrowBookPage\BorrowBookVorcherPage.xaml"
            this.tbMAKH.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextBox_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 423 "..\..\..\..\..\Views\Admin\BorrowBookPage\BorrowBookVorcherPage.xaml"
            this.tbMAKH.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnPay = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

