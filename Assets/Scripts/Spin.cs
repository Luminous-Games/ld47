using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speed = -2;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * speed);


    }
}
