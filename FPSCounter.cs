/************************************************************
-	    File Name: FPSCounter
-	  Description: 
-	 	   Author: lijing,<979477187@qq.com>
-     Create Date: 2014.11.19  16:23
-Revision History: --
*************************************************************/

using UnityEngine;
using System.Collections;


public class FPSCounter :MonoBehaviour{

	public Rect startRect= new Rect(10,10,75,50);
	string _sFPS="";
	
	//FPS counter
	float _fps=0;
	private int frames = 0;
	private double lastInterval;
	public float updateInterval = 0.5F;

	public float FPS{
		get{ return _fps;}
	}
	
	void Start () {
		lastInterval = Time.realtimeSinceStartup;
	}

	void Update(){
		++frames;
		float timeNow = Time.realtimeSinceStartup;
		if (timeNow > lastInterval + updateInterval)
		{
			_fps = (float)(frames / (timeNow - lastInterval));
			frames = 0;
			lastInterval = timeNow;
			_sFPS=_fps.ToString("F2");
		}
	}

	void OnGUI(){
		GUI.Window(0,startRect,doMyWindow,"");
	}
	
	void doMyWindow(int windowID){
		GUIStyle style=new GUIStyle(GUI.skin.label);
		style.normal.textColor=Color.green;
		style.alignment=TextAnchor.MiddleCenter;
		
		GUI.Label(new Rect(0,0,startRect.width,startRect.height),_sFPS+" FPS",style);
	}
}
