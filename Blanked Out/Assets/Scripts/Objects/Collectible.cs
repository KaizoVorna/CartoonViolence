using System;
using UnityEngine;

public class Collectible: MonoBehaviour
{
    public static Action OnCollected; 
    public static int total;
   

    void Awake() => total++;
      
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CollectibleCount count = other.GetComponent<CollectibleCount>();
            {
                if (count != null)
                {
                    count.OnCollectibleCollected();
                }

                OnCollected?.Invoke();
                Destroy(gameObject);
            }

            
        }
    }
   
}
