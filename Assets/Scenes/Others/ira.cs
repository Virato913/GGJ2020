using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
