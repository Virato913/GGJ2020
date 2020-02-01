﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CPieceButton : MonoBehaviour
{
    Button m_button;
    Image m_image;
    Text m_PieceName;
    Text m_materialList;
    public CTool m_tool;
    // Start is called before the first frame update
    void Start()
    {
        m_tool = Instantiate(m_tool);

        m_button = transform.Find("Button").GetComponent<Button>();
        m_button.onClick.AddListener(TaskOnClick);
        m_image = transform.Find("Image").GetComponent<Image>();
        m_image.sprite = m_tool.GetComponent<SpriteRenderer>().sprite;
        m_PieceName = transform.Find("PieceName").GetComponent<Text>();
        m_PieceName.text = m_tool.m_name;
        m_materialList = transform.Find("MaterialList").GetComponent<Text>();
        m_materialList.text = "";
        for (int i = 0; i < m_tool.m_materialListCount.Count; i++)
        {
            m_materialList.text += CBob.m_materialListCount[i].ToString() + "/" + m_tool.m_materialListCount[i].ToString() + " " + m_tool.m_materialList[i].ToString() + "\n";
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        CBob.CheckMaterialsNeeded(m_tool);
    }
}
