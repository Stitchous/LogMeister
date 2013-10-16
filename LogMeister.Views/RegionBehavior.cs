using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Xceed.Wpf.AvalonDock.Layout;


using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Prism.Regions;

namespace LogMeister.Views
{
	public static class AvalonDockRegion
	{
		#region Name

		public static readonly DependencyProperty NomenProperty =
			DependencyProperty.RegisterAttached("Nomen", typeof(string), typeof(FrameworkElement),
				new FrameworkPropertyMetadata((string)null,
					new PropertyChangedCallback(OnNameChanged)));

		public static string GetNomen(DependencyObject d)
		{
			return (string)d.GetValue(NomenProperty);
		}

		public static void SetNomen(DependencyObject d, string value)
		{
			d.SetValue(NomenProperty, value);
		}

		private static void OnNameChanged(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			var newValue = (string)e.NewValue;
					CreateRegion(s, newValue);
		}

		#endregion
		
		static void CreateRegion(DependencyObject element, string regionName)
		{
			var mappings = ServiceLocator.Current.GetInstance<RegionAdapterMappings>();
            var adapter = mappings.GetMapping(element.GetType());
            adapter.Initialize(element, regionName);
		}
	}
}
