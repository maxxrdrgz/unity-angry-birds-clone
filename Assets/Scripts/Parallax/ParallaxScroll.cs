using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroll : MonoBehaviour
{
    public float parallaxFactor;
    private Vector3 prevCameraPos;

    // Start is called before the first frame update
    void Start()
    {
        prevCameraPos = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 delta = Camera.main.transform.position - prevCameraPos;
        delta.y = 0;
        delta.z = 0;
        transform.position += delta / parallaxFactor;

        prevCameraPos = Camera.main.transform.position;
    }
}
