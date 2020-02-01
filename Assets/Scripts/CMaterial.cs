using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MatList
{
    Cloth = 0,
    Log,
    Metal,
    Nail,
    Screw
}

public class CMaterial : MonoBehaviour
{
  [SerializeField]
    private MatList m_type;

    public MatList type
    {
        get { return m_type; }
    }

    public void Interact(CPlayer player)
  {
    if (player.CurrentMaterial != null)
    {
      player.DropMaterial(this);
    }
    player.CurrentMaterial = this;
    transform.SetParent(player.transform);
    transform.position = player.MaterialLocation;
    GetComponent<Collider>().enabled = false;
  }
}
