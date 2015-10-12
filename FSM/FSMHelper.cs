/********************************************
-	    File Name: 
-	  Description: 
-	 	   Author: lijing,<979477187@qq.com>
-     Create Date: 2015.1.19  9:33
-Revision History: --
********************************************/
using UnityEngine;
using System.Collections;

namespace GFrame.FSM{
	/*
	 * 该UID用于FSM中的唯一ID，该值是一个基础值，用以加上角色的站位达到唯一ID的目的
	 */
	public enum FSM_BaseID{
		Battle_fsmID=10,
		//普通角色
		HeroBaseID=10000,
		EnemyBaseID=20000,
		//技能克隆出来的分身
		CloneHeroBaseID=30000,
		CloneEnemyBaseID=40000,
	}

	public enum FSM_MSG{
		Battle_Heal=50,//战斗结束后治疗玩家
		Battle_AllAttack,//全体攻击，例如集火
		Actor_Attack,//角色间发消息
		Actor_Heal,//治疗
		Actor_Buff,//Buff/Debuff
		Actor_ContinuousSkill,//持续技能
	}

	public class FSMHelper : MonoBehaviour {
		
	}
}
