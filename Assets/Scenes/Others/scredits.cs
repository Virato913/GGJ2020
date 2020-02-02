using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scredits : MonoBehaviour
{
    public List<string> nombres;
    public GameObject nombre;
    // Start is called before the first frame update
    void Start()
    {
        /*GameObject canvas = GameObject.Find("Canvas");
        for (int a = 0; a < nombres.Capacity; a++)
        {
            nombre.GetComponent<UnityEngine.UI.Text>().text = nombres[a];
            GameObject text = Instantiate(nombre, new Vector3(300, 0-80*a, 0), Quaternion.identity);
            text.transform.SetParent(canvas.transform);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
