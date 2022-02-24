using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class ledBlink : MonoBehaviour
{
    // Start is called before the first frame update

    private int count;
    private float levelTimer = 0.0f;
    private bool updateTimer = false;
    private IEnumerator routine1;
    void Start()
    {
        UduinoManager.Instance.pinMode(7, PinMode.Output);
        UduinoManager.Instance.pinMode(8, PinMode.Output);
        UduinoManager.Instance.pinMode(11, PinMode.Servo);
        StartCoroutine("SoundLoop");
        updateTimer = true;
        levelTimer = 0.0f;
    }

    // Update is called once per frame
    
    IEnumerator SoundLoop()
    {
        while(true)
        {
            UduinoManager.Instance.digitalWrite(7, State.HIGH);
            UduinoManager.Instance.digitalWrite(8, State.HIGH);
            UduinoManager.Instance.analogWrite(11, 200);
            yield return new WaitForSeconds(1f);
            UduinoManager.Instance.digitalWrite(7, State.LOW);
            UduinoManager.Instance.digitalWrite(8, State.LOW);
            UduinoManager.Instance.analogWrite(11, 0);
            yield return new WaitForSeconds(1f);
        }
    }


    private void Update()
    {
        
        levelTimer += Time.deltaTime * 1;
        updateTimer = false;
        print("Stopped" + Time.time);

        if (Input.GetMouseButtonDown(0))
        {
            StopAllCoroutines();
            UduinoManager.Instance.digitalWrite(7, State.LOW);
            UduinoManager.Instance.digitalWrite(8, State.LOW);
        }
        }

 

            
}
