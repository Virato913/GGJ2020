﻿using UnityEngine;
public class CPlayerMoveState : CState<CPlayer>
{
  /// <summary>
  /// 
  /// </summary>
  /// <param name="stateMachine"></param>
  public CPlayerMoveState(CStateMachine<CPlayer> stateMachine) :
  base(stateMachine)
  { }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="entity"></param>
  public override void OnStatePostUpdate(CPlayer entity)
  {
    if(Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
    {
      m_stateMachine.ToState(entity.m_idleState, entity);
    }
  }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="entity"></param>
  public override void OnStateUpdate(CPlayer entity)
  {
    Vector2 direction = new Vector2();
    direction.x = Input.GetAxisRaw("Horizontal");
    direction.y = Input.GetAxisRaw("Vertical");

    entity.Move(direction.normalized);

    if (Input.GetButtonDown("Jump"))
    {
      entity.Interact();
    }
  }
}
