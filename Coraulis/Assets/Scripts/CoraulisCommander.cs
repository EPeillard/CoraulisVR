using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoraulisCommander : MonoBehaviour
{
    public Material proj;
    public Material plain;
    public GameObject partieMobile;
    public List<GameObject> screens;
    public Vector3 projRef;
    public GameObject maquetteBlanche;
    public GameObject maquetteCouleur;

    bool started = true;
    Animation anim;
    private bool modeImmersion = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = partieMobile.GetComponent<Animation>();
        StartCoroutine("SwitchOnOff");
    }

    public void SwitchCoraulis()
    {
        StartCoroutine("SwitchOnOff");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("SwitchOnOff");
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            SwitchProjection();
        }
    }

    public void SwitchProjection()
    {
        modeImmersion = !modeImmersion;
        if(modeImmersion)
        {
            proj.SetVector("_Pos", new Vector4(0, 0, 0, 1));
        }
        else
        {
            Vector4 v = Vector4.zero;
            v.x = projRef.x;
            v.y = projRef.y;
            v.z = projRef.z;
            proj.SetVector("_Pos", v);
        }
    }

    private IEnumerator SwitchOnOff()
    {
        if(started) //Turn off
        {
            foreach (GameObject s in screens)
            {
                s.GetComponent<MeshRenderer>().material = plain;
            }
            maquetteBlanche.SetActive(true);
            maquetteCouleur.SetActive(false);
            foreach (AnimationState state in anim)
            {
                state.speed = -1;
                state.time = state.length;
            }
            anim.Play();
            while (anim.isPlaying)
            {
                yield return new WaitForEndOfFrame();
            }
        }
        else //Turn on
        {
            foreach (AnimationState state in anim)
            {
                state.speed = 1;
            }
            anim.Play();
            while (anim.isPlaying)
            {
                yield return new WaitForEndOfFrame();
            }
            foreach (GameObject s in screens)
            {
                s.GetComponent<MeshRenderer>().material = proj;
            }
            maquetteBlanche.SetActive(false);
            maquetteCouleur.SetActive(true);
        }
        started = !started;
    }
}
