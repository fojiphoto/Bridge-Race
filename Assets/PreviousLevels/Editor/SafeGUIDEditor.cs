using UnityEditor;
using UnityEngine;
using System.IO;

public class SafeGUIDEditor : EditorWindow
{
    [MenuItem("Tools/Safe GUID Change")]
    public static void ShowWindow()
    {
        GetWindow<SafeGUIDEditor>("Safe GUID Change");
    }

    private void OnGUI()
    {
        GUILayout.Label("Change Script GUID Without Losing References", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        if (GUILayout.Button("Change GUID for Selected Script"))
        {
            ChangeGUIDForSelectedScript();
        }
    }

    private static void ChangeGUIDForSelectedScript()
    {
        // Get the selected script asset
        Object selectedAsset = Selection.activeObject;
        if (selectedAsset == null || !(selectedAsset is MonoScript))
        {
            Debug.LogError("Please select a script asset!");
            return;
        }

        string assetPath = AssetDatabase.GetAssetPath(selectedAsset);
        string metaPath = assetPath + ".meta";

        // Check if .meta file exists
        if (!File.Exists(metaPath))
        {
            Debug.LogError("Meta file not found for the selected script.");
            return;
        }

        // Read the meta file
        string metaFileContent = File.ReadAllText(metaPath);

        // Find the GUID line
        string guidLine = "guid:";
        int guidIndex = metaFileContent.IndexOf(guidLine);
        if (guidIndex == -1)
        {
            Debug.LogError("GUID not found in the meta file.");
            return;
        }

        // Extract the current GUID
        int guidStartIndex = guidIndex + guidLine.Length + 1;
        int guidEndIndex = metaFileContent.IndexOf("\n", guidStartIndex);
        string currentGUID = metaFileContent.Substring(guidStartIndex, guidEndIndex - guidStartIndex).Trim();

        // Generate a new GUID
        string newGUID = System.Guid.NewGuid().ToString("N");

        // Replace the old GUID with the new one
        metaFileContent = metaFileContent.Replace(currentGUID, newGUID);

        // Save the modified meta file
        File.WriteAllText(metaPath, metaFileContent);

        // Refresh Asset Database to apply the changes
        AssetDatabase.Refresh();

        // Ensure references are updated by reimporting
        AssetDatabase.ImportAsset(assetPath, ImportAssetOptions.ForceUpdate);

        // Log the new GUID
        Debug.Log("GUID changed successfully! New GUID: " + newGUID);
    }
}
