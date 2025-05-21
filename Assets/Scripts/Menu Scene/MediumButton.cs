using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MediumButton : MonoBehaviour, IPointerClickHandler
{
    private static int pressed_button;
    public void OnPointerClick(PointerEventData eventData)
    {
        MediumButton.pressed_button = 3;
        SceneManager.LoadScene("Maze");
    }
}
