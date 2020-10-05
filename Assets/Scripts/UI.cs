using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public Button skipButton;
    public GameObject timeDisplay;
    void Start()
    {
        DontDestroyOnLoad(transform.parent.gameObject);
        DontDestroyOnLoad(FindObjectOfType<EventSystem>().gameObject);

    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        gameObject.SetActive(false);
        skipButton.gameObject.SetActive(true);
        timeDisplay.gameObject.SetActive(true);
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBGL
        Application.OpenURL("https://ldjam.com/events/ludum-dare/47/$221274");
#else
        Application.Quit();
#endif
    }
}
