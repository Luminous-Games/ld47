using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public float forceMultiplier;

    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void OnTriggerStay2D(Collider2D other)
    {
        float diff = other.attachedRigidbody.position.x - rb2d.position.x;
        other.attachedRigidbody.AddForce(new Vector2(diff * forceMultiplier, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
