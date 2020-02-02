using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CLifeBar : MonoBehaviour
{
    public Slider m_slider;
    public CShip m_ship;

    // Start is called before the first frame update
    void Start()
    {
        m_slider.minValue = 0;
        m_slider.maxValue = 100;
        
    }

    // Update is called once per frame
    void Update()
    {
        m_slider.value = m_ship.m_life;
        if(m_slider.value == 0)
        {
            Color color = Color.white;
            m_slider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = color;
            CSceneManager.LoadStartScene();
            Destroy(CSingleton.instance.gameObject);
        }
    }
}
