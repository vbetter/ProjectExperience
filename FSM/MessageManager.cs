/********************************************
-	    File Name: 
-	  Description: 
-	 	   Author: lijing,<979477187@qq.com>
-     Create Date: 2015.10.12  9:33
-Revision History: --
********************************************/
using UnityEngine;
using System.Collections;

public class MessageManager : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		MessageDispatcher.Instance().DispatchDelayedMessages();
	}
}
