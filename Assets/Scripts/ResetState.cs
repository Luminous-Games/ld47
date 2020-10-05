using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetState : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform t in FindObjectsOfType<Transform>())
        {
            if (t.gameObject.name != "SecretCam")
            {
                Destroy(t.gameObject);
            }
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}
