using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIchase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    bool isActive;
    public Vector2 nestPoint;

    private float distance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      nestPoint = new Vector2 (transform.position.x, transform.position.y);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
        {
            distance = Vector2.Distance(transform.position, nestPoint);

            transform.position = Vector2.MoveTowards(this.transform.position, nestPoint, speed * Time.deltaTime);

        }
        else
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;

            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}
