using UnityEngine;

public class CComponent : CInteractable
{

    public float m_fixTime; //maximun time for the player to complete the minigame
    public float m_timeCount; //counter for the minigame
    public bool m_fixing; //if player is fixing this component
    public bool m_functioning; //if this component is functioning
    public bool m_broken; //if this component is broken
    public bool m_fixed; //temporary bool simulating the minigame win/lose outcome
    Canvas m_warningUI;

    public float m_interactRange = 4.0f;
    CPlayer m_player = null;
    public TOOL_TYPES m_toolID;
    //possible reference to minigame
    // Start is called before the first frame update
    void Start()
    {
        m_fixed = false;
        m_fixing = false;
        m_broken = false;
        m_functioning = true;
        m_warningUI = transform.Find("Canvas").GetComponent<Canvas>();
        m_warningUI.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((!m_functioning && !m_broken) && !m_fixing) //if this component is broken and not repairing, start the count to the player to try fix it
        {
            m_timeCount += Time.fixedDeltaTime;
            m_warningUI.enabled = true;
        }

        if (!m_broken && (m_timeCount > m_fixTime)) //if the time count exceeds the fix time duration, this component is broken, causing damage per second
        {
            m_timeCount = 0;
            m_functioning = false;
            m_fixed = false;
            m_fixing = false;
            m_broken = true;
        }

        if (m_fixed == true) //if fixed all states go back to normality
        {
            m_timeCount = 0;
            m_fixing = false;
            m_fixed = false;
            m_broken = false;
            m_functioning = true;
            m_warningUI.enabled = false;
        }

    }

    public void temporaryFix() //call this function when the player needs to stop the counter but dont have the tool to repair it
    {
        m_fixing = true; //the counter is only stopped when m_fixing is true
    }

    public void repair() //call this function when the player has the right tool to repair
    {
        switch (m_toolID)
        {
            case TOOL_TYPES.FLOOR:
                CSceneManager.LoadFloorGame();
                break;
            case TOOL_TYPES.GEAR:
                CSceneManager.LoadGearGame();
                break;
            case TOOL_TYPES.PIPE:
                CSceneManager.LoadPipeGame();
                break;
            case TOOL_TYPES.PLATE:
                //CSceneManager.LoadPlateGame();
                break;
            case TOOL_TYPES.WING:
                //CSceneManager.LoadWingGame();
                break;
            default:
                break;
        }
        m_fixed = true; // all states go back to normality in the update
    }

    public TOOL_TYPES getToolNeeded() // returns the id needed to repair this component
    {
        return m_toolID;
    }

    public override void Interact(CPlayer player)
    {
        base.Interact(player);
        m_player = player;
        Debug.Log(Vector3.Distance(m_player.transform.position, transform.position));
        if (Vector3.Distance(m_player.transform.position, transform.position) > m_interactRange)
        {
            m_player = null;
            if (m_fixing == true)
            {
                m_fixing = false;
            }
        }
        else
        {
            if ((player.CurrentPickupable as CTool) != null)
            {
                if (((CTool)player.CurrentPickupable).m_type == m_toolID)
                {
                    repair();
                    Destroy(m_player.CurrentPickupable.gameObject);
                    m_player.CurrentPickupable = null;
                }
                else
                {
                    temporaryFix();
                }
            }
        }
    }
}
