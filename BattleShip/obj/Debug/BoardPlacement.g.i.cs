﻿#pragma checksum "..\..\BoardPlacement.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9650F238BCD7365A5A1728C02A3FB7AF475E357D5BED8260369A317500CCA8EB"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using BattleShip;
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


namespace BattleShip {
    
    
    /// <summary>
    /// BoardPlacement
    /// </summary>
    public partial class BoardPlacement : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\BoardPlacement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid battleGrid;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\BoardPlacement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button restartBtn;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\BoardPlacement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock narratorTxt;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\BoardPlacement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button goBtn;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\BoardPlacement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox levelCBox;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\BoardPlacement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox timerCBox;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\BoardPlacement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button shuffle;
        
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
            System.Uri resourceLocater = new System.Uri("/BattleShip;component/boardplacement.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\BoardPlacement.xaml"
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
            
            #line 9 "..\..\BoardPlacement.xaml"
            ((BattleShip.BoardPlacement)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.movement);
            
            #line default
            #line hidden
            return;
            case 2:
            this.battleGrid = ((System.Windows.Controls.Grid)(target));
            
            #line 14 "..\..\BoardPlacement.xaml"
            this.battleGrid.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.restartBtn = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\BoardPlacement.xaml"
            this.restartBtn.Click += new System.Windows.RoutedEventHandler(this.restartBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.narratorTxt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.goBtn = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\BoardPlacement.xaml"
            this.goBtn.Click += new System.Windows.RoutedEventHandler(this.goBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.levelCBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.timerCBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.shuffle = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\BoardPlacement.xaml"
            this.shuffle.Click += new System.Windows.RoutedEventHandler(this.shuffling);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

