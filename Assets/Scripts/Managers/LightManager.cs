using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightManager : MonoBehaviour
{
    public Light R1;
    public Light R2;
    public Light R3;
    public Light R4;

    public Light D1;
    public Light D2;
    public Light D3;
    public Light D4;

    public Light B1;
    public Light B2;
    public Light B3;
    public Light B4;

    void Start()
    {
        switch(MenuButtons.button_pressed) 
        {
            case 2:
                D1.enabled = false;
                D2.enabled = false;
                D3.enabled = false;
                D4.enabled = false;

                B1.enabled = false;
                B2.enabled = false;
                B3.enabled = false;
                B4.enabled = false;
                break;
            case 3:
                D1.enabled = false;
                D2.enabled = false;
                D3.enabled = false;
                D4.enabled = false;

                B1.enabled = false;
                B2.enabled = false;
                B3.enabled = false;
                B4.enabled = false;

                R1.enabled = false;
                R2.enabled = false;
                R3.enabled = false;
                R4.enabled = false;
                break;
        }
    }

}
