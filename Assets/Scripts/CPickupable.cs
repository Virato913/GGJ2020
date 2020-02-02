using UnityEngine;

public class CPickupable : CInteractable
{
  public override void Interact(CPlayer player)
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
