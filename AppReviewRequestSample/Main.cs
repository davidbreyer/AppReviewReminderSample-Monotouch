
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.IO;

namespace AppReviewRequestSample
{
	public class Application
	{
		static void Main (string[] args)
		{
			UIApplication.Main (args);
		}
	}

	// The name AppDelegate is referenced in the MainWindow.xib file.
	public partial class AppDelegate : UIApplicationDelegate
	{
		// This method is invoked when the application has loaded its UI and its ready to run
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// If you have defined a view, add it here:
			// window.AddSubview (navigationController.View);
			btnResetFlag.TouchUpInside += delegate(object sender, EventArgs e) {
				WriteReviewFlag(0);
				lblReminderFlag.Text = string.Format("Reminder flag: {0}", 0);
			};
			
			window.MakeKeyAndVisible ();
			
			return true;
		}

		// This method is required in iPhoneOS 3.0
		public override void OnActivated (UIApplication application)
		{
			//This sample uses a simple file to store a reiminder flag.
			int flag = ReadReviewFlag();
			lblReminderFlag.Text = string.Format("Reminder flag: {0}", flag);
			
			if(flag < 3) //Number of times the user needs to open the app before s/he is prompted to review your application.
			{
				WriteReviewFlag(flag + 1); //If it's not time to show the prompt, then increment.
				lblReminderFlag.Text = string.Format("Reminder flag: {0}", flag + 1);
			}
			else if(flag == 3)
			{
				UIAlertView alert = new UIAlertView();
				alert.Title = "Thank You!";
				alert.Message = "Thank you for being such a dedicated user! If you have a second, we would love an honest review in the App Store.";
				alert.AddButton("Leave a Review");
				alert.AddButton("Remind Me Later");
				alert.AddButton("Don't Ask Again");
				alert.Show();
				alert.Clicked+= delegate(object sender, UIButtonEventArgs e) {
					switch(e.ButtonIndex)
					{
						case 0:
							WriteReviewFlag(100); //Set the number high enough so the user is not prompted again.
							lblReminderFlag.Text = string.Format("Reminder flag: {0}", 100);	
							UIApplication.SharedApplication.OpenUrl(NSUrl.FromString("Your-iTuntes-Application-URI")); //Open the App Store to your application
							break;
						case 1:
							WriteReviewFlag(1); //Reset the reminder flag to prompt the user at a later time.
							lblReminderFlag.Text = string.Format("Reminder flag: {0}", 1);	
							break;
						case 2:
							WriteReviewFlag(100); //Set the number high enough so the user is not prompted again.
							lblReminderFlag.Text = string.Format("Reminder flag: {0}", 100);
							break;
					}
				};
			}
		}
		
		#region Reminder flag functions
		int ReadReviewFlag()
		{
			string filePath = Path.Combine(Environment.GetFolderPath (Environment.SpecialFolder.Personal), "reviewflag.txt");
			int flag = 0;
			
			//If file does not exist then set the flag to 0.
			if(File.Exists(filePath))
			{
				Int32.TryParse(File.ReadAllText(filePath), out flag);
			} 
			else 
			{
				WriteReviewFlag(flag);
			}
			
			return flag;
		}
		
		void WriteReviewFlag(int ReviewFlag)
		{
			string filePath = Path.Combine(Environment.GetFolderPath (Environment.SpecialFolder.Personal), "reviewflag.txt");
			
			File.WriteAllText(filePath, ReviewFlag.ToString());
		}
		#endregion
	}
}

