// ETERNAL BEGIN - APPLE
using System.Collections.Generic;
using Tools.DotNETCommon;

namespace UnrealBuildTool
{
	/// <summary>
	/// Stub partial class for Mac-specific target settings. 
	/// This class is not in a restricted location to simplify code paths in UBT. It is visible to all UE4 users, without NDA, and will appear
	/// empty to those without the Mac implementation code.
	/// </summary>
	public partial class MacTargetRules
	{
		/// <summary>
		/// Contructor required for compilation
		/// </summary>
		public MacTargetRules()
		{
		}

		/// <summary>
		/// Contructor required for compilation
		/// </summary>
		/// <param name="Target"></param>
		public MacTargetRules( TargetInfo Target )
		{
		}
	}

	/// <summary>
	/// Stub read-only wrapper for Mac-specific target settings.
	/// This class is not in a restricted location to simplify code paths in UBT. It is visible to all UE4 users, without NDA, and will appear
	/// empty to those without the Mac implementation code.
	/// </summary>
	public partial class ReadOnlyMacTargetRules
	{
		/// <summary>
		/// The private mutable settings object
		/// </summary>
		private MacTargetRules Inner;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="Inner">The settings object to wrap</param>
		public ReadOnlyMacTargetRules( MacTargetRules Inner )
		{
			this.Inner = Inner;
		}
	}

	class XcodeProjectFileGenerator : ProjectFileGenerator
	{
		public XcodeProjectFileGenerator( FileReference InOnlyGameProject, CommandLineArguments CommandLine )
			: base( InOnlyGameProject )
		{
		}

		protected override bool WriteMasterProjectFile( ProjectFile UBTProject, PlatformProjectGeneratorCollection PlatformProjectGenerators )
		{
			return true;
		}

		/// <summary>
		/// The file extension for this project file.
		/// </summary>
		public override string ProjectFileExtension
		{
			get
			{
				return null;
			}
		}

		public override void CleanProjectFiles( DirectoryReference InMasterProjectDirectory, string InMasterProjectName, DirectoryReference InIntermediateProjectFilesDirectory )
		{
		}

		/// <summary>
		/// Allocates a generator-specific project file object
		/// </summary>
		/// <param name="InitFilePath">Path to the project file</param>
		/// <returns>The newly allocated project file object</returns>
		protected override ProjectFile AllocateProjectFile( FileReference InitFilePath )
		{
			return null;
		}

		/// ProjectFileGenerator interface
		public override MasterProjectFolder AllocateMasterProjectFolder( ProjectFileGenerator InitOwnerProjectFileGenerator, string InitFolderName )
		{
			return null;
		}
	}

	class MacToolChainSettings
	{
		public string ToolchainDir = null;
		public string BaseSDKDir = null;

		public MacToolChainSettings( bool bVerbose )
		{
		}
	}

	class MacToolChain : UEToolChain
	{
		public static string SDKPath = null;

		public static MacToolChainSettings Settings = new MacToolChainSettings( false );

		public override CPPOutput CompileCPPFiles( CppCompileEnvironment CompileEnvironment, List<FileItem> InputFiles, DirectoryReference OutputDir, string ModuleName, IActionGraphBuilder Graph )
		{
			return null;
		}

		public override FileItem LinkFiles( LinkEnvironment LinkEnvironment, bool bBuildImportLibraryOnly, IActionGraphBuilder Graph )
		{
			return null;
		}
	}
}

// ETERNAL END - APPLE
