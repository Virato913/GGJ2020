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
  public override void OnStatePostUpdate(CPlayer entity, bool fixedUpdate = true)
  {
    if (!fixedUpdate)
    {
      if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
      {
        m_stateMachine.ToState(entity.m_moveState, entity);
      }
    }
  }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="entity"></param>
  public override void OnStateUpdate(CPlayer entity, bool fixedUpdate = true)
  {
    if (!fixedUpdate)
    {
      if (Input.GetButtonDown("Jump"))
      {
        entity.BeginInteract();
      }
      if (Input.GetButton("Jump"))
      {
        entity.OnInteract();
      }
      if (Input.GetButtonUp("Jump"))
      {
        entity.EndInteract();
      }
    }
  }
}
