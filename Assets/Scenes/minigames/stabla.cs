using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stabla : MonoBehaviour
{
    public float tiempo;
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
        if (timer > tiempo)
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
