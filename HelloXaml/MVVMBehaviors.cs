﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HelloXaml
{
    public static class MVVMBehaviors
    {
        public static string GetLoadedMethodName(DependencyObject obj)
        {
            return (string)obj.GetValue(LoadedMethodNameProperty);
        }

        public static void SetLoadedMethodName(DependencyObject obj, string value)
        {
            obj.SetValue(LoadedMethodNameProperty, value);
        }
        
        public static readonly DependencyProperty LoadedMethodNameProperty = DependencyProperty.RegisterAttached("LoadedMethodName", typeof(string), typeof(MVVMBehaviors), new PropertyMetadata(null, OnLoadedMethodNameChanged));

        static void OnLoadedMethodNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = d as FrameworkElement;
            if (element != null)
            {
                element.Loaded += (s, e2) =>
                {
                    var viewModel = element.DataContext;
                    if (viewModel == null) return;
                    var methodInfo = viewModel.GetType().GetMethod(e.NewValue.ToString());
                    if (methodInfo != null) methodInfo.Invoke(viewModel, null);
                };
            }
        }

    }
}
