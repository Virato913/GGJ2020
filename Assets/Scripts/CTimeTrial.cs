using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CTimeTrial : MonoBehaviour
{
    public float m_totaltimeleft;
    public Text m_text;
    // Start is called before the first frame update
    void Start()
    {
        m_totaltimeleft = 180;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_totaltimeleft -= Time.fixedDeltaTime;
        if(m_totaltimeleft < 0)
        {
            m_totaltimeleft = 0;
            //gameover();
        }
        m_text.text = Mathf.Floor(m_totaltimeleft).ToString();
        
    }
}
