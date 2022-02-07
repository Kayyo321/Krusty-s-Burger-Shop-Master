using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] MeshRenderer makeInvisible;
    [SerializeField] GameObject player;
    [SerializeField] Vector3 originalPos;
    [SerializeField] Canvas Esc;
    [SerializeField] Canvas Original;
    [SerializeField] Canvas Walking;
    
    public bool isAtDoor;
    public bool isWoodDoor;

    // Start is called before the first frame update
    void Start()
    {
        Esc.enabled = false;
        Walking.enabled = false;

        makeInvisible.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWoodDoor)
        {
            if (Input.GetKey(KeyCode.Escape) && isAtDoor) // leaving
            {
                isAtDoor = false;

                Esc.enabled = false;

                player.transform.position = originalPos;
            }

            if (isAtDoor) // entered
            {
                Esc.enabled = true;

                player.transform.position = transform.position;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Escape) && isAtDoor) // leaving
            {
                isAtDoor = false;

                Esc.enabled = false;

                player.transform.position = originalPos;
            }

            if (isAtDoor) // entered
            {
                Esc.enabled = true;

                player.transform.position = transform.position;
            }
        }
    }

    private void OnMouseDown()
    {
        print("Clicked On Door!");
        if (!isAtDoor) { isAtDoor = true; }
    }

    private void OnMouseEnter()
    {
        print("Over The Door!");

        Walking.enabled = true;
        Original.enabled = false;
    }

    private void OnMouseExit()
    {
        Walking.enabled = false;
        Original.enabled = true;
    }
}
