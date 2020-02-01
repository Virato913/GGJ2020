﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFloor : MonoBehaviour
{
    GameObject[] m_floor; //all cells of floor prefab

    public float m_timeCounter; //timing counter 
    public float m_randomTime;
    // Start is called before the first frame update
    void Start()
    {
        m_floor = GameObject.FindGameObjectsWithTag("floor");
        m_timeCounter = 0;
        m_randomTime = Random.Range(10, 15);
        //m_floor[14].GetComponent<MeshRenderer>().enabled = false;
        //m_floor[14].GetComponent<BoxCollider>().enabled = true;
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
        int x = Random.Range(0, m_floor.Length);
        m_floor[x].GetComponent<MeshRenderer>().enabled = false;
        m_floor[x].GetComponent<BoxCollider>().enabled = true;
    }
}
