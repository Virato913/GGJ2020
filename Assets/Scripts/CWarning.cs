using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CWarning : MonoBehaviour
{
    Image m_image;
    Text m_PieceName;
    public CTool m_tool;
    // Start is called before the first frame update
    void Start()
    {
        m_tool = Instantiate(m_tool);
        m_image = transform.Find("Image").GetComponent<Image>();
        m_image.sprite = m_tool.GetComponent<SpriteRenderer>().sprite;
        m_PieceName = transform.Find("PieceName").GetComponent<Text>();
        m_PieceName.text = m_tool.m_name;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
