using UnityEngine;

public class WE_CameraMove : MonoBehaviour
{
    float horizontalMove = 0f;

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
                horizontalMove = Input.GetAxisRaw("Horizontal");
                if (horizontalMove < 0f)
                {
                    Camera.main.transform.Translate(-25f / 2, 0f, 0f);
                }
                else
                {
                    Camera.main.transform.Translate(25f / 2, 0f, 0f);
                }
        }
    }
}
