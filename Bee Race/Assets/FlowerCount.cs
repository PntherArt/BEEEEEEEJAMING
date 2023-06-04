using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlowerCount : MonoBehaviour
{
    public int flowerCount;
    public TextMeshProUGUI CountText;

    private void Update()
    {
        updateFlowerCount();
    }

    public void updateFlowerCount()
    {
        CountText.text = flowerCount.ToString("0");
    }

}
