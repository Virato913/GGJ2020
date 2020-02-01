using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CComponent : MonoBehaviour
{

    public float m_fixTime; //maximun time for the player to complete the minigame
    public float m_timeCount; //counter for the minigame
    public bool m_fixing; //if player is fixing this component
    public bool m_functioning; //if this component isn´t broken
    public static bool m_fixed; //temporary bool simulating the minigame win/lose outcome
    //enum_id to the tool that fixes this component
    //possible reference to minigame

    // Start is called before the first frame update
    void Start()
    {
        m_fixing = false;
        m_functioning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_fixing & m_functioning) //if the player is fixing this component, then we start the counter for the minigame
        {
            m_timeCount += Time.deltaTime;
        }

        if(m_timeCount > m_fixTime) //if the player exceeds the time for the minigame, then this component will not be functioning
        {
            m_functioning = false;
        }

        if(m_fixed == true)
        {
            m_timeCount = 0;
            m_fixing = false;
            m_fixed = false;
        }
        
    }
}
