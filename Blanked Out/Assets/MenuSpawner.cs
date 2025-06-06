using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSpawner : MonoBehaviour
{
        public Transform spawnPoint;
        public int maxSpawnCount = 1;
        private int currentSpawnCount = 0;
        public GameObject anvil;
        public GameObject Bomb;
        public GameObject Door;
        public GameObject CampFire;
        public Image anvilCharge;
        public Image BombCharge;
        public Image DoorCharge;
        public Image CampFireCharge;
        float chargeUp = 0f;
        public float timeNeeded;

    private void Update()
    {
        if (Input.GetAxisRaw("Vertical") == -1f && anvil != null)
        {
            if (currentSpawnCount >= maxSpawnCount)
            {
                Debug.Log("Spawn limit reached.");
                return;
            }

            chargeUp += Time.deltaTime;
            anvilCharge.fillAmount = Mathf.Clamp(chargeUp, 0, 1);

            if (chargeUp > timeNeeded)
            {
                Vector2 spawnPos = spawnPoint ? spawnPoint.position : Vector2.zero;
                Instantiate(anvil, spawnPos, Quaternion.identity);
                currentSpawnCount++;
                anvilCharge.fillAmount = 0f;
                chargeUp = 0f;
                return;
            }
        }
        else
        {
            anvilCharge.fillAmount = 0f;
            chargeUp = 0f;
        }

        if (Input.GetAxisRaw("Vertical") == 1f && Door != null)
        {
            if (currentSpawnCount >= maxSpawnCount)
            {
                Debug.Log("Spawn limit reached.");
                return;
            }

            Vector2 spawnPos = spawnPoint ? spawnPoint.position : Vector2.zero;
            Instantiate(Door, spawnPos, Quaternion.identity);
            currentSpawnCount++;
        }

        if (Input.GetAxisRaw("Horizontal") == 1f && Bomb != null)
        {
            if (currentSpawnCount >= maxSpawnCount)
            {
                Debug.Log("Spawn limit reached.");
                return;
            }

            Vector2 spawnPos = spawnPoint ? spawnPoint.position : Vector2.zero;
            Instantiate(Bomb, spawnPos, Quaternion.identity);
            currentSpawnCount++;
        }
        if (Input.GetAxisRaw("Horizontal") == -1f && CampFire != null)
        {
            if (currentSpawnCount >= maxSpawnCount)
            {
                Debug.Log("Spawn limit reached.");
                return;
            }

            Vector2 spawnPos = spawnPoint ? spawnPoint.position : Vector2.zero;
            Instantiate(CampFire, spawnPos, Quaternion.identity);
            currentSpawnCount++;
        }






    }

    
    


   


    
}
