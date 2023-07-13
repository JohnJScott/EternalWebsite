// Copyright Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;

public class AllDesktopTargetPlatform : ModuleRules
{
	public AllDesktopTargetPlatform(ReadOnlyTargetRules Target) : base(Target)
	{
		PrivateDependencyModuleNames.AddRange(
			new string[]
			{
				"Core",
				"CoreUObject",
				"TargetPlatform",
				"DesktopPlatform",
				// ETERNAL BEGIN
				//"LaunchDaemonMessages",
				// ETERNAL END
				"Projects"
			}
		);

		// ETERNAL BEGIN
		if( PublicUEBuildPlatform.IsPlatformRegistered( UnrealTargetPlatform.IOS ) )
		{
			PrivateDependencyModuleNames.Add( "LaunchDaemonMessages" );
		}
		// ETERNAL END

		PrivateIncludePathModuleNames.AddRange(
			new string[] {
				"Messaging",
				"TargetDeviceServices",
			}
		);

		if (Target.bCompileAgainstEngine)
		{
			PrivateDependencyModuleNames.Add("Engine");
		}
	}
}
