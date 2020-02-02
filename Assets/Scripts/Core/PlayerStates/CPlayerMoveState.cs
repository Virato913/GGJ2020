using UnityEngine;
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
  public override void OnStatePostUpdate(CPlayer entity, bool fixedUpdate = true)
  {
    if (!fixedUpdate)
    {
      if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
      {
        m_stateMachine.ToState(entity.m_idleState, entity);
      }
    }
  }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="entity"></param>
  public override void OnStateUpdate(CPlayer entity, bool fixedUpdate = true)
  {
    Vector3 direction = new Vector3();
    if (!fixedUpdate)
    {
      direction.x = Input.GetAxisRaw("Horizontal");
      direction.y = 0;
      direction.z = Input.GetAxisRaw("Vertical");
      entity.MoveDirection = direction;
    }

    if (fixedUpdate)
    {
      entity.Move(entity.MoveDirection);
    }

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
