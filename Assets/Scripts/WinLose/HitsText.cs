using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HitsText : MonoBehaviour
{
    public TextMeshProUGUI uiText;

    void Update()
    {
        uiText.text = GameStateManager.getMinotaurHits().ToString() + " hits";
    }

}
