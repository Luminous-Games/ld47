using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Rope : MonoBehaviour
{
    public int segments = 10;
    public float totalMass = 10;
    public Rigidbody2D a;
    public Rigidbody2D b;

    private LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        float totalLenght = (b.position - a.position).magnitude;
        float segmentLength = totalLenght / segments;

        Rigidbody2D previous = a;

        for (int i = 0; i < segments; ++i)
        {
            GameObject segment = new GameObject("Rope");
            segment.transform.parent = this.transform;
            segment.transform.position = a.position + (b.position - a.position).normalized * segmentLength * (i + 1);
            var rb = segment.AddComponent<Rigidbody2D>();
            rb.mass = totalMass / segments;
            var joint = segment.AddComponent<DistanceJoint2D>();

            joint.anchor = Vector2.zero;
            joint.connectedAnchor = Vector2.zero;
            joint.connectedBody = previous;
            joint.distance = segmentLength;
            joint.autoConfigureDistance = false;



            previous = rb;

        }

        var fixedJoint = b.gameObject.AddComponent<FixedJoint2D>();
        fixedJoint.connectedBody = previous;
        fixedJoint.autoConfigureConnectedAnchor = false;
        fixedJoint.anchor = Vector2.zero;
        fixedJoint.connectedAnchor = Vector2.zero;
        fixedJoint.dampingRatio = 1;

    }

    void Update()
    {
        Vector3[] positions = new Vector3[this.transform.childCount + 1];
        positions[0] = a.position;
        for (int i = 1; i <= this.transform.childCount; ++i)
        {
            var childPos = this.transform.GetChild(i - 1).position;
            positions[i] = new Vector3(childPos.x, childPos.y, 0);
        }
        line.positionCount = positions.Length;
        line.SetPositions(positions);

    }

}
