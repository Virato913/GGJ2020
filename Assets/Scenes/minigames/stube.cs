using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stube : MonoBehaviour
{
    // Start is called before the first frame update
    public bool klikeado = false, ya = false, desklikeado = false;
    public int cual;
    void Start()
    {
        
    }
    // Update is called once per frame
    void OnMouseDown()
    {
        if (!ya)
        {
            klikeado = true;
        }
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        {
            desklikeado = true;
        }
    }
    void Update()
    {
        
        /*if (Input.GetMouseButtonUp(0))
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos = new Vector2(wp.x, wp.y);
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(mousePos))
            {
                result = true;
            }
        }*/
    }
}
