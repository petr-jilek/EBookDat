﻿#pragma checksum "..\..\..\..\View\EGCmanagerWindows\CompanyManager.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "056F7EC89FA9A1C0976B30A808CF9F3A6E4CF2AE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using EBookDat.View.EGCmanagerWindows;
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


namespace EBookDat.View.EGCmanagerWindows {
    
    
    /// <summary>
    /// CompanyManager
    /// </summary>
    public partial class CompanyManager : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\..\View\EGCmanagerWindows\CompanyManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock mainTitle;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\View\EGCmanagerWindows\CompanyManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock countTitle;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\View\EGCmanagerWindows\CompanyManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock countVariableText;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\View\EGCmanagerWindows\CompanyManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchTextBox;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\View\EGCmanagerWindows\CompanyManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView egcListBox;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\View\EGCmanagerWindows\CompanyManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameEditTextBox;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\View\EGCmanagerWindows\CompanyManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel upDownStackPanel;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\View\EGCmanagerWindows\CompanyManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameTextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/EBookDat;component/view/egcmanagerwindows/companymanager.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\EGCmanagerWindows\CompanyManager.xaml"
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
            this.mainTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.countTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.countVariableText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.searchTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 31 "..\..\..\..\View\EGCmanagerWindows\CompanyManager.xaml"
            this.searchTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.egcListBox = ((System.Windows.Controls.ListView)(target));
            return;
            case 6:
            
            #line 38 "..\..\..\..\View\EGCmanagerWindows\CompanyManager.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.TitleGridViewColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.nameEditTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 50 "..\..\..\..\View\EGCmanagerWindows\CompanyManager.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 51 "..\..\..\..\View\EGCmanagerWindows\CompanyManager.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.upDownStackPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 11:
            
            #line 54 "..\..\..\..\View\EGCmanagerWindows\CompanyManager.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UpButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 59 "..\..\..\..\View\EGCmanagerWindows\CompanyManager.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DownButton_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.nameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 14:
            
            #line 76 "..\..\..\..\View\EGCmanagerWindows\CompanyManager.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
