using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help1 : MonoBehaviour
{
    private GameObject help1;
    static bool shown = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!shown)
        {
            help1 = GameObject.Find("Help1");
            help1.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
            shown = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (help1)
        {
            help1.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
