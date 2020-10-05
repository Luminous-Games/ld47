using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrecker : MonoBehaviour
{
    public float degreesPerSecond = 60f;
    public float target = 219;
    public float spread = 81;
    public int direction = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        float diff = (this.transform.eulerAngles.z - (target + direction * spread) + 360) % 360;
        if (diff < 4)
        {
            direction = 0;
        }
        //float rotate = Input.GetAxis("Rotation");
        //float rotate = (this.transform.eulerAngles.z - target + 360) % 360 < 180 ? -1 : 1;
        //Debug.Log(rotate);
        this.transform.Rotate(Vector3.forward, direction * degreesPerSecond * Time.fixedDeltaTime);

    }
}
