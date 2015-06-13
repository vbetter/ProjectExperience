/********************************************
-	    File Name: 
-	  Description: 该脚本用来批量生成预设，使用方法把所选对象拖入Hierarchy面板，全选之，点击Tools/从选择的物体保存预设,已应用到批量生成音频预设
-	 	   Author: lijing,<979477187@qq.com>
-     Create Date: 2015.5.19  9:33
-Revision History: --
********************************************/
using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

public class SpawnPrefabs : MonoBehaviour {

	static string UIAudio_Path="Assets/Resources/AudioPrefabs/UIAudio/";//UI音效预设保存路径
	static string BattleAudio_Path="Assets/Resources/AudioPrefabs/BattleAudio/";//Battle音效预设保存路径

	// Use this for initialization
	void Start () {
	
	}

	#region UI Audio
	[MenuItem("Tools/从选择的物体保存UI音效预设")]static public void CreatPrefab_UI(){
		GameObject[] objs = Selection.gameObjects;
		foreach(GameObject obj in objs){
			CreatPrefab(obj,UIAudio_Path);
		}
	}
	
	[MenuItem("Tools/从选择的物体保存UI音效预设", true)]
	static bool ValidateCreatePrefab_UI(){
		return Selection.activeGameObject != null;
	}

	#endregion


	#region Battle Audio

	[MenuItem("Tools/从选择的物体保存Battle音效预设")]static public void CreatPrefab_Battle(){
		GameObject[] objs = Selection.gameObjects;
		foreach(GameObject obj in objs){
			CreatPrefab(obj,BattleAudio_Path);
		}
	}
	
	[MenuItem("Tools/从选择的物体保存Battle音效预设", true)]
	static bool ValidateCreatePrefab_Battle(){
		return Selection.activeGameObject != null;
	}

	#endregion

//	[MenuItem("Tools/保存场景中的预设实例")]
//	public static void SavePrefabAll(){
//		List<GameObject> prefabObjs = new List<GameObject>();
//		//获取当前场景里的所有游戏对象
//		GameObject []rootObjects = (GameObject[])UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
//		foreach(GameObject go in rootObjects){
//			//判断是否是预设实例
//			if(PrefabUtility.GetPrefabType(go) == PrefabType.PrefabInstance){
//				//获取预设根物体保存到List
//				GameObject prefabRoot = PrefabUtility.FindRootGameObjectWithSameParentPrefab(go);
//				if(!prefabObjs.Contains(prefabRoot)){
//					prefabObjs.Add(prefabRoot);
//				}
//			}
//		}
//		foreach(GameObject go in prefabObjs){
//			//这里要用自己的保存prefab的路径
//			string localpath = MyPath+go.name+".prefab";
//			CreatNew(go, localpath);
//		}
//		//保存
//		AssetDatabase.SaveAssets();
//	}
	
	static void CreatPrefab(GameObject obj,string path){
		//这里要用自己的保存prefab的路径
		string localpath = path+obj.name+".prefab";
		//判断预设资源是否存在
		if(AssetDatabase.LoadAssetAtPath(localpath, typeof(GameObject))){
//			if(EditorUtility.DisplayDialog("预设已经存在", "是否重置？", "yes", "no")){
//				CreatNew(obj, localpath);
//			}
			CreatNew(obj, localpath);
		}
		else
			CreatNew(obj, localpath);
	}
	
	static void CreatNew(GameObject go, string path){
		Object prefab = PrefabUtility.CreatePrefab(path, go);
		PrefabUtility.ReplacePrefab(go, prefab, ReplacePrefabOptions.ConnectToPrefab);
	}
}
