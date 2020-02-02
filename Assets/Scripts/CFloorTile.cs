using UnityEngine;

public class CFloorTile : MonoBehaviour
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
