// ETERNAL BEGIN - ANDROID
using System.Collections.Generic;
using Tools.DotNETCommon;

namespace UnrealBuildTool
{
	/// <summary>
	/// Stub partial class for Mac-specific target settings. 
	/// This class is not in a restricted location to simplify code paths in UBT. It is visible to all UE4 users, without NDA, and will appear
	/// empty to those without the Mac implementation code.
	/// </summary>
	public partial class AndroidTargetRules
	{
		/// <summary>
		/// Contructor required for compilation
		/// </summary>
		public AndroidTargetRules()
		{
		}

		/// <summary>
		/// Contructor required for compilation
		/// </summary>
		/// <param name="Target"></param>
		public AndroidTargetRules( TargetInfo Target )
		{
		}
	}

	/// <summary>
	/// Stub read-only wrapper for Mac-specific target settings.
	/// This class is not in a restricted location to simplify code paths in UBT. It is visible to all UE4 users, without NDA, and will appear
	/// empty to those without the Mac implementation code.
	/// </summary>
	public partial class ReadOnlyAndroidTargetRules
	{
		/// <summary>
		/// The private mutable settings object
		/// </summary>
		private AndroidTargetRules Inner;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="Inner">The settings object to wrap</param>
		public ReadOnlyAndroidTargetRules( AndroidTargetRules Inner )
		{
			this.Inner = Inner;
		}
	}
}

// ETERNAL END - ANDROID
