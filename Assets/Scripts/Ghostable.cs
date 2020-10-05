using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public struct GhostableState
{
    public readonly Vector2 pos;
    public readonly int collisionCount;

    public GhostableState(Vector2 pos, int collisionCount)
    {
        this.pos = pos;
        this.collisionCount = collisionCount;
    }
}

public class Ghostable : MonoBehaviour
{
    private List<GhostableState> history = new List<GhostableState>();
    private Rigidbody2D rb2d;
    private int collisionCount;

    public ReadOnlyCollection<GhostableState> History
    {
        get
        {
            return this.history.AsReadOnly();
        }

    }

    public void ResetHistory()
    {
        this.history = new List<GhostableState>();
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.history.Add(new GhostableState(rb2d.position, collisionCount));

    }
}
