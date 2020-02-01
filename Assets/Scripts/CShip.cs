using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CShip : MonoBehaviour
{
    public float m_life;
    public float m_destructiontimer;
    public CComponent[] m_shipComponents = new CComponent[5]; //helix, floor, fireplace, wing, steamengine, spoilers;


    public int m_damagePerSecond; // function that calculates damage per component broken/destroyed
    public int m_damageMultiplier; //damage = dps * dmgMultiplier
    public int m_componentsAvailable; //counter of the available components
    public bool m_allComponentsDestroyed; // bool that is true when are components are not functioning
    public float m_timeToDestroy; //random time to destroy a component
    //CFloor m_floor;

    // Start is called before the first frame update
    void Start()  
    {
        m_life = 100;
        m_destructiontimer = 0;
        m_timeToDestroy = Random.Range(4, 7);
        m_allComponentsDestroyed = false;
        m_componentsAvailable = 5;
        m_damageMultiplier = 1;
        m_damagePerSecond = 5;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!m_allComponentsDestroyed)
        {
            m_destructiontimer += Time.fixedDeltaTime;
            if (m_destructiontimer > m_timeToDestroy)
            {
                m_destructiontimer = 0;
                destroyComponent();
            }
        }
        countAvailableComponents();
        applyDamage();
    }

    void destroyComponent()
    {
        if (!m_allComponentsDestroyed)
        {
            int x = Random.Range(0, 5);
            while (m_shipComponents[x].m_functioning == false)
            {
                x = Random.Range(0, 5);
            }
            m_shipComponents[x].m_functioning = false;
            m_allComponentsDestroyed = checkAllComponentsDestroyed();
        }

    }
    bool checkAllComponentsDestroyed() //if there are no components functioning then returns true
    {
        for(int i = 0; i < 5; i++)
        {
            if(m_shipComponents[i].m_functioning == true)
            {
                return false;
            }
        }
        return true;
    }

    void countAvailableComponents() //function that counts every functioning component
    {
        m_componentsAvailable = 0;
        for(int i = 0; i < 5; i++)
        {
            if(m_shipComponents[i].m_functioning == true)
            {
                m_componentsAvailable++;
            }
        }
    }

    void applyDamage ()
    {
        m_life -= ( (m_damageMultiplier * (m_damagePerSecond - m_componentsAvailable) * Time.fixedDeltaTime));
    }
}
