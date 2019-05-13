using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPosition : MonoBehaviour
{
    public GameObject steamVrRef;
    public List<GameObject> positions;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = steamVrRef.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            steamVrRef.transform.position = startPos;
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            steamVrRef.transform.position = positions[0].transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            steamVrRef.transform.position = positions[1].transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            steamVrRef.transform.position = positions[2].transform.position;
        }
    }
}
