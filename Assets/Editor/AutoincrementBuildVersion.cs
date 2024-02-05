using System;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace Editor
{
	public class AutoIncrementBuildVersion : MonoBehaviour
	{
		[PostProcessBuild (0)]
		public static void OnPostprocessBuild (BuildTarget buildTarget, string path)
		{
			// 1.2.3.4 maintenance major minor
			string[] currentVersion = PlayerSettings.bundleVersion.Split('.');

			try 
			{
				int major = Convert.ToInt32 (currentVersion[0]);
				int minor = Convert.ToInt32 (currentVersion[1]);
				int maintenance = Convert.ToInt32 (currentVersion[2]);
				int build = Convert.ToInt32 (currentVersion[3]);

				build ++;
				if(build % 10 == 0)
				{
					maintenance ++;
				}
				if(maintenance > 99)
				{
					maintenance = 0;
					minor ++;
				}
				if(minor > 9)
				{
					minor = 0;
					major ++;
				}

				string bundleVersion = $"{major}.{minor}.{maintenance}.{build}";
				PlayerSettings.bundleVersion = bundleVersion;
			}
			catch (Exception e) 
			{
				UnityEngine.Debug.LogError (e);
				UnityEngine.Debug.LogError ("AutoIncrementBuildVersion script failed. Make sure your current bundle version is in the format 1.2.3.4");
			}
		}
	}
}
