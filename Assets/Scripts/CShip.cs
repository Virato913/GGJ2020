using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CShip : MonoBehaviour
{
    public float m_life;
    public float m_destructiontimer;
    public CComponent[] m_shipComponents; //helix, floor, fireplace, wing, steamengine, spoilers;
    public CFloor m_floor; 

    public int m_damageMultiplier; //damage = components broken * dmgMultiplier
    public int m_componentsBroken; //counter of the available components
    public bool m_allComponentsBroken; // bool that is true when all components are broken
    public bool m_allComponentsNotFunctioning; //bool that is true when all components are not functioning
    public float m_timeToDestroy; //random time to destroy a component
    //CFloor m_floor;

    // Start is called before the first frame update
    void Start()  
    {
        m_life = 100;
        m_destructiontimer = 0;
        m_timeToDestroy = Random.Range(4, 7);
        m_allComponentsBroken = false;
        m_componentsBroken = 0;
        m_damageMultiplier = 1;
        m_shipComponents = GameObject.FindObjectsOfType<CComponent>();
        m_floor = GameObject.FindObjectOfType<CFloor>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_allComponentsNotFunctioning = checkAllComponentsNotFunctioning();
        if (!m_allComponentsNotFunctioning)
        {
            m_destructiontimer += Time.fixedDeltaTime;
            if (m_destructiontimer > m_timeToDestroy)
            {
                m_destructiontimer = 0;
                m_timeToDestroy = Random.Range(4, 7);
                hijackComponent(); //randomly hijack a component
            }
        }
        countBrokenComponents(); //check our available components needed to operate the damage over second
        m_allComponentsBroken = checkAllComponentsBroken();
        applyDamage(); //apply damage over second 

        if(m_life < 0.0f)
        {
            m_life = 0.0f;
        }
    }

    void hijackComponent() //random component destroy that uses only when there are still components that can be broke
    {
            int x = Random.Range(0, m_shipComponents.Length);
            while (m_shipComponents[x].m_functioning == false)
            {
                x = Random.Range(0, m_shipComponents.Length);
            }
            m_shipComponents[x].m_functioning = false;
            m_allComponentsBroken = checkAllComponentsBroken();
        

    }
    bool checkAllComponentsBroken() //if there are no components functioning then returns true
    {
        for(int i = 0; i < m_shipComponents.Length; i++)
        {
            if(m_shipComponents[i].m_broken == false)
            {
                return false;
            }
        }
        return true;
    }

    void countBrokenComponents() //function that counts every functioning component
    {
        m_componentsBroken = 0;
        for(int i = 0; i < m_shipComponents.Length; i++)
        {
            if(m_shipComponents[i].m_broken == true)
            {
                m_componentsBroken++;
            }
        }
    }

    bool checkAllComponentsNotFunctioning ()
    {
        for(int i = 0; i < m_shipComponents.Length; i++)
        {
            if(m_shipComponents[i].m_functioning == true)
            {
                return false;
            }
        }
        return true;
    }
    void applyDamage ()
    {
        m_life -= ( (m_damageMultiplier *  m_componentsBroken) * Time.fixedDeltaTime);
    }
}
