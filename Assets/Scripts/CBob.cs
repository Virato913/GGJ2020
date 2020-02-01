﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CBob : MonoBehaviour
{
  public Canvas m_menu;
  bool interacting = false;
  [SerializeField]
  [Range(5.0f, 10.0f)]
  private float m_interactRange = 7.0f;
  CPlayer m_player = null;

  static public List<int> m_materialListCount = new List<int> { 0, 0, 0, 0, 0 };

  // Start is called before the first frame update
  void Start()
  {
    m_menu = transform.Find("Canvas").GetComponent<Canvas>();
    m_menu.gameObject.SetActive(false);
  }

  // Update is called once per frame
  void Update()
  {
    if (m_player != null)
    {
      if (Vector3.Distance(    m_player.transform.position, transform.position) > m_interactRange)
      {
        m_player = null;
        CloseMenu();
      }
    }
  }

  public void Interact(CPlayer player)
  {
    //if (interacting)
    //{
    //    CloseMenu();
    //}
    //else
    //{
    m_player = player;
    OpenMenu();
    //}

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

#if UNITY_EDITOR
  public void OnDrawGizmos()
  {
    var collider = GetComponent<Collider>();
    Gizmos.color = Color.yellow;
    if (collider == null)
    {
      Gizmos.DrawWireSphere(transform.position, m_interactRange);
    }
    else
    {
      Gizmos.DrawWireSphere(collider.bounds.center, m_interactRange);
    }
  }
#endif

}
