using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RocksText : MonoBehaviour
{
    public TextMeshProUGUI uiText;

    void Update()
    {
        uiText.text = GameStateManager.getTotalRocks().ToString() + " rocks";
    }

}
