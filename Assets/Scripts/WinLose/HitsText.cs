using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HitsText : MonoBehaviour
{
    public TextMeshProUGUI uiText;
    public int hits = 0;

    void Update()
    {
        uiText.text = hits.ToString("F2") + " hits";
    }

}
