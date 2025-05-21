using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleCount : MonoBehaviour
{
    public int count;
    public TMP_Text countText;
    
    void Start()
    {
        UpdateCountText();
    }

    void Update()
    {
        UpdateCountText();
    }

    void UpdateCountText()
    {
        countText.text = ("Artsheets:") + count.ToString();
    }
}

