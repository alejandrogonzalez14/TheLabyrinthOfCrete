using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RocksText : MonoBehaviour
{
    public TextMeshProUGUI uiText;
    public int rocks = 0;

    void Update()
    {
        uiText.text = rocks.ToString("F2") + " rocks";
    }

}
