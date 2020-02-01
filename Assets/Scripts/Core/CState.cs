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

  public abstract void OnStatePostUpdate(T entity);

  public abstract void OnStateUpdate(T entity);

  public virtual void OnStateExit(T entity) { }

  protected readonly CStateMachine<T> m_stateMachine;
}
