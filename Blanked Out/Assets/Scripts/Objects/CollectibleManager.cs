using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CollectibleManager : MonoBehaviour
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