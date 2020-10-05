using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Wrecker))]
public class AutoBallControl : MonoBehaviour
{
    public float period = 5;

    private Wrecker wreckingBall;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        wreckingBall = GetComponent<Wrecker>();
    }

    void FixedUpdate()
    {
        int direction = Time.fixedTime % period < period / 2 ? -1 : 1;
        wreckingBall.GetComponentInChildren<Wrecker>().direction = direction;
    }
}
