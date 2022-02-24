using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UduinoManager.Instance.pinMode(2, PinMode.Input_pullup);
    }

    // Update is called once per frame
    void Update()
    {
        int buttonVal = UduinoManager.Instance.digitalRead(2);
    }
}
