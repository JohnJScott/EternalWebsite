// ETERNAL BEGIN - LUMIN
using System.Collections.Generic;
using Tools.DotNETCommon;

namespace UnrealBuildTool
{
	/// <summary>
	/// Stub partial class for Mac-specific target settings. 
	/// This class is not in a restricted location to simplify code paths in UBT. It is visible to all UE4 users, without NDA, and will appear
	/// empty to those without the Mac implementation code.
	/// </summary>
	public partial class LuminTargetRules
	{
		/// <summary>
		/// Contructor required for compilation
		/// </summary>
		public LuminTargetRules()
		{
		}

		/// <summary>
		/// Contructor required for compilation
		/// </summary>
		/// <param name="Target"></param>
		public LuminTargetRules( TargetInfo Target )
		{
		}
	}

	/// <summary>
	/// Stub read-only wrapper for Mac-specific target settings.
	/// This class is not in a restricted location to simplify code paths in UBT. It is visible to all UE4 users, without NDA, and will appear
	/// empty to those without the Mac implementation code.
	/// </summary>
	public partial class ReadOnlyLuminTargetRules
	{
		/// <summary>
		/// The private mutable settings object
		/// </summary>
		private LuminTargetRules Inner;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="Inner">The settings object to wrap</param>
		public ReadOnlyLuminTargetRules( LuminTargetRules Inner )
		{
			this.Inner = Inner;
		}
	}
}

// ETERNAL END - LUMIN
