using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    [SerializeField] GameObject Krusty;
    [SerializeField] GameObject KrustyTp;

    [SerializeField] Camera PlayerTp;
    [SerializeField] Camera Main;

    [SerializeField] Vector3 Pos1;

    [SerializeField] Vector3 Pos2;

    [SerializeField] Vector3 Pos3;
    [SerializeField] Vector3 Pos4;

    [SerializeField] float time;

    public Buttons doorClosed;

    public bool isAtShock = false;
    public bool rtol = false;
    public bool gotShocked;

    public AudioManager audio;

    private bool isKill;

    private void Update()
    {
        time -= Time.deltaTime;

        if (time < 0)
        {
            print("Moving Krusty...");

            if (!rtol && !isKill)
            {
                StartCoroutine(GoLeft());
                rtol = true;
            }
            else if (rtol && !isKill)
            {
                StartCoroutine(GoRight());
                rtol = false;
            }

            time = UnityEngine.Random.Range(12f, 15f);

        }
    }

    private IEnumerator GoLeft()
    {
        Krusty.transform.position = Pos2;

        yield return new WaitForSeconds(6.57f);

        Krusty.transform.position = Pos4;

        yield return new WaitForSeconds(4.57f);

        if (doorClosed.isClosed)
        {
            print("damn, fine bro");
            Krusty.transform.position = Pos1;
        }
        else
        {
            isKill = true;
            StartCoroutine(Kill());
        }
    }

    private IEnumerator GoRight()
    {
        Krusty.transform.position = Pos2;

        yield return new WaitForSeconds(6.57f);

        Krusty.transform.position = Pos3;
        isAtShock = true;

        yield return new WaitForSeconds(4.57f);

        if (gotShocked)
        {
            print("damn, fine bro");

            isAtShock = false;
            gotShocked = false;

            Krusty.transform.position = Pos1;
        }
        else
        {
            isKill = true;
            StartCoroutine(Kill());
        }
    }

    private IEnumerator Kill()
    {
        Krusty.transform.position = KrustyTp.transform.position;
        PlayerTp.enabled = true;
        Main.enabled = false;

        audio.PlayDeath();

        yield return new WaitForSeconds(0.75f);

        Application.Quit();
    }
}
