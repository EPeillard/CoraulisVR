using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEvents : MonoBehaviour
{
    public Animation anim;
    public bool startAnim;

    bool animStarted = false;
    public bool changeProj;
    private bool projChanged;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<CoraulisCommander>().SwitchProjection();
        FindObjectOfType<CoraulisCommander>().SwitchProjection();
    }

    // Update is called once per frame
    void Update()
    {
        if(startAnim && !animStarted)
        {
            FindObjectOfType<CoraulisCommander>().SwitchCoraulis();
            animStarted = true;
        }
        else if(!startAnim)
        {
            animStarted = false;
        }

        if(changeProj && !projChanged)
        {
            FindObjectOfType<CoraulisCommander>().SwitchProjection();
            projChanged = true;
        }
        else if(!changeProj)
        {
            projChanged = false;
        }
    }
}
