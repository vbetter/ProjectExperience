/********************************************
-	    File Name: 
-	  Description: 
-	 	   Author: lijing,<979477187@qq.com>
-     Create Date: 2015.10.12  9:33
-Revision History: --
********************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Telegram
{

	public int Sender;

	public int Receiver;

	public int Msg;
	
	public float DispatchTime;
	
	public MonoBehaviour _Behaviour;
	
	

	public Telegram (float atime, int asender, int areceiver, int amsg,MonoBehaviour _Be)
	{
		DispatchTime = atime;
		Sender = asender;
		Receiver = areceiver;
		Msg = amsg;
		_Behaviour = _Be;
	}
	
}

public class MessageDispatcher
{


	public float SEND_MSG_IMMEDIATELY = 0.0f;
	public int NO_ADDITIONAL_INFO = 0;
	public int SENDER_ID_IRRELEVANT = -1;

	private static MessageDispatcher instance;

	private IList<Telegram> PriorityQ = new List<Telegram> ();

	private void Discharge (BaseGameEntity pReceiver, Telegram telegram)
	{
		if (!pReceiver.HandleMessage (telegram)) {
			Debug.LogError ("Message can not be resolved");
		}
	}
	
	public void DispatchMessage (float delay, int sender, int receiver, int msg , MonoBehaviour _be)
	{
		//通过id获取接收者
		BaseGameEntity pReceiver = EntityManager.Instance ().GetEntityFromID (receiver);

		//初始化一个消息 
		Telegram telegram = new Telegram (0, sender, receiver, msg,_be);
		
		if (delay <= 0.0f) {
			
			//立即发送消息 
			Discharge (pReceiver, telegram);

		} else {
			
			//延时发送消息
			//延时发送可能会有bug，慎用

			float CurrentTime = Time.realtimeSinceStartup;
			
			telegram.DispatchTime = CurrentTime + delay;

			foreach(Telegram val in PriorityQ)
			{
				if(val.Sender == sender && val.Receiver == receiver && val.Msg ==msg)
				{
					return ;
				}
			}

			PriorityQ.Add (telegram);
			
		}
		
	}

	//延时处理消息
	public void DispatchDelayedMessages ()
	{
		//获取游戏开始实时时间
		float CurrentTime = Time.realtimeSinceStartup;
		
		for(int i = 0 ;i < PriorityQ.Count ; i++)
		{
			Telegram val  = PriorityQ[i];
			if (val.DispatchTime < CurrentTime && val.DispatchTime > 0f) {
				//延时结束
				BaseGameEntity pReceiver = EntityManager.Instance ().GetEntityFromID (val.Receiver);
				//发送消息
				Discharge (pReceiver, val);
				//从列表中移除消息
				PriorityQ.RemoveAt(i);
			}
		}
	}
	
	public static MessageDispatcher Instance ()
	{
		if (instance == null) {
			instance = new MessageDispatcher ();
		}
		return instance;
	}
}
