using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float strenght = 1f;
    public float size = 10;
    public float minSize = 5;
    public float maxSize = 20;
    public float scrollSpeed = -5;

    private Camera camera;
    void Awake()
    {
        if (FindObjectsOfType<CameraFollow>().Length > 1)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        size += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        if (size < minSize) size = minSize;
        if (size > maxSize) size = maxSize;
        camera.orthographicSize = size;
    }

    void LateUpdate()
    {
        if (target)
        {
            float z = transform.position.z;
            transform.position = Vector2.Lerp(transform.position, target.position, strenght * Time.deltaTime);
            transform.position += Vector3.forward * z;
        }

    }
}
