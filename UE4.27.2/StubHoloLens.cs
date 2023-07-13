// ETERNAL BEGIN - HOLOLENS
using System.Collections.Generic;
using Tools.DotNETCommon;

namespace UnrealBuildTool
{
	/// <summary>
	/// Stub partial class for HoloLens-specific target settings. 
	/// This class is not in a restricted location to simplify code paths in UBT. It is visible to all UE4 users, without NDA, and will appear
	/// empty to those without the HoloLens implementation code.
	/// </summary>
	public partial class HoloLensTargetRules
	{
		/// <summary>
		/// Contructor required for compilation
		/// </summary>
		/// <param name="Target"></param>
		public HoloLensTargetRules( TargetInfo Target )
		{
		}
	}

	/// <summary>
	/// Stub read-only wrapper for HoloLens-specific target settings.
	/// This class is not in a restricted location to simplify code paths in UBT. It is visible to all UE4 users, without NDA, and will appear
	/// empty to those without the HoloLens implementation code.
	/// </summary>
	public partial class ReadOnlyHoloLensTargetRules
	{
		/// <summary>
		/// The private mutable settings object
		/// </summary>
		private HoloLensTargetRules Inner;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="Inner">The settings object to wrap</param>
		public ReadOnlyHoloLensTargetRules( HoloLensTargetRules Inner )
		{
			this.Inner = Inner;
		}
	}
	
	class HoloLensToolChain : UEToolChain
	{
		public override CPPOutput CompileCPPFiles(CppCompileEnvironment CompileEnvironment, List<FileItem> InputFiles,
			DirectoryReference OutputDir, string ModuleName, IActionGraphBuilder Graph)
		{
			return null;
		}

		public override FileItem LinkFiles( LinkEnvironment LinkEnvironment, bool bBuildImportLibraryOnly, IActionGraphBuilder Graph )
		{
			return null;
		}

		public static string GetVCIncludePaths(UnrealTargetPlatform Platform, WindowsCompiler Compiler)
		{
			return null;
		}
	}
}

// ETERNAL END - HOLOLENS
