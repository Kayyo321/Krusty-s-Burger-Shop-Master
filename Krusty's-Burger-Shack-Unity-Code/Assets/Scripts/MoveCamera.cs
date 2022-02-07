using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public bool ShowCursor;
    public float Sensitivity;

    [SerializeField] GameObject cell;

    #region Cameras
    public Camera monitor;
    public Camera main;
    public Camera LeftHall;
    public Camera RightHall;
    public Camera Death;
    #endregion

    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager.PlayPhoneCall();
        StartCoroutine(PutDownPhone());

        ResetCam();
        Cursor.visible = ShowCursor;
    }

    // Update is called once per frame
    void Update()
    {
        float localEulerY = gameObject.transform.localEulerAngles.y;
        float newRotationY = localEulerY + Input.GetAxis("Mouse X") * Sensitivity;
        
        gameObject.transform.localEulerAngles = new Vector3(0, newRotationY, 0);
    }

    void LateUpdate()
    {
        Cursor.visible = ShowCursor;    
    }

    void ResetCam()
    {
        main.enabled = true;

        monitor.enabled = false;
        LeftHall.enabled = false;
        RightHall.enabled = false;
        Death.enabled = false;
    }

    private IEnumerator PutDownPhone()
    {
        yield return new WaitForSeconds(48f);
        print("Putting Down The Phone...");
        cell.SetActive(false);
    }
}
