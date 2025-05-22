using System.Collections;
using System.Diagnostics;
using UnityEngine;


public class JumpScare : MonoBehaviour
{

    public GameObject JumpScareImg;

    private bool isPlayed = false;
    void Start()
    {
        JumpScareImg.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!isPlayed)
            {
                JumpScareImg.SetActive(true);

                StartCoroutine(DisableImg());

                isPlayed = true;
            }

        }

        IEnumerator DisableImg()
        {
            yield return new WaitForSeconds(2);
            JumpScareImg.SetActive(false);
        }
    }

}

   