using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    #region Parameters

    [SerializeField] GameObject Button;
    [SerializeField] GameObject Lever;
    [SerializeField] GameObject Door;
    [SerializeField] Canvas Original;
    [SerializeField] Canvas Walking;
    [SerializeField] MeshRenderer MakeInvisible;
    [SerializeField] bool LeverPos = false;
    [SerializeField] Light ShockLight;
    [SerializeField] Power power;

    public ParticleSystem Sparks;
    public ParticleSystem Shock;

    public bool IsDoorButton; // if true (change in editor) the button is for the door
    public bool isClosed;

    public AIManager aiManager;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Walking.enabled = false;

        // make trigger invisible
        MakeInvisible.enabled = false;

        ShockLight.enabled = false;

        isClosed = false;
    }

    private void OnMouseDown()
    {
        print("Clicked! : " + gameObject);

        // play spark animation
        Sparks.Play();

        LeverPos = !LeverPos;
        
        if (!IsDoorButton && power.PowerMeter.value > 49.4)
        {
            StartCoroutine(ShockLightRoutine());
            Shock.Play();
        }
    }

    private void Update()
    {
        if (!IsDoorButton) { return; }

        if (LeverPos && power.PowerMeter.value > 49.4)
        {
           float maximumOpening = -1.35f;

            if (Door.transform.position.y > maximumOpening)
            {
                print("Closing...");
                isClosed = true;

                power.subtractPowerBy(0.0001f);

                Door.transform.Translate(0f, -5f * Time.deltaTime, 0f);
            }
       }
       
       else if (!LeverPos)
       {
           float maximumClosing = 1.35f * 6f;

           if (Door.transform.position.y < maximumClosing)
           {
               print("Opening...");
               isClosed = false;
               Door.transform.Translate(0f, 1.5f * Time.deltaTime, 0f);
           }
       }

       if (power.PowerMeter.value <= 49.4 && !LeverPos)
       {
            float maximumClosing = 1.35f * 6f;

            if (Door.transform.position.y < maximumClosing)
            {
                print("Opening...");
                isClosed = false;
                Door.transform.Translate(0f, 1.5f * Time.deltaTime, 0f);
            }
        }
    }

    private void OnMouseEnter()
    {
        print("Over The Button!");

        Walking.enabled = true;
        Original.enabled = false;
    }

    private void OnMouseExit()
    {
        Walking.enabled = false;
        Original.enabled = true;
    }

    private IEnumerator ShockLightRoutine()
    {
        power.subtractPowerBy(0.0001f);

        if (aiManager.isAtShock)
        {
            aiManager.gotShocked = true;
        }

        ShockLight.enabled = true;
        ShockLight.cookieSize += 3.5f;

        isClosed = true;

        yield return new WaitForSeconds(0.75f);

        ShockLight.cookieSize -= 3.5f;
        ShockLight.enabled = false;

        yield return new WaitForSeconds(7f);

        isClosed = false;
    }
}
