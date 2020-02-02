using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CBob : MonoBehaviour
{
    public Canvas m_menu;
    bool interacting = false;
    [SerializeField]
    [Range(5.0f, 10.0f)]
    private float m_interactRange = 7.0f;
    CPlayer m_player = null;

    public List<int> m_materialListCount = new List<int> { 0, 0, 0, 0, 0 }; //cloth, log, metal, nail, screw

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
            if (Vector3.Distance(m_player.transform.position, transform.position) > m_interactRange)
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

        if (m_player.CurrentPickupable != null && (m_player.CurrentPickupable as CMaterial) != null)
        {
            m_materialListCount[(int)((CMaterial)m_player.CurrentPickupable).type]++;
            Destroy(m_player.CurrentPickupable.gameObject);
            m_player.CurrentPickupable = null;
        }

        OpenMenu();
        //}

        Debug.Log("Interactuando con Bob. Hola amigos.");
    }

    CPlayer getPlayer()
    {
        return m_player;
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


    public void CheckMaterialsNeeded(CTool m_ToolInProgress)
    {
        /*
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
        */

        bool hasAll = false;
        for (int i = 0; i < m_materialListCount.Count; i++)
        {
            for (int e = 0; e < m_ToolInProgress.m_materialList.Count; e++)
            {
                if (i == (int)m_ToolInProgress.m_materialList[e])
                {
                    if (m_materialListCount[i] >= m_ToolInProgress.m_materialListCount[e])
                    {
                        m_materialListCount[i] -= m_ToolInProgress.m_materialListCount[e];
                        hasAll = true;
                    }
                    else
                    {
                        hasAll = false;
                    }
                }
            }
        }

        if (hasAll == true)
        {
            Debug.Log("All materials in inventory");
            var pickable = Instantiate(m_ToolInProgress, GameObject.Find("BobTable").transform.position + new Vector3(0,1,0), Quaternion.identity);
            pickable.Interact(m_player);
        }

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
