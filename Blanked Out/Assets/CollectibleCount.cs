using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleCount : MonoBehaviour
{
    public int count;
    public TextMeshPro text;
    public CollectibleManager manager;
    void Start()
    {
        
    }

    void Update()
    {
       text.text = "Artsheets:" + count.ToString();
    }
}
