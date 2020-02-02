using UnityEngine;

public class CFloorTile : CInteractable
{
  [SerializeField]
  private Vector3 m_LocalSpawnLocation;

  private CMaterial m_currentMaterial = null;

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
      }
    }
  }

  public bool CanSpawn
  {
    get { return (m_currentMaterial == null); }
  }

#if UNITY_EDITOR
  void OnDrawGizmos()
  {
    Gizmos.color = Color.green;
    Gizmos.DrawSphere(m_LocalSpawnLocation + transform.position, 0.2f);
  }
#endif
}
