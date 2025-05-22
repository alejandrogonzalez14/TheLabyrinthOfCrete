using UnityEngine;

public class StartBGMusic : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        MusicManager.Instance.PlayMusic("bg-maze");
    }
}