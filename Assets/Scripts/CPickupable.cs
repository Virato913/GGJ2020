using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPickupable : MonoBehaviour
{
  public void Interact(CPlayer player)
  {
    if (player.CurrentPickupable != null)
    {
      player.DropMaterial(this);
    }
    player.CurrentPickupable = this;
    transform.SetParent(player.transform);
    transform.position = player.MaterialLocation;
    GetComponent<Collider>().enabled = false;
  }
}
