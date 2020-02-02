using UnityEngine;

public class CFloor : CInteractable
{
     public GameObject[] m_floor; //all cells of floor prefab

    public float m_timeCounter; //timing counter 
    public float m_randomTime;
    public int m_randomFloor;
    public MatList m_logId = MatList.Log;
    CPlayer m_player = null;
    // Start is called before the first frame update
    void Start()
    {
        m_floor = GameObject.FindGameObjectsWithTag("floor");
        m_player = FindObjectOfType<CPlayer>();
        m_timeCounter = 0;
        m_randomTime = Random.Range(10, 15);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_timeCounter += Time.fixedDeltaTime;
        
        if (m_timeCounter > m_randomTime)
        {
            m_timeCounter = 0;
            m_randomTime = Random.Range(10, 15);
            destroyRandom();
        }
    }

    void destroyRandom()
    {
        m_randomFloor = Random.Range(0, m_floor.Length);
        
        m_randomFloor = Random.Range(0, m_floor.Length);
        m_floor[m_randomFloor].GetComponent<MeshRenderer>().enabled = false;
        m_floor[m_randomFloor].GetComponent<BoxCollider>().enabled = true;
        if(((m_floor[m_randomFloor].transform.position.x + 3 > m_player.transform.position.x) 
            || (m_floor[m_randomFloor].transform.position.x < m_player.transform.position.x))
            && ((m_floor[m_randomFloor].transform.position.z + 3 > m_player.transform.position.z) 
            || (m_floor[m_randomFloor].transform.position.z < m_player.transform.position.z)))
        {
            m_player.EnterThrownState();
        }

    }

    public override void Interact(CPlayer player)
    {
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
        
    }
}
