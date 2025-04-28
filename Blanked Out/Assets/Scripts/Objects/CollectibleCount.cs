using UnityEngine;

public class CollectibleCount : MonoBehaviour
{
    TMPro.TMP_Text text;
    public int count;

    void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }

    
    

    void OnEnable() => Collectible.OnCollected += OnCollectibleCollected;
    void OnDisable() => Collectible.OnCollected -= OnCollectibleCollected;
    

    public void OnCollectibleCollected()
    {
        count++; 
    }

    
}
