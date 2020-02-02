using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CSceneManager : MonoBehaviour
{
    private static CSceneManager playerInstance;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            Object.Destroy(gameObject);
        }
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.buildIndex != 0)
        {
            if (CSingleton.instance != null)
            {
                CSingleton.instance.gameObject.SetActive(false);
            }
        }
        else if(scene.buildIndex == 0)
        {
            if (CSingleton.instance != null)
            {
                CSingleton.instance.gameObject.SetActive(true);
            }
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("MainScene");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("coservela");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("conectuberias");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadScene("placasoldada");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SceneManager.LoadScene("smashearclavos");
        }

    }

    public static void LoadFloorGame()
    {
        SceneManager.LoadScene("smashearclavos");
        CSingleton.instance.gameObject.SetActive(false);
    }

    public static void LoadBobScene()
    {
        SceneManager.LoadScene("MainScene");
        CSingleton.instance.gameObject.SetActive(true);
    }

    public static void LoadStartScene()
    {
        SceneManager.LoadScene("menu de inicio");
        CSingleton.instance.gameObject.SetActive(true);
    }

    public static void LoadPipeGame()
    {
        SceneManager.LoadScene("conectuberias");
        CSingleton.instance.gameObject.SetActive(false);
    }

    public static void LoadPlateGame()
    {
        SceneManager.LoadScene("placasoldada");
        CSingleton.instance.gameObject.SetActive(false);
    }

    public static void LoadWingGame()
    {
        SceneManager.LoadScene("coservela");
        CSingleton.instance.gameObject.SetActive(false);
    }

    public static void LoadGearGame()
    {
        SceneManager.LoadScene("Gear");
        CSingleton.instance.gameObject.SetActive(false);
    }

    public static void Restar()
    {
        //SceneManager.LoadScene("placasoldada");
        //CSingleton.instance.gameObject.SetActive(false);
    }
}
