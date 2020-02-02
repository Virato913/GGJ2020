using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoser : MonoBehaviour
{
    public float tiempo;
    Vector3 wp;
    public Vector3 touchPos;
    public GameObject punto;
    public List<GameObject> puntos;
    public int este = 0;
    bool hilo = false,linea = false,destroi = false;
    public List<GameObject> hilos = new List<GameObject>();
    GameObject myLine;
    LineRenderer lr;
    public bool end = false, win = true;
    float timer = 0;
    public Material cuerda;
    // Start is called before the first frame update
    void Start()
    {
        for (float a = 0; a < 4; a++)
        {
            punto.transform.position = new Vector3((a-2)*5,(2-a)/2*5 , 0);
            Instantiate(punto);
            GameObject.Find("punto(Clone)").name = "punto" + ((int)a*2).ToString();
        }
        for (float a = 0; a < 3; a++)
        {
            punto.transform.position = new Vector3((a - 2+.75f)*5, ((2 - a) / 2+.25f)*5, 0);
            Instantiate(punto);
            GameObject.Find("punto(Clone)").name = "punto" + ((int)a * 2+1).ToString();
        }
        for(int a = 0; a < 7; a++)
        {
            puntos.Add(GameObject.Find("punto" + a.ToString()));
            puntos[a].GetComponent<stube>().cual = a;
        }
        myLine = new GameObject();
        hilos.Add(myLine);
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
        if (este == 7)
        {
            end = true;
        }
        destroi = Input.GetMouseButtonUp(0);
        touchPos = Input.mousePosition;
        touchPos.z = 10;
        touchPos = Camera.main.ScreenToWorldPoint(touchPos);
        if (puntos[este].GetComponent<stube>().klikeado)
        {
            hilo = true;
            linea = true;
        }
        
        if (hilo)
        {
            GameObject.Destroy(hilos[este]);
            linea = false;
            hilos[este] = new GameObject();
            hilos[este].transform.position = puntos[este].GetComponent<Transform>().position;
            hilos[este].AddComponent<LineRenderer>();
            lr = hilos[este].GetComponent<LineRenderer>();
            lr.material = cuerda;
            lr.startColor = Color.red;
            lr.endColor = Color.red;
            lr.startWidth = 0.1f;
            lr.endWidth = 0.1f;
            lr.SetPosition(0, puntos[este].GetComponent<Transform>().position);
            lr.SetPosition(1, touchPos);
            lr.generateLightingData = true;
            if (puntos[este + 1].GetComponent<stube>().desklikeado)
            {
                Debug.Log('0');
                este += 1;
                hilo = false;
                myLine = new GameObject();
                hilos.Add(myLine);
                destroi = false;
            }
        }
        if (destroi)
        {
            destroi = false;
            GameObject.Destroy(hilos[este]);
            hilo = false;
            puntos[este].GetComponent<stube>().klikeado = false;
            CSceneManager.LoadBobScene();
        }
    }
}
