using UnityEditor;
using UnityEngine;
using System.IO;

public class GUIDChangerWindow : EditorWindow
{
    private Object selectedAsset;

    [MenuItem("Tools/GUID Changer")]
    public static void ShowWindow()
    {
        GetWindow<GUIDChangerWindow>("GUID Changer");
    }

    private void OnGUI()
    {
        GUILayout.Label("Change Asset GUID", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        // Drag-and-Drop Field
        selectedAsset = EditorGUILayout.ObjectField("Asset", selectedAsset, typeof(Object), false);

        if (selectedAsset != null)
        {
            // Get the path of the selected asset
            string assetPath = AssetDatabase.GetAssetPath(selectedAsset);

            if (GUILayout.Button("Change GUID"))
            {
                ChangeGUID(assetPath);
            }
        }
        else
        {
            EditorGUILayout.HelpBox("Drag and drop an asset to change its GUID.", MessageType.Info);
        }
    }

    private void ChangeGUID(string assetPath)
    {
        string metaPath = assetPath + ".meta";

        if (!File.Exists(metaPath))
        {
            Debug.LogError("Meta file not found for the given asset!");
            return;
        }

        // Read the meta file
        string[] metaContents = File.ReadAllLines(metaPath);

        // Generate new GUID
        string newGUID = System.Guid.NewGuid().ToString();

        // Replace the GUID in meta file
        for (int i = 0; i < metaContents.Length; i++)
        {
            if (metaContents[i].StartsWith("guid:"))
            {
                metaContents[i] = "guid: " + newGUID;
                break;
            }
        }

        // Write the new meta file
        File.WriteAllLines(metaPath, metaContents);

        Debug.Log($"GUID changed for {assetPath} to {newGUID}");
        AssetDatabase.Refresh();
    }
}
