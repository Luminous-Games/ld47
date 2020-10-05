using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetJoint2D))]
public class MoveablePlatform : MonoBehaviour
{
    public Vector2[] positions;
    public int selectedIndex = 0;

    private TargetJoint2D targetJoint;
    private Vector2 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        targetJoint = GetComponent<TargetJoint2D>();
        spawnPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (positions.Length == 0) return;

        var virtualSelectedIndex = selectedIndex;
        if (virtualSelectedIndex < 0) virtualSelectedIndex = 0;
        if (virtualSelectedIndex > positions.Length - 1) virtualSelectedIndex = positions.Length - 1;
        this.targetJoint.target = positions[virtualSelectedIndex] + spawnPosition;
    }
}
