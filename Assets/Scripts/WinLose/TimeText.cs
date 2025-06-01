using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeText : MonoBehaviour
{
    public TextMeshProUGUI uiText;

    void Update()
    {
        uiText.text = GameStateManager.GetCountdownTime().ToString() + " s";
    }

}
