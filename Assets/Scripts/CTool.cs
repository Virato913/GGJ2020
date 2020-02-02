using System.Collections.Generic;

public enum TOOL_TYPES
{
    FLOOR = 0,
    GEAR,
    PIPE,
    PLATE,
    WING
}

public class CTool : CPickupable
{
  public TOOL_TYPES m_type;
  public string m_name;
  public List<MatList> m_materialList;
  public List<int> m_materialListCount;

  //     public void Interact(CPlayer player)
  //     {
  //         if (player.CurrentTool != null)
  //         {
  //             //player.DropMaterial(this);
  //             //drop Tool/Piece
  //         }
  //         player.CurrentTool = this;
  //         transform.SetParent(player.transform);
  //         transform.position = player.MaterialLocation;
  //         GetComponent<Collider>().enabled = false;
  //     }
}
