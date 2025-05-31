using UnityEngine;
using UnityEngine.UI;

public class Home : MonoBehaviour
{

    public GameObject optionsMenu;
    public GameObject mainMenu;
    public GameObject home;
    public GameObject optionsIcon;

    private float timer = 0f;
    private bool isInside = false;
    public float selectionTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player1"))
        {
            isInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            isInside = false;
            timer = 0f;
        }
    }

    private void Update()
    {
        if (isInside)
        {
            timer += Time.deltaTime;
            if (timer >= selectionTime)
            {
                optionsMenu.SetActive(false);
                mainMenu.SetActive(true);
                home.SetActive(false);
                optionsIcon.SetActive(true);
                timer = 0f;
            }
        }
    }
}