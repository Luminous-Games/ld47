using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLevel : MonoBehaviour
{
    // Update is called once per frame
    public void GotoMain()
    {
        SceneManager.LoadScene(0);

    }
}
