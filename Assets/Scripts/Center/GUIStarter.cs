using UnityEngine;
using TMPro;

public class GUIStarter : MonoBehaviour
{
    public TextMeshPro livesText;
    public TextMeshPro rocksText;
    public TextMeshPro minotaurlivesText;

    // Start is called before the first frame update
    void Awake()
    {
        GUIManager.setLivesText(livesText);
        GUIManager.setRocksText(rocksText);
        GUIManager.setMinotaurLivesText(minotaurlivesText);
    }
}
