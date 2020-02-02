using System;
using UnityEngine;

public class seje : MonoBehaviour
{
  Vector3 touchPos;
  public float tiempo, vueltas;
  double distancia;
  float angulo = 0;
  float inicio = 0;
  public GameObject rueda;
  Vector2 mio, otro;
  public bool win = false, end = false;
  float timer = 0;
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
    if (angulo > 360 * vueltas)
    {
      win = true;
    }

    mio = new Vector2(transform.position.x, transform.position.y);
    otro = new Vector2(touchPos.x, touchPos.y);
    touchPos = Input.mousePosition;
    touchPos.z = 10;
    touchPos = Camera.main.ScreenToWorldPoint(touchPos);
    distancia = Math.Pow(Math.Pow(transform.position.x - touchPos.x, 2) + Math.Pow(transform.position.y - touchPos.y, 2), .5f);
    if (distancia < 1.5f)
    {
      transform.position = new Vector3(transform.position.x + (float)((1.5f - distancia) / distancia * (transform.position.x - touchPos.x)), transform.position.y + (float)((1.5f - distancia) / distancia * (transform.position.y - touchPos.y)), -1);
    }
    if (transform.position.x < -1)
    {
      transform.position = new Vector3(-1, transform.position.y, transform.position.z);
    }
    if (transform.position.x > 1)
    {
      transform.position = new Vector3(1, transform.position.y, transform.position.z);
    }
    if (transform.position.y < 0)
    {
      transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
    if (transform.position.y > 2)
    {
      transform.position = new Vector3(transform.position.x, 2, transform.position.z);
    }
    if (Input.GetMouseButtonDown(0))
    {
      inicio = Mathf.Atan2(mio.y - otro.y, mio.x - otro.x) * 180 / Mathf.PI;
    }
    if (Input.GetMouseButtonUp(0))
    {
      angulo += (Mathf.Atan2(mio.y - otro.y, mio.x - otro.x) * 180 / Mathf.PI + 360) % 360 - inicio;
    }

    if (Input.GetMouseButton(0))
    {
      rueda.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mio.y - otro.y, mio.x - otro.x) * 180 / Mathf.PI);
      if (90 < (Mathf.Atan2(mio.y - otro.y, mio.x - otro.x) * 180 / Mathf.PI + 360) % 360 - inicio && (Mathf.Atan2(mio.y - otro.y, mio.x - otro.x) * 180 / Mathf.PI + 360) % 360 - inicio < 180)
      {
        angulo += (Mathf.Atan2(mio.y - otro.y, mio.x - otro.x) * 180 / Mathf.PI + 360) % 360 - inicio;
        inicio = Mathf.Atan2(mio.y - otro.y, mio.x - otro.x) * 180 / Mathf.PI;
      }
      if (180 < (Mathf.Atan2(mio.y - otro.y, mio.x - otro.x) * 180 / Mathf.PI + 360) % 360 - inicio && (Mathf.Atan2(mio.y - otro.y, mio.x - otro.x) * 180 / Mathf.PI + 360) % 360 - inicio < 270)
      {
        inicio = Mathf.Atan2(mio.y - otro.y, mio.x - otro.x) * 180 / Mathf.PI;
      }
    }
  }
}
