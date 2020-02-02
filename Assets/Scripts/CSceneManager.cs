using UnityEngine;
using UnityEngine.SceneManagement;

public class CSceneManager : MonoBehaviour
{
  public static CSceneManager playerInstance;
  void Awake()
  {
    DontDestroyOnLoad(this);

    if (playerInstance == null)
    {
      playerInstance = this;
    }
    else
    {
      Destroy(gameObject);
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
    else if (scene.buildIndex == 0)
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
    if (CSingleton.instance != null)
      CSingleton.instance.gameObject.SetActive(false);
  }

  public static void LoadBobScene()
  {
    SceneManager.LoadScene("MainScene");
    if (CSingleton.instance != null)
      CSingleton.instance.gameObject.SetActive(true);
  }

  public static void LoadStartScene()
  {
    SceneManager.LoadScene("menu de inicio");
    if (CSingleton.instance != null)
      CSingleton.instance.gameObject.SetActive(false);
  }

  public static void LoadPipeGame()
  {
    SceneManager.LoadScene("conectuberias");
    if (CSingleton.instance != null)
      CSingleton.instance.gameObject.SetActive(false);
  }

  public static void LoadPlateGame()
  {
    SceneManager.LoadScene("placasoldada");
    if (CSingleton.instance != null)
      CSingleton.instance.gameObject.SetActive(false);
  }

  public static void LoadWingGame()
  {
    SceneManager.LoadScene("coservela");
    if (CSingleton.instance != null)
      CSingleton.instance.gameObject.SetActive(false);
  }

  public static void LoadGearGame()
  {
    SceneManager.LoadScene("Gear");
    if (CSingleton.instance != null)
      CSingleton.instance.gameObject.SetActive(false);
  }

  public static void Restar()
  {
    //SceneManager.LoadScene("placasoldada");
    //CSingleton.instance.gameObject.SetActive(false);
  }

  public static void LoadCredits()
  {
    SceneManager.LoadScene("creditos");
    if (CSingleton.instance != null)
      CSingleton.instance.gameObject.SetActive(false);
  }
}
