using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] GameObject RightHall;
    [SerializeField] GameObject LeftHall;
    [SerializeField] GameObject Stage;
    [SerializeField] GameObject DiningRoom;

    [SerializeField] GameObject Static;

    public Camera LeHall;
    public Camera RiHall;
    public Camera LeStage;
    public Camera LeDining;

    public void LHall()
    {
        StartCoroutine(StaticFeed());

        LeHall.enabled = true;

        RightHall.transform.position = new Vector3(-30, -30, -30);
        Stage.transform.position = new Vector3(-30, -30, -30);
        DiningRoom.transform.position = new Vector3(-30, -30, -30);

        LeftHall.transform.position = new Vector3(-71.35f, 31.5f, -10.965f);
    }

    public void RHall()
    {
        StartCoroutine(StaticFeed());

        RiHall.enabled = true;

        LeftHall.transform.position = new Vector3(-30, -30, -30);
        Stage.transform.position = new Vector3(-30, -30, -30);
        DiningRoom.transform.position = new Vector3(-30, -30, -30);

        RightHall.transform.position = new Vector3(-71.35f, 31.25f, -10.965f);
    }

    public void MainStage()
    {
        StartCoroutine(StaticFeed());

        LeStage.enabled = true;

        RightHall.transform.position = new Vector3(-30, -30, -30);
        LeftHall.transform.position = new Vector3(-30, -30, -30);
        DiningRoom.transform.position = new Vector3(-30, -30, -30);

        Stage.transform.position = new Vector3(-71.35f, 31.25f, -10.965f);
    }

    public void Dining()
    {
        StartCoroutine(StaticFeed());

        LeDining.enabled = true;

        RightHall.transform.position = new Vector3(-30, -30, -30);
        Stage.transform.position = new Vector3(-30, -30, -30);
        LeftHall.transform.position = new Vector3(-30, -30, -30);

        DiningRoom.transform.position = new Vector3(-71.35f, 31.25f, -10.965f);
    }

    private IEnumerator StaticFeed()
    {
        Static.transform.position = new Vector3(-71.35f, 31.65f, -10.965f);

        yield return new WaitForSeconds(0.35f);

        Static.transform.position = new Vector3(-71.35f, 31.35f, -10.965f);
    }
}
