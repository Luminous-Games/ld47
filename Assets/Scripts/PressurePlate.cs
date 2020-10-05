using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
public class PressurePlate : MonoBehaviour
{
    public MoveablePlatform gate;
    private int collisions = 0;
    public Sprite spriteUnpressed;
    public Sprite spritePressed;
    public AudioClip downClip;
    public AudioClip upClip;

    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer != 8) { return; }
        if (collisions == 0)
        {
            gate.selectedIndex += 1;
            spriteRenderer.sprite = spritePressed;
            audioSource.clip = downClip;
            audioSource.Play();
        }
        collisions++;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer != 8) { return; }
        collisions--;
        if (collisions == 0)
        {
            spriteRenderer.sprite = spriteUnpressed;
            gate.selectedIndex -= 1;
            audioSource.clip = upClip;
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
