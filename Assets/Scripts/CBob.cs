using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CBob : MonoBehaviour
{
  public Canvas m_menu;
  bool interacting = false;

  // Start is called before the first frame update
  void Start()
  {
    m_menu = transform.Find("Canvas").GetComponent<Canvas>();
    m_menu.gameObject.SetActive(false);
  }

  // Update is called once per frame
  void Update()
  {
    //Quitar esto cuando ya se peuda interactuar
    if (Input.GetKeyDown(KeyCode.Alpha0))
    {
      
    }
  }

  public void Interact()
  {
    if (interacting)
    {
      CloseMenu();
    }
    else
    {
      OpenMenu();
    }
    
    Debug.Log("Interactuando con Bob. Hola amigos.");
  }

  void OpenMenu()
  {
      interacting = true;
      m_menu.gameObject.SetActive(true);
  }

  void CloseMenu()
  {
    interacting = false;
    m_menu.gameObject.SetActive(false);
  }


    public static void CheckMaterialsNeeded(CTool m_ToolInProgress)
  {
    int totalMaterialsNeeded = 0;
    for (int i = 0; i < m_ToolInProgress.m_materialListCount.Count; i++)
    {
      totalMaterialsNeeded += m_ToolInProgress.m_materialListCount[i];
    }

    if (totalMaterialsNeeded <= 0)
    {
      m_ToolInProgress = null;
      //give material
    }
    Debug.Log("Materiales restantes: " + totalMaterialsNeeded);
  }

}
