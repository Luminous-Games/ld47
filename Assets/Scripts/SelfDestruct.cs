using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float after = .5f;
    private float start = 0f;
    void Start()
    {
        start = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - start > after)
        {
            gameObject.SetActive(false);
        }

    }
}
