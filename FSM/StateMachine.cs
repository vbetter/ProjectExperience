/********************************************
-	    File Name: 
-	  Description: 
-	 	   Author: lijing,<979477187@qq.com>
-     Create Date: 2015.10.12  9:33
-Revision History: --
********************************************/

using UnityEngine;
using System.Collections;

public class StateMachine<entity_type>
{
	//实体对象
	private entity_type m_pOwner;
	//当前状态
	private State<entity_type> m_pCurrentState;
	//上一个状态
	private State<entity_type> m_pPreviousState;
	//全局状态
	private State<entity_type> m_pGlobalState;

	public StateMachine (entity_type owner)
	{
		m_pOwner = owner;
		m_pCurrentState = null;
		m_pPreviousState = null;
		m_pGlobalState = null;
	}
	
	public void GlobalStateEnter()
	{
		m_pGlobalState.Enter(m_pOwner);
	}
	
	public void SetGlobalStateState(State<entity_type> GlobalState)
	{
		m_pGlobalState = GlobalState;
		m_pGlobalState.Target = m_pOwner;
		m_pGlobalState.Enter(m_pOwner);
	}
	
	public void SetCurrentState(State<entity_type> CurrentState)
	{
		m_pCurrentState = CurrentState;
		m_pCurrentState.Target = m_pOwner;
		m_pCurrentState.Enter(m_pOwner);
	}

	public void SMUpdate ()
	{
		//更新全局状态
		if (m_pGlobalState != null)
			m_pGlobalState.Execute (m_pOwner);
		
		//更新当前状态
		if (m_pCurrentState != null)
			m_pCurrentState.Execute (m_pOwner);
	}

	//改变状态
	public void ChangeState (State<entity_type> pNewState)
	{
		if (pNewState == null) {
			Debug.LogError ("Current state is not exist : " + pNewState.ToString());
		}
		
		m_pCurrentState.Exit(m_pOwner);

		m_pPreviousState = m_pCurrentState;
		
		m_pCurrentState = pNewState;
		m_pCurrentState.Target = m_pOwner;

		m_pCurrentState.Enter (m_pOwner);
	}

	//返回上一个状态
	public void RevertToPreviousState ()
	{
		ChangeState (m_pPreviousState);
	}

	#region State Property

	public State<entity_type> CurrentState ()
	{
		return m_pCurrentState;
	}

	public State<entity_type> GlobalState ()
	{
		return m_pGlobalState;
	}

	public State<entity_type> PreviousState ()
	{
		return m_pPreviousState;
	}

	#endregion

	/// <summary>
	/// 处理消息接收
	/// </summary>
	/// <returns><c>true</c>, if message was handled, <c>false</c> otherwise.</returns>
	/// <param name="msg">Message.</param>
	public bool HandleMessage (Telegram msg)
	{
		//当前态接收消息
		if (m_pCurrentState!=null && m_pCurrentState.OnMessage (m_pOwner, msg)) {
			return true;
		}

		//全局态接收消息
		if (m_pGlobalState!=null && m_pGlobalState.OnMessage (m_pOwner, msg)) {
			return true;
		}
		
		return false;
	}
}
