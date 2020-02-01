using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TOOL_TYPES
{
    FLOOR = 0,
    GEAR,
    PIPE,
    PLATE,
    WING
}

public class CTool : MonoBehaviour
{
    public TOOL_TYPES m_type;
    public string m_name;
    public List<MatList> m_materialList;
    public List<int> m_materialListCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
