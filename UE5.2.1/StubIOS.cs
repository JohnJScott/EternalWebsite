// ETERNAL BEGIN - APPLE
using System.Collections.Generic;
using EpicGames.Core;
using Microsoft.Extensions.Logging;
using UnrealBuildBase;

namespace UnrealBuildTool
{
	partial struct UnrealArch
	{
		// @todo add x64 simulators to run on old macs?
		/// <summary>
		/// IOS Simulator
		/// </summary>
		public static UnrealArch IOSSimulator = FindOrAddByName( "iossimulator", bIsX64: false );

		/// <summary>
		/// TVOS Simulator
		/// </summary>
		public static UnrealArch TVOSSimulator = FindOrAddByName( "tvossimulator", bIsX64: false );


		private static Dictionary<UnrealArch, string> AppleToolchainArchitectures = new()
		{
			{ UnrealArch.Arm64,         "arm64" },
			{ UnrealArch.X64,           "x86_64" },
			{ UnrealArch.IOSSimulator,  "arm64" },
			{ UnrealArch.TVOSSimulator, "arm64" },
		};

		/// <summary>
		/// Apple-specific low level name for the generic platforms
		/// </summary>
		public string AppleName
		{
			get
			{
				if( AppleToolchainArchitectures.ContainsKey( this ) ) return AppleToolchainArchitectures[this];

				throw new BuildException( $"Unknown architecture {ToString()} passed to UnrealArch.AppleName" );
			}
		}
	}

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
	}

	/// <summary>
	/// IOS provisioning data
	/// </summary>
	class IOSProvisioningData
	{
		public FileReference? MobileProvisionFile = null;
	}

	class IOSPlatform : UEBuildPlatform
	{
		public IOSPlatform( UnrealTargetPlatform TargetPlatform, UEBuildPlatformSDK SDK, UnrealArchitectureConfig ArchitectureConfig, ILogger InLogger )
			: base( TargetPlatform, SDK, ArchitectureConfig, InLogger )
		{
		}

		public IOSProvisioningData ReadProvisioningData( FileReference? ProjectFile, bool bForDistribution = false, string? Bundle = "" )
		{
			return new IOSProvisioningData();
		}

		public override bool IsBuildProduct( string FileName, string[] NamePrefixes, string[] NameSuffixes )
		{
			return false;
		}

		public override UEToolChain CreateToolChain(ReadOnlyTargetRules Target)
		{
			return new IOSToolChain( Logger);
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

	class IOSToolChain : UEToolChain
	{
		public IOSToolChain( ILogger InLogger )
			: base( InLogger )
		{
		}

		protected override CPPOutput CompileCPPFiles( CppCompileEnvironment CompileEnvironment, List<FileItem> InputFiles, DirectoryReference OutputDir, string ModuleName, IActionGraphBuilder Graph )
		{
			return new CPPOutput();
		}

		public override FileItem? LinkFiles( LinkEnvironment LinkEnvironment, bool bBuildImportLibraryOnly, IActionGraphBuilder Graph )
		{
			return null;
		}
	}
}

// ETERNAL END - APPLE
