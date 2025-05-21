using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EasyButton : MonoBehaviour, IPointerClickHandler
{
    private static int pressed_button;
    public void OnPointerClick(PointerEventData eventData)
    {
        EasyButton.pressed_button = 1;
        SceneManager.LoadScene("Maze");
    }
}
