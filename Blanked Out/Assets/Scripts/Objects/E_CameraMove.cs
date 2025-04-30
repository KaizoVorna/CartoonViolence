using UnityEngine;

public class E_CameraMove : MonoBehaviour
{
    float horizontalMove = 0f;

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            horizontalMove = Input.GetAxisRaw("Horizontal");
            Camera.main.transform.Translate((horizontalMove * 25) / 2, 0f, 0f);
        }
    }
}
