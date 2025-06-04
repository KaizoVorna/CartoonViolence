 using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DrawBadManager : MonoBehaviour
    
{

    public GameObject drawpbadMenuUI;
    public float followSpeed = 15f;
    public Transform player;
    public Vector2 startPos;
    public Transform m_GroundCheck;
    const float k_GroundedRadius = .2f;
    public bool m_Grounded = false;
    [SerializeField] private LayerMask m_WhatIsGround;
    public Animator animator;

    void Start()
    {
        startPos = drawpbadMenuUI.transform.position;
    }
    // Update is called once per frame

    private void FixedUpdate()
    {
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
            }
        }
    }
    void Update()
    {
        if (m_Grounded)
        {
            if (Input.GetButtonDown("DrawBad"))
            {

                drawpbadMenuUI.SetActive(true);
                drawpbadMenuUI.transform.position = Vector2.MoveTowards(transform.position, player.position, followSpeed * Time.deltaTime);
                player.GetComponent<Player_Move>().enabled = false;
            }
            else if (Input.GetButtonUp("DrawBad"))
            {

                drawpbadMenuUI.transform.position = startPos;
                drawpbadMenuUI.SetActive(false);
                player.GetComponent<Player_Move>().enabled = true;

            }


        

        }
    }
}
