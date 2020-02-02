using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sclavos : MonoBehaviour
{
    int cuantos = 0;
    bool ok = false;
    public GameObject skrip;
    // Start is called before the first frame update
    void Start()
    {
    }
    void OnMouseDown()
    {
        if (cuantos < 4)
        {
            cuantos += 1;
            transform.position = new Vector3(transform.position.x, transform.position.y - .1f, transform.position.z);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.black;
            skrip.GetComponent<stabla>().cuantos += 1;
            ok = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
