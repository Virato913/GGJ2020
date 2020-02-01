using UnityEngine;

public class CPlayer : MonoBehaviour
{
  #region Members
  /// <summary>
  /// 
  /// </summary>
  [SerializeField]
  [Range(1.0f, 10.0f)]
  private float m_moveSpeed = 1.0f;

  /// <summary>
  /// 
  /// </summary>
  [SerializeField]
  [Range(2.0f, 7.0f)]
  private float m_stunDuration = 5.0f;

  /// <summary>
  /// 
  /// </summary>
  internal float m_stunElapsedTime = 0.0f;

  /// <summary>
  /// 
  /// </summary>
  private CMaterial m_currentMaterial = null;

  /// <summary>
  /// 
  /// </summary>
  private CTool m_currentTool = null;

  /// <summary>
  /// 
  /// </summary>
  [SerializeField]
  private Vector3 m_direction = new Vector3(0.0f, 0.0f, -1.0f);

  /// <summary>
  /// 
  /// </summary>
  [SerializeField]
  private float m_interactRange = 3.0f;
  #region State Machine
  /// <summary>
  /// 
  /// </summary>
  private CStateMachine<CPlayer> m_stateMachine = null;

  /// <summary>
  /// 
  /// </summary>
  internal CPlayerIdleState m_idleState = null;

  /// <summary>
  /// 
  /// </summary>
  internal CPlayerInteractState m_interactState = null;

  /// <summary>
  /// 
  /// </summary>
  internal CPlayerMoveState m_moveState = null;

  /// <summary>
  /// 
  /// </summary>
  internal CPlayerStunState m_stunState = null;
  #endregion
  #endregion

  #region Methods
  /// <summary>
  /// 
  /// </summary>
  /// <param name="direction"></param>
  internal void Move(Vector3 direction)
  {
    Vector3 currentPos = transform.position;

    currentPos += (direction * Time.fixedDeltaTime * m_moveSpeed);

    transform.position = currentPos;

    if (direction.magnitude != 0)
    {
      m_direction = direction;
    }

    UpdateRotation();
  }

  public void UpdateRotation()
  {
    var rotation = transform.rotation;
    rotation.eulerAngles =
      new Vector3(0.0f, Vector3.SignedAngle(Vector3.right, m_direction, Vector3.up) + 90.0f, 0.0f);
    transform.rotation = rotation;
  }

  internal void Interact()
  {
    var collider = GetComponent<Collider>();

    RaycastHit hit;
    Debug.DrawRay(collider.bounds.center, m_direction * m_interactRange, Color.red);
    // Does the ray intersect any objects excluding the player layer
    if (Physics.Raycast(collider.bounds.center, m_direction, out hit, m_interactRange))
    {
      if (hit.collider.gameObject.GetComponent<CBob>() != null)
      {
        hit.collider.gameObject.GetComponent<CBob>().Interact();
      }
      Debug.Log("Did Hit");
    }
  }

  private void InitStateMachine()
  {
    if (m_stateMachine == null)
    {
      m_stateMachine = new CStateMachine<CPlayer>();
    }

    if (m_idleState == null)
    {
      m_idleState = new CPlayerIdleState(m_stateMachine);
    }

    if (m_interactState == null)
    {
      m_interactState = new CPlayerInteractState(m_stateMachine);
    }

    if (m_moveState == null)
    {
      m_moveState = new CPlayerMoveState(m_stateMachine);
    }

    if (m_stunState == null)
    {
      m_stunState = new CPlayerStunState(m_stateMachine);
    }

    m_stateMachine.Init(m_idleState, this);
  }
  /// <summary>
  /// 
  /// </summary>
  void Start()
  {
    InitStateMachine();
    UpdateRotation();
  }

  /// <summary>
  /// 
  /// </summary>
  void FixedUpdate()
  {
    m_stateMachine.OnState(this);
  }
  #endregion

  #region Properties
  public Vector3 Direction
  {
    set { m_direction = value; }
    get { return m_direction; }
  }

  public float InteractRange
  {
    set { m_interactRange = value; }
    get { return m_interactRange; }
  }

  public float StunDuration
  {
    get { return m_stunDuration; }
  }

  public float StunElapsedTime
  {
    set { m_stunElapsedTime = value; }
    get { return m_stunElapsedTime; }
  }
  #endregion

  #region Gizmos
#if UNITY_EDITOR
  private void OnDrawGizmos()
  {
    Gizmos.color = Color.blue;
    Gizmos.DrawLine(transform.position, transform.position + m_direction * InteractRange);
  }
#endif
  #endregion
}
