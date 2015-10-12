/********************************************
-	    File Name: 
-	  Description: 
-	 	   Author: lijing,<979477187@qq.com>
-     Create Date: 2015.1.19  9:33
-Revision History: --
********************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseGameEntity : GameBehaviour
{
	private int m_ID;
	
	private static ArrayList m_idArray = new ArrayList();

	public int ID ()
	{
		return m_ID;
	}

	public void SetID (int val)
	{
		m_ID = val;

		EntityManager.Instance ().RegisterEntity(this);
	}

	public virtual bool HandleMessage (Telegram telegram) 
	{
		return false;
	}

	public void removeID(int actorID){
		if(m_idArray!=null){
			if (m_idArray.Contains(actorID)) {
				m_idArray.Remove(actorID);
			}else{
				Debug.LogError ("ID does not exist : "+actorID);
				return;
			}
		}
	}

}
