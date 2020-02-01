public class CPlayerStunState : CState<CPlayer>
{
  /// <summary>
  /// 
  /// </summary>
  /// <param name="stateMachine"></param>
  public CPlayerStunState(CStateMachine<CPlayer> stateMachine) :
  base(stateMachine)
  { }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="entity"></param>
  public override void OnStateEnter(CPlayer entity)
  {
    base.OnStateEnter(entity);
    entity.StunElapsedTime = 0.0f;
  }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="entity"></param>
  public override void OnStatePostUpdate(CPlayer entity, bool fixedUpdate = true)
  {
    if (fixedUpdate)
    {
      if (entity.StunElapsedTime >= entity.StunDuration)
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
    if (fixedUpdate)
    {
      entity.StunElapsedTime += UnityEngine.Time.fixedDeltaTime;
    }
  }
}
