using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Uduino;

public class ButtonUdu : MonoBehaviour
{

    void Start()
    {
        UduinoManager.Instance.pinMode(2, PinMode.Input_pullup);
    }

    // Update is called once per frame
    void Update()
    {
        int buttonVal = UduinoManager.Instance.digitalRead(2);

        if (buttonVal == 0)
        {
            Destroy(this);
        }
    }
}
