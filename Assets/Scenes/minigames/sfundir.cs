using System;
using UnityEngine;

public class sfundir : MonoBehaviour
{
  public Vector3 touchPos, inicio, intermedio;
  public GameObject fuego;
  public float maximo;
  // Start is called before the first frame update
  void Start()
  {

  }
  // Update is called once per frame
  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      touchPos = Input.mousePosition;
      touchPos.z = 10;
      inicio = Camera.main.ScreenToWorldPoint(touchPos);
    }
    if (Input.GetMouseButton(0))
    {
      touchPos = Input.mousePosition;
      touchPos.z = 10;
      touchPos = Camera.main.ScreenToWorldPoint(touchPos);
      fuego.transform.position = touchPos;
      maximo = Math.Max(Math.Abs(inicio.x - touchPos.x), Math.Abs(inicio.y - touchPos.y)) * 49;
      for (float a = 0; a < maximo; a++)
      {
        fuego.transform.position = new Vector3(inicio.x - (inicio.x - touchPos.x) / maximo * a, inicio.y - (inicio.y - touchPos.y) / maximo * a, 0);
        Instantiate(fuego);
      }
      inicio = touchPos;


    }
  }
}
