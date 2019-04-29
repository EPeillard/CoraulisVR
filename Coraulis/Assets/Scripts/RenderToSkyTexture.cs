using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class RenderToSkyTexture : MonoBehaviour
{
    Camera cam;
    public RenderTexture toRender;
    public RenderTexture tempCubeMap;

    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        cam.enabled = true;
        cam.RenderToCubemap(tempCubeMap);
        tempCubeMap.ConvertToEquirect(toRender);
        cam.enabled = false;
    }
}
