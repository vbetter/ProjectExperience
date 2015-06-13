using UnityEngine;
using UnityEditor;

public class ExportAssetBundles : MonoBehaviour {
  
	[MenuItem("Assets/Build AssetBundle From Selection")]  
	static void ExportResourceRGB2()  
	{  
		// Open the save panel, access path selected by the user 
		string path = EditorUtility.SaveFilePanel("Save Resource", "", "New Resource", "assetbundle");  
		
		if (path.Length != 0)  
		{  
			// Select the object you want to save 
			Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);  
			//package  
			BuildPipeline.BuildAssetBundle(Selection.activeObject, selection, path, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, BuildTarget.StandaloneWindows);  
		}  
	}

	[MenuItem("Assets/Save Scene")]
	static void ExportScene()
	{
		// Open the save panel, access path selected by the user
		string path = EditorUtility.SaveFilePanel("Save Resource", "", "New Resource", "unity3d");
		
		if (path.Length != 0)
		{
			// Select the object you want to save 
			//Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
			string[] scenes = {"Assets/scene1.unity"};
			//package 
			BuildPipeline.BuildPlayer(scenes,path,BuildTarget.StandaloneWindows,BuildOptions.BuildAdditionalStreamedScenes);
		}
	}
}
