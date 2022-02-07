using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject Flash;
    [SerializeField] GameObject Light;
    [SerializeField] GameObject Phone;

    public bool PhoneActive = true;

    private bool FlashLightActive = false;

    private void Start()
    {
        Flash.gameObject.SetActive(false);
        Light.gameObject.SetActive(false);
    }

    private void Update()
    {
        bool deez = false;

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (FlashLightActive == false)
            {
                Flash.gameObject.SetActive(true);
                Light.gameObject.SetActive(true);
                FlashLightActive = true;
            }
            else
            {
                Flash.gameObject.SetActive(false);
                Light.gameObject.SetActive(false);
                FlashLightActive = false;
            }
        }

        //print(Time.time);
    }

    private IEnumerator SlidePhone()
    {
        float minHeight = 5;
        
        if (Phone.transform.position.y < minHeight) Phone.transform.Translate(0f, 0.5f * Time.deltaTime, 0f);

        yield return new WaitForSeconds(3f);
        Phone.SetActive(false);
    }
}
