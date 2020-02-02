using UnityEngine;
using UnityEngine.UI;

public class CShip : MonoBehaviour
{
  public float m_life;
  public float m_destructiontimer;
  public CComponent[] m_shipComponents; //helix, floor, fireplace, wing, steamengine, spoilers;
  public CFloor m_floor;

  public int m_damageMultiplier; //damage = components broken * dmgMultiplier
  public int m_componentsBroken; //counter of the available components
  public bool m_allComponentsBroken; // bool that is true when all components are broken
  public bool m_allComponentsNotFunctioning; //bool that is true when all components are not functioning
  public float m_timeToDestroy; //random time to destroy a component
                                //CFloor m_floor;
  private float m_gameOverTime = 5.0f;
  private float m_gameOverElapsedTime = 0.0f;
  private bool m_gameOver = false;
  [SerializeField]
  private Canvas m_loseText;

  // Start is called before the first frame update
  void Start()
  {
    m_life = 100;
    m_destructiontimer = 0;
    m_timeToDestroy = Random.Range(7, 15);
    m_allComponentsBroken = false;
    m_componentsBroken = 0;
    m_damageMultiplier = 1;
    m_shipComponents = FindObjectsOfType<CComponent>();
    m_floor = FindObjectOfType<CFloor>();
    //m_loseText.enabled = false;
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    m_allComponentsNotFunctioning = CheckAllComponentsNotFunctioning();
    if (!m_allComponentsNotFunctioning)
    {
      m_destructiontimer += Time.fixedDeltaTime;
      if (m_destructiontimer > m_timeToDestroy)
      {
        m_destructiontimer = 0;
        m_timeToDestroy = Random.Range(4, 7);
        HijackComponent(); //randomly hijack a component
      }
    }
    CountBrokenComponents(); //check our available components needed to operate the damage over second
    m_allComponentsBroken = CheckAllComponentsBroken();
    ApplyDamage(); //apply damage over second 

    if (Input.anyKeyDown)
    {
      m_life = -10;
    }

    if (m_life < 0.0f)
    {
      m_life = 0.0f;
      m_gameOver = true;
      var player = GameObject.FindGameObjectWithTag("Player");

      //var loseText = GetComponentInChildren<Text>();
      //m_loseText.enabled = true;
    }

    if (m_gameOver)
    {
      m_gameOverElapsedTime += Time.fixedDeltaTime;
      if (m_gameOverElapsedTime >= m_gameOverTime)
      {
        CSceneManager.LoadStartScene();
        Destroy(CSingleton.instance.gameObject);
      }
    }
  }

  void HijackComponent() //random component destroy that uses only when there are still components that can be broke
  {
    int x = Random.Range(0, m_shipComponents.Length);
    while (m_shipComponents[x].m_functioning == false)
    {
      x = Random.Range(0, m_shipComponents.Length);
    }
    m_shipComponents[x].m_functioning = false;
    m_allComponentsBroken = CheckAllComponentsBroken();
  }

  bool CheckAllComponentsBroken() //if there are no components functioning then returns true
  {
    foreach (CComponent component in m_shipComponents)
    {
      if (!component.m_broken) { return false; }
    }
    //for (int i = 0; i < m_shipComponents.Length; i++)
    //{
    //  if (m_shipComponents[i].m_broken == false)
    //  {
    //    return false;
    //  }
    //}
    return true;
  }

  void CountBrokenComponents() //function that counts every functioning component
  {
    m_componentsBroken = 0;
    for (int i = 0; i < m_shipComponents.Length; i++)
    {
      if (m_shipComponents[i].m_broken == true)
      {
        m_componentsBroken++;
      }
    }
  }

  bool CheckAllComponentsNotFunctioning()
  {
    for (int i = 0; i < m_shipComponents.Length; i++)
    {
      if (m_shipComponents[i].m_functioning == true)
      {
        return false;
      }
    }
    return true;
  }

  void ApplyDamage()
  {
    m_life -= ((m_damageMultiplier * m_componentsBroken) * Time.fixedDeltaTime);
  }
}
