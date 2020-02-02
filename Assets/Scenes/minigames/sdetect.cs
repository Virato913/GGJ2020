using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sdetect : MonoBehaviour
{
    bool v = true;
    public GameObject plaka;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0)&&v)
        {
            v = false;
            plaka.GetComponent<splaka>().perimetro += 1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
