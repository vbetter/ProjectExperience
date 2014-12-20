using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if(GUILayout.Button("OPEN Activity01",GUILayout.Height(100)))
		{
			//注解1
			using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
			{
				using( AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"))
				{
					//调用Android插件中UnityTestActivity中StartActivity0方法，stringToEdit表示它的参数
					jo.Call("add",1);
				}
			}
		}
		if(GUILayout.Button("OPEN Activity02",GUILayout.Height(100)))
		{

		}
	}

	public void receiveMessage(string str){
		Debug.Log(str);
	}
}
