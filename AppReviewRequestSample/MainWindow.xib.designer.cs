// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace AppReviewRequestSample {
	
	
	// Base type probably should be MonoTouch.Foundation.NSObject or subclass
	[MonoTouch.Foundation.Register("AppDelegate")]
	public partial class AppDelegate {
		
		private MonoTouch.UIKit.UIWindow __mt_window;
		
		private MonoTouch.UIKit.UILabel __mt_lblReminderFlag;
		
		private MonoTouch.UIKit.UIButton __mt_btnResetFlag;
		
		#pragma warning disable 0169
		[MonoTouch.Foundation.Connect("window")]
		private MonoTouch.UIKit.UIWindow window {
			get {
				this.__mt_window = ((MonoTouch.UIKit.UIWindow)(this.GetNativeField("window")));
				return this.__mt_window;
			}
			set {
				this.__mt_window = value;
				this.SetNativeField("window", value);
			}
		}
		
		[MonoTouch.Foundation.Connect("lblReminderFlag")]
		private MonoTouch.UIKit.UILabel lblReminderFlag {
			get {
				this.__mt_lblReminderFlag = ((MonoTouch.UIKit.UILabel)(this.GetNativeField("lblReminderFlag")));
				return this.__mt_lblReminderFlag;
			}
			set {
				this.__mt_lblReminderFlag = value;
				this.SetNativeField("lblReminderFlag", value);
			}
		}
		
		[MonoTouch.Foundation.Connect("btnResetFlag")]
		private MonoTouch.UIKit.UIButton btnResetFlag {
			get {
				this.__mt_btnResetFlag = ((MonoTouch.UIKit.UIButton)(this.GetNativeField("btnResetFlag")));
				return this.__mt_btnResetFlag;
			}
			set {
				this.__mt_btnResetFlag = value;
				this.SetNativeField("btnResetFlag", value);
			}
		}
	}
}