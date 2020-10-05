using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public ReadOnlyCollection<GhostableState> history;
    private IEnumerator<GhostableState> historyEnumerator;
    private Rigidbody2D rb2d;

    public int desiredCollisionCount;
    public int collisionCount;

    public float poofFactor = 5000;

    private GhostableState curState;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        historyEnumerator = history.GetEnumerator();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        //rb2d = GetComponent<Rigidbody2D>();
    }

    //void EnableSpin()
    //{
    //    transform.GetChild(0).gameObject.SetActive(true);
    //}

    //void DisableSpin()
    //{
    //    transform.GetChild(0).gameObject.SetActive(false);
    //}

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (var contact in collision.contacts)
        {
            Debug.Log(contact.normalImpulse);
            if (contact.normalImpulse > poofFactor)
            {
                Destroy(gameObject);
            }
        }

    }

    void FixedUpdate()
    {
        //DisableSpin();
        if (historyEnumerator.MoveNext())
        {
            curState = historyEnumerator.Current;
            desiredCollisionCount = curState.collisionCount;
            float xMove = curState.pos.x - transform.position.x;
            transform.position = curState.pos;

            if (Mathf.Abs(xMove) > 0.1)
            {
                spriteRenderer.flipX = xMove < 0;
            }
        }
    }
}
