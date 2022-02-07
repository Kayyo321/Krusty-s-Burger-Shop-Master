using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
    [SerializeField] float time = 2.5f;
    [SerializeField] Text clock;

    public Slider PowerMeter;

    void Start()
    {
        clock.text = Time.time.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            subtractPowerBy(0.00005f);
        }

        clock.text = ((int)Time.time).ToString() + " / 360";

        if (Time.time >= 360)
        {
            Application.Quit();
        }
    }

    public void subtractPowerBy(float amount)
    {
        PowerMeter.value -= amount;
    }
}
