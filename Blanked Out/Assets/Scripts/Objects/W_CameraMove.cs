using UnityEngine;

public class W_CameraMove : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            Camera.main.transform.Translate(-25f / 2, 0f, 0f);
        }
    }
}
