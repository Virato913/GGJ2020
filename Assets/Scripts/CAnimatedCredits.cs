using UnityEngine;

public class CAnimatedCredits : MonoBehaviour
{
  private float m_elapsedTime = 0.0f;

  void Start()
  {
    m_elapsedTime = 0.0f;
  }

  void FixedUpdate()
  {
    m_elapsedTime += Time.fixedDeltaTime;
    if (m_elapsedTime >= 7.0f)
    {
      CSceneManager.LoadStartScene();
    }
  }
}
