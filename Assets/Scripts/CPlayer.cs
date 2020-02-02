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
  private CPickupable m_currentPickupable = null;

  /// <summary>
  /// 
  /// </summary>
  [SerializeField]
  private Vector3 m_direction = new Vector3(0.0f, 0.0f, -1.0f);

  internal Vector3 m_moveDirection = new Vector3(0.0f, 0.0f, 0.0f);

  /// <summary>
  /// 
  /// </summary>
  [SerializeField]
  private Vector3 m_materialLocalLocation = new Vector3(0.0f, 0.0f, 0.0f);

  private float m_materialLocalRotation = 0.0f;

  private Vector3 m_materialLocation = new Vector3(0.0f, 0.0f, 0.0f);

  private bool m_isInteracting = false;
  /// <summary>
  /// 
  /// </summary>
  [SerializeField]
  private float m_interactRange = 3.0f;

  /// <summary>
  /// 
  /// </summary>
  [SerializeField]
  [Range(0.1f, 1.0f)]
  private float m_thrownTime = 0.5f;

  /// <summary>
  /// 
  /// </summary>
  private float m_thrownElapsedTime = 0.0f;

  /// <summary>
  /// 
  /// </summary>
  private Vector3 m_thrownDirection = new Vector3(0.0f, 0.0f, 0.0f);

  ///// <summary>
  ///// 
  ///// </summary>
  //private float m_thrownSpeed = 0.0f;
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

  /// <summary>
  /// 
  /// </summary>
  internal CPlayerThrownState m_thrownState = null;
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

  public void UpdateMaterialLocation()
  {
    //m_materialLocalRotation = transform.rotation.eulerAngles.y;
    //Vector3 localLocation = m_materialLocalLocation - transform.position;
    //Vector3.RotateTowards(localLocation, m_direction,
    // Mathf.Deg2Rad * Vector3.Angle(m_materialLocalLocation, m_direction), 10.0f);

    m_materialLocation = transform.position;
    m_materialLocation += m_materialLocalLocation.x * transform.right.normalized;
    m_materialLocation += m_materialLocalLocation.y * transform.up.normalized;
    m_materialLocation += m_materialLocalLocation.z * transform.forward;
  }

  public void DropMaterial(CPickupable material)
  {
    m_currentPickupable.transform.SetParent(null);
    m_currentPickupable.transform.position = material.transform.position;
    m_currentPickupable.GetComponent<Collider>().enabled = true;
    m_currentPickupable = null;
  }

  internal void OnInteract()
  {
    if (m_isInteracting)
    {
      var collider = GetComponent<Collider>();

      RaycastHit hit;
      Debug.DrawRay(collider.bounds.center, m_direction * m_interactRange, Color.red);
      // Does the ray intersect any objects excluding the player layer
      if (Physics.Raycast(collider.bounds.center, m_direction, out hit, m_interactRange))
      {
        if (hit.collider.gameObject.GetComponent<CBob>() != null)
        {
          hit.collider.gameObject.GetComponent<CBob>().Interact(this);
          EndInteract();
        }
        if (hit.collider.gameObject.GetComponent<CPickupable>() != null)
        {
          hit.collider.gameObject.GetComponent<CPickupable>().Interact(this);
          EndInteract();
        }
        Debug.Log("Did Hit");
      }
    }
  }

  public void BeginInteract()
  {
    if (!m_isInteracting)
      m_isInteracting = true;
  }

  public void EndInteract()
  {
    if (m_isInteracting)
      m_isInteracting = false;
  }

  public void EnterThrownState()
  {
    m_stateMachine.ToState(m_thrownState, this);
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

    if (m_thrownState == null)
    {
      m_thrownState = new CPlayerThrownState(m_stateMachine);
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

  void Update()
  {
    m_stateMachine.OnState(this, false);
  }

  /// <summary>
  /// 
  /// </summary>
  void FixedUpdate()
  {
    m_stateMachine.OnState(this, true);
    UpdateMaterialLocation();
    if (Input.GetKeyDown(KeyCode.E))
    {
      EnterThrownState();
    }
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

  public CPickupable CurrentPickupable
  {
    set { m_currentPickupable = value; }
    get { return m_currentPickupable; }
  }

  public Vector3 MaterialLocation
  {
    get { return m_materialLocation; }
  }

  public float ThrownTime
  {
    get { return m_thrownTime; }
  }

  public float ThrownElapsedTime
  {
    set { m_thrownElapsedTime = value; }
    get { return m_thrownElapsedTime; }
  }

  public Vector3 ThrownDirection
  {
    set { m_thrownDirection = value; }
    get { return m_thrownDirection; }
  }

  public Vector3 MoveDirection
  {
    set { m_moveDirection = value; }
    get { return m_moveDirection; }
  }
  #endregion

  #region Gizmos
#if UNITY_EDITOR
  private void OnDrawGizmos()
  {
    UpdateMaterialLocation();

    Gizmos.color = Color.blue;
    Gizmos.DrawLine(transform.position, transform.position + m_direction * InteractRange);

    Gizmos.color = Color.magenta;
    Gizmos.DrawSphere(m_materialLocation, 0.2f);
  }
#endif
  #endregion
}
