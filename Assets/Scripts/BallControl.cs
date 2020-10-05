using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BallControl : MonoBehaviour
{
    public GameObject wreckingBall;
    public int direction = 0;
    public Sprite spriteUnpressed;
    public Sprite spritePressed;
    public AudioClip downClip;
    public AudioClip upClip;

    private int triggerCount;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer != 8 && other.gameObject.layer != 10) { return; }
        if (triggerCount == 0)
        {
            wreckingBall.GetComponentInChildren<Wrecker>().direction = direction;
            spriteRenderer.sprite = spritePressed;
            audioSource.clip = downClip;
            audioSource.Play();
        }
        triggerCount++;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer != 8 && other.gameObject.layer != 10) { return; }
        triggerCount--;
        if (triggerCount <= 0)
        {
            //wreckingBall.GetComponentInChildren<Wrecker>().target = 219;
            spriteRenderer.sprite = spriteUnpressed;
            audioSource.clip = upClip;
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
