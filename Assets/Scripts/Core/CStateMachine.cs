public class CStateMachine<T>
{
  internal CState<T> CurrentState { get; private set; }
  internal CState<T> PrevState { get; private set; }

  public void Init(CState<T> initialState, T entity)
  {
    CurrentState = initialState;
    PrevState = initialState;

    CurrentState.OnStateEnter(entity);
  }

  public void OnState(T entity, bool fixedUpdate = true)
  {
    CurrentState.OnStateUpdate(entity, fixedUpdate);
    CurrentState.OnStatePostUpdate(entity, fixedUpdate);
  }

  public void ToState(CState<T> nextState, T entity)
  {
    CurrentState.OnStateExit(entity);

    PrevState = CurrentState;
    CurrentState = nextState;

    CurrentState.OnStateEnter(entity);
  }

  internal bool IsCurrentState(params CState<T>[] compareStates)
  {
    return CurrentState.IsAnyOf(compareStates);
  }
}
