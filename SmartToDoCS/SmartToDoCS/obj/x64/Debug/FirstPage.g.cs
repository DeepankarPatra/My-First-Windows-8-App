﻿

#pragma checksum "C:\Users\doslab\Documents\Visual Studio 2012\Projects\SmartToDoCS\SmartToDoCS\FirstPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5B0B8068E8CF438F7F85167E5231789A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartToDoCS
{
    partial class FirstPage : global::SmartToDoCS.Common.LayoutAwarePage, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 37 "..\..\..\FirstPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).DoubleTapped += this.GoHome;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 55 "..\..\..\FirstPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Save_Task;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 49 "..\..\..\FirstPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Second_Click;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 50 "..\..\..\FirstPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Third_Click;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 47 "..\..\..\FirstPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.First_Click;
                 #line default
                 #line hidden
                break;
            case 6:
                #line 42 "..\..\..\FirstPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.GoBack;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


