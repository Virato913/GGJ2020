using UnityEngine;

public class CInteractable : MonoBehaviour
{
  public virtual void Interact(CPlayer player)
  {
    Debug.Log(player.ToString() + " interacting with " + this.ToString());
  }
}
