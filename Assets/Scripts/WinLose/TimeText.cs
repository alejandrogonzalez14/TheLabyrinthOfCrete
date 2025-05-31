using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeText : MonoBehaviour
{
    public TextMeshProUGUI uiText;
    public float timer = 0f;

    void Update()
    {
        uiText.text = timer.ToString("F2") + "s";
    }

}
