using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitors : MonoBehaviour
{
    #region SerializeField
    [SerializeField] MeshRenderer MakeInvisible;
    [SerializeField] Canvas MainCanvas;
    [SerializeField] Canvas Original;
    [SerializeField] Canvas Walking;
    [SerializeField] Canvas MonitorCanvas;
    [SerializeField] Camera Main;
    [SerializeField] Camera MonitorMain;
    [SerializeField] Camera RightHall;
    [SerializeField] Camera LeftHall;
    #endregion

    public MoveCamera moveCameraScript;
    public bool isInMonitor;

    public Door atTheDoor;

    // Start is called before the first frame update
    void Start()
    {
        Walking.enabled = false;

        RightHall.enabled = true;
        LeftHall.enabled = true;

        MonitorCanvas.enabled = false;
        MakeInvisible.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && isInMonitor) // leaving
        {
            isInMonitor = false;

            MonitorCanvas.enabled = false;
            MainCanvas.enabled = true;

            Cursor.visible = false;
            moveCameraScript.ShowCursor = false; // Turn Off Cursor
            Cursor.lockState = CursorLockMode.Locked;

            Main.enabled = true;
            MonitorMain.enabled = false;
        }

        if (isInMonitor) // entered
        {
            Cursor.visible = true;
            moveCameraScript.ShowCursor = true;
            Cursor.lockState = CursorLockMode.None;

            MonitorCanvas.enabled = true;
            MainCanvas.enabled = false;
            Main.enabled = false;
            MonitorMain.enabled = true;
        }
    }

    private void OnMouseDown()
    {
        print("Clicked On Monitors!");
        if (!isInMonitor) { isInMonitor = true; }
    }

    private void OnMouseEnter()
    {
        print("Over The Monitors!");

        Walking.enabled = true;
        Original.enabled = false;
    }

    private void OnMouseExit()
    {
        Walking.enabled = false;
        Original.enabled = true;
    }
}
