using UnityEngine;
public class ira : MonoBehaviour
{
  public string level;
  // Start is called before the first frame update
  void Start()
  {

  }
  public void go()
  {
    CSceneManager.LoadBobScene();
  }

  public void credits()
  {
    CSceneManager.LoadCredits();
  }
  // Update is called once per frame
  void Update()
  {

  }
}
