using UnityEngine;

public class CFloorTile : CInteractable
{
  [SerializeField]
  private Vector3 m_LocalSpawnLocation;

  private CMaterial m_currentMaterial = null;

  private float m_timeToDestroy = 0.0f;

  private float m_elapsedTime = 0.0f;

  private Material m_material = null;

  private Color m_normalColor;

  private void FixedUpdate()
  {
    if(m_timeToDestroy > 0.0f)
    {
      m_elapsedTime += Time.fixedDeltaTime;
      m_material.SetColor("_EmissionColor", Color.red * (m_elapsedTime / m_timeToDestroy));
      if (m_elapsedTime > m_timeToDestroy)
      {
        m_material.SetColor("_EmissionColor", m_normalColor);
        m_material.DisableKeyword("_EMISSION");
        m_material = null;
        m_timeToDestroy = 0.0f;
        m_elapsedTime = 0.0f;
        var player = GameObject.FindGameObjectWithTag("Player");
        if (Vector3.Distance(transform.position, player.transform.position) < 2)
        {
          player.GetComponent<CPlayer>().EnterThrownState();
        }
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = true;
      }
    }
  }

  public void SpawnMaterial(CMaterial material)
  {
    if(m_currentMaterial == null)
    {
      m_currentMaterial = Instantiate(material, m_LocalSpawnLocation + transform.position, Quaternion.identity);
    }
  }

  public override void Interact(CPlayer player)
  {
    base.Interact(player);
    if ((player.CurrentPickupable as CTool) != null)
    {
      if ((player.CurrentPickupable as CTool).m_type == TOOL_TYPES.FLOOR)
      {
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<BoxCollider>().enabled = false;
        Destroy(player.CurrentPickupable.gameObject);
        CSceneManager.LoadFloorGame();
      }
    }
  }

  public bool CanSpawn
  {
    get { return (m_currentMaterial == null); }
  }

  public float TimeToDestroy
  {
    set
    {
      m_material = GetComponent<Renderer>().material;
      m_material.EnableKeyword("_EMISSION");
      m_normalColor = m_material.GetColor("_EmissionColor");
      m_elapsedTime = 0.0f;
      m_timeToDestroy = value;
    }
  }

#if UNITY_EDITOR
  void OnDrawGizmos()
  {
    Gizmos.color = Color.green;
    Gizmos.DrawSphere(m_LocalSpawnLocation + transform.position, 0.2f);
  }
#endif
}
