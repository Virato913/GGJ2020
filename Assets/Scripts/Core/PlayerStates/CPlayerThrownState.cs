using System.Collections.Generic;
using UnityEngine;

public class CPlayerThrownState : CState<CPlayer>
{
  /// <summary>
  /// 
  /// </summary>
  /// <param name="stateMachine"></param>
  public CPlayerThrownState(CStateMachine<CPlayer> stateMachine) :
  base(stateMachine)
  { }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="entity"></param>
  public override void OnStateEnter(CPlayer entity)
  {
    base.OnStateEnter(entity);
    entity.ThrownElapsedTime = 0.0f;

    List<Vector3> directions = new List<Vector3>();
    Collider collider = entity.GetComponent<Collider>();
    RaycastHit hit;
    if (!Physics.Raycast(collider.bounds.center, Vector3.forward, out hit, 3.0f))
    {
      directions.Add(Vector3.forward);
    }
    if (!Physics.Raycast(collider.bounds.center, Vector3.right, out hit, 3.0f))
    {
      directions.Add(Vector3.right);
    }
    if (!Physics.Raycast(collider.bounds.center, Vector3.back, out hit, 3.0f))
    {
      directions.Add(Vector3.back);
    }
    if (!Physics.Raycast(collider.bounds.center, Vector3.left, out hit, 3.0f))
    {
      directions.Add(Vector3.left);
    }
    int item = Random.Range(0, directions.Count);
    entity.ThrownDirection = directions[item];

    
  }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="entity"></param>
  public override void OnStatePostUpdate(CPlayer entity, bool fixedUpdate = true)
  {
    if (fixedUpdate)
    {
      if (entity.ThrownElapsedTime >= entity.ThrownTime)
      {
        m_stateMachine.ToState(entity.m_stunState, entity);
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
      entity.transform.position +=
       (entity.ThrownDirection * (3.0f / entity.ThrownTime) * Time.fixedDeltaTime);
      entity.ThrownElapsedTime += Time.fixedDeltaTime;
    }
  }
}
