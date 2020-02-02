using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stabla : MonoBehaviour
{
    public bool end = false, win = true;
    float timer = 0;
    public int cuantos = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            end = true;
            win = false;
        }
        if (cuantos == 4)
        {
            end = true;
        }
    }
}
