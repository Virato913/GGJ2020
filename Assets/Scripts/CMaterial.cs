using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MatList
{
    Log = 0,
    Nail,
    Cloth,
    Metal,
    Screw
}

public class CMaterial : MonoBehaviour
{
  [SerializeField]
    private MatList m_type;

    public void Interact(CPlayer player)
  {
    if (player.CurrentMaterial != null)
    {

    }
    player.CurrentMaterial = this;
    transform.SetParent(player.transform);
    transform.position = player.MaterialLocation;
  }
}
