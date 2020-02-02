using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splaka : MonoBehaviour
{
    public float tiempo;
    float timer = 0;
    public bool end=false, win=true;
    public int perimetro = 0;
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
        if(perimetro == 40)
        {
            end = true;
        }
    }
}
