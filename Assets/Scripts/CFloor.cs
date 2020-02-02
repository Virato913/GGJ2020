using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFloor : MonoBehaviour
{
     public GameObject[] m_floor; //all cells of floor prefab

    public float m_destroyTimeCounter; //timing counter for destroying object
    public float m_appearMaterialCounter; // timing counter for spawning materials
    public float m_randomDestroyTime;//time to destroy floor tile
    public float m_randomAppearMaterialTime; //time to appear materials
    CMaterial m_randomMaterial; //member to instantiate from a random of the material enum
    public int m_randomFloor;//random floor index
    public MatList m_logId = MatList.Log;
    public CMaterial[] m_materialList = GameObject.FindObjectsOfType<CMaterial>();
    CPlayer m_player = null;
    // Start is called before the first frame update
    void Start()
    {
        m_floor = GameObject.FindGameObjectsWithTag("floor");
        m_player = GameObject.FindObjectOfType<CPlayer>();
        m_destroyTimeCounter = 0;
        m_randomDestroyTime = Random.Range(10, 15);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_destroyTimeCounter += Time.fixedDeltaTime;
        m_randomAppearMaterialTime += Time.fixedDeltaTime;

        if (m_destroyTimeCounter > m_randomDestroyTime)
        {
            m_destroyTimeCounter = 0;
            m_randomDestroyTime = Random.Range(10, 15);
            destroyRandom();
        }

        if (m_appearMaterialCounter > m_randomAppearMaterialTime)
        {
            m_appearMaterialCounter = 0;
            m_randomAppearMaterialTime = Random.Range(5, 9);
            generateRandomMaterials();
           
        }
    }

    void destroyRandom()
    {
        m_randomFloor = Random.Range(0, m_floor.Length);
       
        m_floor[m_randomFloor].GetComponent<MeshRenderer>().enabled = false;
        m_floor[m_randomFloor].GetComponent<BoxCollider>().enabled = true;

        if(Vector3.Distance(m_floor[m_randomFloor].transform.position, m_player.transform.position) < 2)
        {
            m_player.EnterThrownState();
        }
    }

    public override void Interact(CPlayer player)
    {
        base.Interact(player);
        m_player = player;
        if((m_player.CurrentPickupable as CMaterial) != null) {
           if((m_player.CurrentPickupable as CMaterial).type == m_logId) {
                m_floor[m_randomFloor].GetComponent<MeshRenderer>().enabled = true;
                m_floor[m_randomFloor].GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    void generateRandomMaterials()
    {
        m_randomFloor = Random.Range(0, m_floor.Length);

        int x = Random.Range(0, 5);
        if(x == 0)
        {
            m_randomMaterial = m_materialList[0];
        }
        else if ( x == 1)
        {
            m_randomMaterial = m_materialList[1];
        }
        else if (x == 2)
        {
            m_randomMaterial = m_materialList[2];
        }
        else if (x == 3)
        {
            m_randomMaterial = m_materialList[3];
        }
        else if (x == 4)
        {
            m_randomMaterial = m_materialList[4];
        }

        //if(m_floor[m_randomFloor].GetComponent<MeshRenderer>().enabled == true)
        //{
        //    CMaterial instance = Instantiate(m_randomMaterial);
        //}

        while(m_floor[m_randomFloor].GetComponent<MeshRenderer>().enabled != true)
        {
            m_randomFloor = Random.Range(0, m_floor.Length);
        }
        CMaterial instance = Instantiate(m_randomMaterial);

        instance.transform.position = m_floor[m_randomFloor].transform.position;
    }
}
