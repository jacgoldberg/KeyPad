using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadButton : MonoBehaviour
{
    public int ButtonValue;
    public Keypad keypad;

    public void onClick()
    {
        keypad.RegisterButtonClick(ButtonValue);
    }
}
