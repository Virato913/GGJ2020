using UnityEngine;
//using UnityEngine.SceneManagement;

public class CSingleton : MonoBehaviour
{
  public static CSingleton instance;
  void Awake()
  {
    DontDestroyOnLoad(this);

    if (instance == null)
    {
      instance = this;

      if (CSceneManager.playerInstance != null)
        CSceneManager.LoadStartScene();
    }
    else
    {
      Destroy(gameObject);
    }

  }

  //public static void Restart()
  //{
  //  if (instance != null)
  //  {
  //    Destroy(instance.gameObject);
  //  }
  //  instance = new CSingleton();
  //  if(SceneManager.GetActiveScene().buildIndex!=0)
  //  {
  //
  //  }
  //}
}
