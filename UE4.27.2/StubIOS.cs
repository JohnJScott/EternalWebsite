// ETERNAL BEGIN - APPLE
using System.Collections.Generic;
using Tools.DotNETCommon;

namespace UnrealBuildTool
{
	/// <summary>
	/// Stub partial class for IOS-specific target settings. 
	/// This class is not in a restricted location to simplify code paths in UBT. It is visible to all UE4 users, without NDA, and will appear
	/// empty to those without the IOS implementation code.
	/// </summary>
	public partial class IOSTargetRules
	{
		/// <summary>
		/// Contructor required for compilation
		/// </summary>
		public IOSTargetRules()
		{
		}

		/// <summary>
		/// Contructor required for compilation
		/// </summary>
		/// <param name="Target"></param>
		public IOSTargetRules( TargetInfo Target )
		{
		}

		/// <summary>
		/// Whether to strip iOS symbols or not (implied by Shipping config).
		/// </summary>
		public bool bStripSymbols = false;

		/// <summary>
		/// If true, then a stub IPA will be generated when compiling is done (minimal files needed for a valid IPA).
		/// </summary>
		public bool bCreateStubIPA = false;
	}

	/// <summary>
	/// Stub read-only wrapper for IOS-specific target settings.
	/// This class is not in a restricted location to simplify code paths in UBT. It is visible to all UE4 users, without NDA, and will appear
	/// empty to those without the IOS implementation code.
	/// </summary>
	public partial class ReadOnlyIOSTargetRules
	{
		/// <summary>
		/// The private mutable settings object
		/// </summary>
		private IOSTargetRules Inner;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="Inner">The settings object to wrap</param>
		public ReadOnlyIOSTargetRules( IOSTargetRules Inner )
		{
			this.Inner = Inner;
		}


		/// <summary>
		/// Whether to strip iOS symbols or not (implied by Shipping config).
		/// </summary>
		public bool bStripSymbols = false;

		/// <summary>
		/// If true, then a stub IPA will be generated when compiling is done (minimal files needed for a valid IPA).
		/// </summary>
		public bool bCreateStubIPA = false;
	}

	/// <summary>
	/// IOS provisioning data
	/// </summary>
	class IOSProvisioningData
	{
		public FileReference MobileProvisionFile = null;
	}

	class IOSPlatform : UEBuildPlatform
	{
		public IOSPlatform( UnrealTargetPlatform TargetPlatform )
			: base( TargetPlatform )
		{
		}

		public IOSProvisioningData ReadProvisioningData( FileReference ProjectFile, bool bForDistribution = false, string Bundle = "" )
		{
			return null;
		}

		public override bool IsBuildProduct( string FileName, string[] NamePrefixes, string[] NameSuffixes )
		{
			return false;
		}

		public override UEToolChain CreateToolChain( ReadOnlyTargetRules Target )
		{
			return null;
		}

		public override bool ShouldCreateDebugInfo( ReadOnlyTargetRules Target )
		{
			return false;
		}

		public override void SetUpEnvironment( ReadOnlyTargetRules Target, CppCompileEnvironment CompileEnvironment, LinkEnvironment LinkEnvironment )
		{
		}

		public override SDKStatus HasRequiredSDKsInstalled()
		{
			return SDKStatus.Invalid;
		}

		public override void Deploy( TargetReceipt Receipt )
		{
		}
	}

	class IOSToolChainSettings
	{
		public IOSToolChainSettings( bool bVerbose = false )
		{
		}

		public string GetSDKPath( string Architecture )
		{
			return null;
		}
	}

	class TVOSToolChainSettings
	{
		public TVOSToolChainSettings( bool bVerbose = false )
		{
		}

		public string GetSDKPath( string Architecture )
		{
			return null;
		}
	}

	class IOSToolChain : UEToolChain
	{
		public override CPPOutput CompileCPPFiles( CppCompileEnvironment CompileEnvironment, List<FileItem> InputFiles, DirectoryReference OutputDir, string ModuleName, IActionGraphBuilder Graph )
		{
			return null;
		}

		public override FileItem LinkFiles( LinkEnvironment LinkEnvironment, bool bBuildImportLibraryOnly, IActionGraphBuilder Graph )
		{
			return null;
		}

		public static string GetAssetCatalogArgs( UnrealTargetPlatform Platform, string InputDir, string OutputDir )
		{
			return null;
		}
	}
}

// ETERNAL END - APPLE
