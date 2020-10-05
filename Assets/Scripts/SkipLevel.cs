using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipLevel : MonoBehaviour
{
    public void Skip()
    {
        GhostManager.CleanHistory();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
