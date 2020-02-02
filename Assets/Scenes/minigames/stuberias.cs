using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stuberias : MonoBehaviour
{
    public float tiempo;
    public GameObject tuberia,largo,curva;
    List<int> usados = new List<int>(),usa2 = new List<int>();
    public float inicio, fin,distancia;
    List<Color> colores = new List<Color> { Color.blue, Color.green,Color.yellow,Color.red,Color.magenta };
    List<GameObject> cosas = new List<GameObject>();
    Transform posi;
    int cual,e=0,todas=0,tubi=0;
    bool ya=false;
    public bool end = false,win=true;
    Color colour;
    float timer=0;
    public Material metal;
    // Start is called before the first frame update
    void Start()
    {
        distancia = (fin - inicio) / ((float)5);
        for(int a = 0; a < 4; a++)
        {
            tuberia.transform.position = new Vector3(0, inicio + (a + 1) * distancia, 0);
            tuberia.transform.rotation = Quaternion.Euler(0, 0, -90);
            cual = Random.Range(0, 4);
            while (usados.Contains(cual))
            {
                cual = Random.Range(0, 4);
            }
            tuberia.GetComponent<SpriteRenderer>().color = colores[cual];
            usados.Add(cual);
            Instantiate(tuberia);
            GameObject.Find("tuberia(Clone)").name = "tuberia" + e.ToString();
            cosas.Add(GameObject.Find("tuberia" + e.ToString()));
            e += 1;
        }
        for (int a = 0; a < 4; a++)
        {
            tuberia.transform.position = new Vector3(5, inicio + (a + 1) * distancia, 0);
            tuberia.transform.rotation = Quaternion.Euler(0, 0, 90);
            cual = Random.Range(0, 4);
            while (usa2.Contains(cual))
            {
                cual = Random.Range(0, 4);
            }
            tuberia.GetComponent<SpriteRenderer>().color = colores[usados[cual]];
            usa2.Add(cual);
            Instantiate(tuberia);
            GameObject.Find("tuberia(Clone)").name = "tuberia" + e.ToString();
            cosas.Add(GameObject.Find("tuberia" + e.ToString()));
            e += 1;
        }

        
    }



    void DrawLine(Vector3 start, Vector3 end)
    {
        Debug.Log('1');
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = metal;
        lr.startColor = Color.blue;
        lr.endColor = Color.white;
        lr.startWidth=.5f;
        lr.endWidth = .5f;
        start.x += .4f;
        end.x -= .4f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        lr.generateLightingData = true;
    }
    /*void drawtubo(float a, float e,float i)
    {
        Debug.Log(a);
        Debug.Log(e);
        Debug.Log(0);
        
        if (e==a)
        {
            largo.transform.position = new Vector3(2.7f, a + .1f * a - .05f, 1);
            largo.transform.localScale = new Vector3(.8f, .8f, 1);
            Instantiate(largo);
        }
        else
        {
            largo.transform.position = new Vector3(2.1f + i / 10, .1f * e - .05f, 1);
            largo.transform.localScale = new Vector3(.2f + i / 10, .8f, 1);
            Instantiate(largo);
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > tiempo)
        {
            end = true;
            win = false;
        }
        if(todas == 4)
        {
            end = true;
            CSceneManager.LoadBobScene();
        }
        if (ya)
        {
            for (int a = 4; a < (4) * 2; a++)
            {
                if (cosas[a].GetComponent<stube>().klikeado)
                {
                    cosas[a].GetComponent<stube>().klikeado = false;
                    if (cosas[e].GetComponent<SpriteRenderer>().color == cosas[a].GetComponent<SpriteRenderer>().color)
                    {
                        Debug.Log('0');
                        ya = false;
                        cosas[e].GetComponent<stube>().ya = true;
                        /*drawtubo(cosas[a].transform.position.y, cosas[e].transform.position.y,tubi);
                        tubi += 1;*/
                        DrawLine(cosas[e].GetComponent<Transform>().position, cosas[a].GetComponent<Transform>().position);
                        todas += 1;
                        break;
                    }
                }
            }
        }
        for (int a = 0; a < 4; a++)
        {
            if (cosas[a].GetComponent<stube>().klikeado)
            {
                e = a;
                ya = true;
                for (int i = 0; i < 4; i++)
                {
                    if(i != a)
                    {
                        cosas[a].GetComponent<stube>().klikeado = false;
                    }
                }
                break;
            }
        }

    }
}
