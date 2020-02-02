using UnityEngine;
public abstract class CState<T>
{
  public CState(CStateMachine<T> stateMachine)
  {
    m_stateMachine = stateMachine;
  }

  public virtual void OnStateEnter(T entity)
  {
    Debug.Log(entity.ToString() + " entered " + this.ToString());
  }

  public abstract void OnStatePostUpdate(T entity, bool fixedUpdate = true);

  public abstract void OnStateUpdate(T entity, bool fixedUpdate = true);

  public virtual void OnStateExit(T entity) { }

  protected readonly CStateMachine<T> m_stateMachine;
}
