/********************************************
-	    File Name: 
-	  Description: 
-	 	   Author: lijing,<979477187@qq.com>
-     Create Date: 2015.10.12  9:33
-Revision History: --
********************************************/

using UnityEngine;
using System.Collections;

//C# 状态基类
public class State<entity_type>
{
	
	public entity_type Target ;
	  
	public virtual void Enter (entity_type entityType)
	{
		
	}
	
	public virtual void Execute (entity_type entityType)
	{
		
	}
	
	public virtual void Exit (entity_type entityType)
	{
		
	}
	
	public virtual bool OnMessage (entity_type entityType, Telegram telegram)
	{
		return false;
	}
}


