﻿#pragma checksum "..\..\..\..\..\Views\Admin\BorrowBookPage\CollectionBookVorcherPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A1D407556DFA58B7CE22A4AF393C0DD0B8F50FA5450F025FB2C63B4F8CA64326"
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
    /// CollectionBookVorcherPage
    /// </summary>
    public partial class CollectionBookVorcherPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\..\Views\Admin\BorrowBookPage\CollectionBookVorcherPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MasterLibrary.Views.Admin.BorrowBookPage.CollectionBookVorcherPage CollectionBookVorcherPageML;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\..\Views\Admin\BorrowBookPage\CollectionBookVorcherPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteAllBookInCollect;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\..\Views\Admin\BorrowBookPage\CollectionBookVorcherPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvBookCollect;
        
        #line default
        #line hidden
        
        
        #line 405 "..\..\..\..\..\Views\Admin\BorrowBookPage\CollectionBookVorcherPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FilterBox;
        
        #line default
        #line hidden
        
        
        #line 424 "..\..\..\..\..\Views\Admin\BorrowBookPage\CollectionBookVorcherPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxBookInBorrow;
        
        #line default
        #line hidden
        
        
        #line 716 "..\..\..\..\..\Views\Admin\BorrowBookPage\CollectionBookVorcherPage.xaml"
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
            System.Uri resourceLocater = new System.Uri("/MasterLibrary;component/views/admin/borrowbookpage/collectionbookvorcherpage.xam" +
                    "l", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Admin\BorrowBookPage\CollectionBookVorcherPage.xaml"
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
            this.CollectionBookVorcherPageML = ((MasterLibrary.Views.Admin.BorrowBookPage.CollectionBookVorcherPage)(target));
            return;
            case 2:
            this.DeleteAllBookInCollect = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.lvBookCollect = ((System.Windows.Controls.ListView)(target));
            return;
            case 4:
            this.FilterBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 415 "..\..\..\..\..\Views\Admin\BorrowBookPage\CollectionBookVorcherPage.xaml"
            this.FilterBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FilterBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ListBoxBookInBorrow = ((System.Windows.Controls.ListBox)(target));
            return;
            case 6:
            this.btnPay = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

