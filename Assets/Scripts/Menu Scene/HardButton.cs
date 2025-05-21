using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class HardButton : MonoBehaviour, IPointerClickHandler
{
    private static int pressed_button;

    public void OnPointerClick(PointerEventData eventData)
    {
        HardButton.pressed_button = 2;
        SceneManager.LoadScene("Maze");
    }
}
