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
using System.Linq;

//实体模板类
public class EntityType<entity_type>
{
	public entity_type target;
	public string name;
}


public class EntityManager
{
	private static EntityManager instance;

	private Dictionary<int, BaseGameEntity> m_EntityMap = new Dictionary<int, BaseGameEntity> ();

	/// <summary>
	/// 获取实体
	/// </summary>
	/// <returns>The entity from I.</returns>
	/// <param name="ID">I.</param>
	public BaseGameEntity GetEntityFromID(int ID)
	{
		foreach(KeyValuePair<int ,BaseGameEntity> val in m_EntityMap)
		{
			if(val.Key == ID)
				return val.Value;
		}
		return null;
	}

	/// <summary>
	/// 移除实体
	/// </summary>
	/// <param name="pEntity">P entity.</param>
	public void RemoveEntity (BaseGameEntity pEntity)
	{
		int removeKey=-1;

		foreach(KeyValuePair<int ,BaseGameEntity> val in m_EntityMap)
		{
			if(val.Value == pEntity){
				removeKey=val.Key;
				break;
			}
		}

		if(removeKey>=0){
			m_EntityMap.Remove(removeKey);
		}
	}

	/// <summary>
	/// 注册实体
	/// </summary>
	/// <param name="NewEntity">New entity.</param>
	public void RegisterEntity (BaseGameEntity NewEntity)
	{
		m_EntityMap.Add (NewEntity.ID(),NewEntity);
	}
	
	public static EntityManager Instance ()
	{
		if (instance == null) {
			instance = new EntityManager ();
		}
		return instance;
	}
}
