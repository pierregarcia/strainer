using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using Todo;
using Xamarin.Forms;
using System.IO;

namespace Todo
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : 
	global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate // superclass new in 1.3
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();
            app.StatusBarStyle = UIStatusBarStyle.LightContent;
            app.SetStatusBarStyle(UIStatusBarStyle.LightContent, true);
			LoadApplication (new App ());  // method is new in 1.3
            app.SetStatusBarStyle(UIStatusBarStyle.LightContent, true);

			return base.FinishedLaunching (app, options);
		}
	}
}