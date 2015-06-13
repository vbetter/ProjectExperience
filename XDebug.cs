/************************************************************
-	    File Name: XDebug
-	  Description: 1.封装常用的打印
				   2.全局设置是否打印
				   3.mcs -r:/Applications/Unity/Unity.app/Contents/Frameworks/Managed/UnityEngine.dll -target:library XDebug.cs
					生成dll，解决打印定位问题
				   4.特别注意 在用到协同和多线程的时候，XDebug.Log是可以用的 ，但是在UI上显示Log是不行的，因为UI更新必须在主线程下，所以应避免该情况。	
-	 	   Author: lijing,<979477187@qq.com>
-     Create Date: 2015.2.16  16:23
-Revision History: --
*************************************************************/
using UnityEngine;

namespace GFrame.Debuger{
	
	public class XDebug {
		/// <summary>
		/// /*全局控制是否打印.*/
		/// </summary>
		static public bool _enablePrint=false;

		public delegate void OnDoSomethingDelegate(string str);

		/// <summary>
		/// /*/* 委托事件 做某事后再打印.*/*/
		/// </summary>
		public event OnDoSomethingDelegate OnDoSomethingEvent;

		private static XDebug _instance = null;

		private XDebug(){

		}

		public static XDebug Instance()
		{
			if(_instance == null)
			{
				_instance = new XDebug();
			}
			return _instance;
		}

		/// <summary>
		/// /*打印的消息委托 做某事后再打印 */
		/// </summary>
		/// <param name="message">Message.</param>
		public void OnLogDoSomeThing(object message){
			
			OnDoSomethingEvent(message.ToString());
			
			Log(message,null);
		}

		//封装了一个常用的打印
		//例如 ---初始化:开始   ---初始化:结束
		//example:
		//XDebug.Log("123");  123
		//XDebug.StartDebug("aa");  ---aa:开始
		//XDebug.EndDebug("aa");	---aa:结束
		static public void StartDebug(string msg){
			string context=string.Format("---{0}:开始",msg);
			Log(context,null);
		}

		static public void EndDebug(string msg){
			string context=string.Format("---{0}:结束",msg);
			Log(context,null);
		}

		//log
		static public void Log(object message){
			Log(message,null);
		}

		static public void Log(object message , UnityEngine.Object context){
			if(_enablePrint){
				UnityEngine.Debug.Log(message,context);

			}
		}

		//logError
		static public void LogError(object message){
			LogError(message,null);
		}
		
		static public void LogError(object message, UnityEngine.Object context){
			if(_enablePrint){
				UnityEngine.Debug.LogError(message,context);
			}
		}

		//logWarning
		static public void LogWarning(object message){
			LogWarning(message,null);
		}
		
		static public void LogWarning(object message, UnityEngine.Object context){
			if(_enablePrint){
				UnityEngine.Debug.LogWarning(message,context);
			}
		}

		/// <summary>
		/// 用于简单测试输出1
		/// </summary>
		static public void Print1(){
			if(_enablePrint){
				UnityEngine.Debug.Log("1");
			}
		}

		/// <summary>
		/// 用于简单测试输出2
		/// </summary>
		static public void Print2(){
			if(_enablePrint){
				UnityEngine.Debug.Log("2");
			}
		}

		/// <summary>
		/// 用于简单测试输出3
		/// </summary>
		static public void Print3(){
			if(_enablePrint){
				UnityEngine.Debug.Log("3");
			}
		}

		/// <summary>
		/// 断言 obj不为空 ,为空报错
		/// </summary>
		/// <param name="obj">Object.</param>
		static public void Assert(object obj){
			if(_enablePrint){
				if(obj==null){
					UnityEngine.Debug.LogError(obj+" : is null");
				}
			}
		}
	}
}
