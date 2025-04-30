using UnityEngine;

public class S_CameraMove : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            Camera.main.transform.Translate(0f, -15f / 2, 0f);
        }
    }
}
