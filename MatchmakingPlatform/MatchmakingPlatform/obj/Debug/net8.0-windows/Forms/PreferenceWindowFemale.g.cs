﻿#pragma checksum "..\..\..\..\Forms\PreferenceWindowFemale.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "40D7205464E87C1004B05B01618DC4BDE03C0622"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace MatchmakingPlatform.Forms {
    
    
    /// <summary>
    /// PreferenceWindowFemale
    /// </summary>
    public partial class PreferenceWindowFemale : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\Forms\PreferenceWindowFemale.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button VisitCatalogButton;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Forms\PreferenceWindowFemale.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SearchItemsButton;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Forms\PreferenceWindowFemale.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddNewPreferenceButton;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Forms\PreferenceWindowFemale.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ClearAllPreferencesButton;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\Forms\PreferenceWindowFemale.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FindMatchingPairsButton;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\..\Forms\PreferenceWindowFemale.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView UserPreferencesListView;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MatchmakingPlatform;component/forms/preferencewindowfemale.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Forms\PreferenceWindowFemale.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.VisitCatalogButton = ((System.Windows.Controls.Button)(target));
            return;
            case 2:
            this.SearchItemsButton = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.AddNewPreferenceButton = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\..\Forms\PreferenceWindowFemale.xaml"
            this.AddNewPreferenceButton.Click += new System.Windows.RoutedEventHandler(this.AddNewPreferenceButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ClearAllPreferencesButton = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\..\Forms\PreferenceWindowFemale.xaml"
            this.ClearAllPreferencesButton.Click += new System.Windows.RoutedEventHandler(this.ClearAllPreferencesButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.FindMatchingPairsButton = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.UserPreferencesListView = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

