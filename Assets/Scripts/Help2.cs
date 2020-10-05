using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help2 : MonoBehaviour
{
    private GameObject help2;
    static bool shown = false;
    // Start is called before the first frame update
    void Start()
    {
        help2 = GameObject.Find("Help2");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!shown)
        {
            help2.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
            shown = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
