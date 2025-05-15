using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private Vector2 startPosition; 
    private bool returningToStart = true;

    private void Start()
    {
        if (Input.GetKeyDown("DrawPad"))
        {
            startPosition = transform.position;
        }
    }
    public Transform player;
    public float followSpeed = 15f;
    private bool isFollowing = true;
    void Update()
    {
        if (isFollowing)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, followSpeed * Time.deltaTime);
        }
        if (isFollowing)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, followSpeed * Time.deltaTime);
            }
            else if (returningToStart)
            {
                transform.position = Vector2.MoveTowards(transform.position, startPosition, followSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, startPosition) < 10f)
                {
                    returningToStart = false;
                }
            }
        }

    }




    
    