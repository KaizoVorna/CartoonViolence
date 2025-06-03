using UnityEngine;

public class E_CameraMove : MonoBehaviour
{
    float horizontalMove = 0f;
    public float leftMove = 0f;
    public float rightMove = 0f;

    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            horizontalMove = Input.GetAxisRaw("Horizontal");
            if (horizontalMove > 0f)
            {
                Camera.main.transform.position = new Vector3(rightMove, Camera.main.transform.position.y, Camera.main.transform.position.z);
            }
            else
            {
                Camera.main.transform.position = new Vector3(leftMove, Camera.main.transform.position.y, Camera.main.transform.position.z);
            }
        }
    }
}
