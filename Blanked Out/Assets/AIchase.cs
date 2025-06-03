using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class AIchase : MonoBehaviour
{
    public AudioSource soundEffect;
    public GameObject player;
    public float speed;
    bool isActive;
    public Vector2 nestPoint;
    public Animator animator;

    private bool hasPlayed = false;

    private float distance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      nestPoint = new Vector2 (transform.position.x, transform.position.y);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !Input.GetButton("Sneak"))
        {
            if (Input.GetAxisRaw("Horizontal") != 0f)
            {
                
                isActive = true;
            }
        }
    }

   

    private void OnTriggerExit2D(Collider2D collision)
    {
        isActive = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        
        animator.SetBool("IsActive", isActive);
        Vector3 theScale = transform.localScale;
        if (player.transform.position.x > transform.position.x)
        {
            
            theScale.x = -Mathf.Abs(theScale.x); // face right
        }
        else
        {
            theScale.x = Mathf.Abs(theScale.x); // face left
        }

        if (!isActive)
        {   
            soundEffect.Play();
            theScale.x = Mathf.Abs(theScale.x); // face right
            transform.localScale = theScale;
            distance = Vector2.Distance(transform.position, nestPoint);
            transform.position = Vector2.MoveTowards(this.transform.position, nestPoint, speed * Time.deltaTime);

        }
        else
        {
            transform.localScale = theScale;
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

        }


    }
    private void OnDisable()
    {
    hasPlayed = false;
    }
}

