using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace SparkTools
{
    [InitializeOnLoad]
    public class AutoVersion : UnityEditor.Build.IPreprocessBuild, UnityEditor.Build.IPostprocessBuild
    {
        private const string autoVersionLabel = "Automated";
        private static string playerSettings;

        static AutoVersion()
        {
            ResetEditorVersion();
        }

        public int callbackOrder { get { return 0; } }
        public void OnPreprocessBuild(BuildTarget target, string path)
        {
            SetBuildVersion(target);
        }

        public void OnPostprocessBuild(BuildTarget target, string path)
        {
            ResetEditorVersion();
        }

        public static void SetBuildVersion(BuildTarget target)
        {
            playerSettings = File.ReadAllText(Application.dataPath + "/../ProjectSettings/ProjectSettings.asset");

            string newVersion = GetGitVersion();

            if ((target == BuildTarget.Android || target == BuildTarget.iOS) && newVersion[0] == 'v' && char.IsNumber(newVersion[1]))
                newVersion = newVersion.Substring(1);

            PlayerSettings.bundleVersion = newVersion;

            Debug.Log("Build version set to " + newVersion);
        }

        private static void ResetEditorVersion()
        {
            if (playerSettings != null)
            {
                PlayerSettings.bundleVersion = autoVersionLabel;
                File.WriteAllText(Application.dataPath + "/../ProjectSettings/ProjectSettings.asset", playerSettings);
                AssetDatabase.ImportAsset("ProjectSettings/ProjectSettings.asset");
                playerSettings = null;
            }

            if (PlayerSettings.bundleVersion != autoVersionLabel)
            {
                PlayerSettings.bundleVersion = autoVersionLabel;
                AssetDatabase.SaveAssets();
                Debug.Log("Versioning is automated.");
            }
        }

        private static string GetGitVersion()
        {
            try
            {
                // Get the short commit hash of the current branch.
                string cmdArguments = "/c git update-index --refresh && git describe --always --broken";
                var procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", cmdArguments);

                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;

                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;

                // Now we create a process, assign its ProcessStartInfo and start it
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();

                // Get the output into a string
                string result = proc.StandardOutput.ReadToEnd().Split('\n')[0];

                if (result != null && result != "")
                {
                    return result;
                }
                else
                {
                    Debug.LogWarning("Unable to get git hash.");
                    return "version error";
                }
            }
            catch
            {
                Debug.LogWarning("Unable to get git hash.");
                return "version error";
            }
        }
    }
}