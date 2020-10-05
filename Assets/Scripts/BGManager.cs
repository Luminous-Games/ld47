using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGManager : MonoBehaviour
{
    public Sprite[] sprites;
    public float width = 10;
    public float height = 10;
    public int count = 100;
    public float scale = 1;

    private List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            GameObject obj = new GameObject("asdfs");
            obj.transform.parent = transform;
            obj.AddComponent(typeof(SpriteRenderer));
            var spriteRenderer = obj.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
            spriteRenderer.transform.localScale = new Vector2(scale, scale);
            spriteRenderers.Add(spriteRenderer);
            obj.transform.position = new Vector3(Random.Range(-width, width), Random.Range(-height, height), 1);
            obj.transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var spriteRenderer in spriteRenderers)
        {
            spriteRenderer.transform.localScale = new Vector2(scale, scale);
        }
    }
}
