using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    int[] levels = { -6, -2, 2, 6, int.MaxValue };
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        bool[] choices = { true, true, true, true };
        bool doSth = false;
        float ypos = transform.position.y;
        Ghostable player = FindObjectOfType<Ghostable>();
        foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            if (go.layer == 8 && go.transform.position.x > -13)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (go.transform.position.y > levels[i] && go.transform.position.y < levels[i + 1])
                    {
                        choices[i] = false;
                        doSth = true;
                        break;
                    }
                }
            }
        }
        if (doSth)
        {
            for (int i = 0; i < 4; i++)
            {
                if (choices[i])
                {
                    ypos = levels[i] + 2;
                    break;
                }
            }
        }
        transform.position = new Vector2(-player.transform.position.x, ypos);
    }
}
