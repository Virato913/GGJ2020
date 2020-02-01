using UnityEngine;

public class CPlayerIdleState : CState<CPlayer>
{
  /// <summary>
  /// 
  /// </summary>
  /// <param name="stateMachine"></param>
  public CPlayerIdleState(CStateMachine<CPlayer> stateMachine) :
  base(stateMachine)
  { }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="entity"></param>
  public override void OnStatePostUpdate(CPlayer entity)
  {
    if(Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
    {
      m_stateMachine.ToState(entity.m_moveState, entity);
    }
  }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="entity"></param>
  public override void OnStateUpdate(CPlayer entity)
  {
    if (Input.GetButton("Jump"))
    {
      entity.Interact();
    }
  }
}
