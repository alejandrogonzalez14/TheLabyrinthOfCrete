using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinLoseText : MonoBehaviour
{
    public TextMeshProUGUI uiText;
    public bool win;

    void Update()
    {
        if (win) {
            uiText.text = "YOU HAVE WON";
        }
        else
        {
            uiText.text = "YOU HAVE LOST";
        }
        
    }

}
