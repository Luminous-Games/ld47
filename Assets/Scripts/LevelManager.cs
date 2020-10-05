using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class LevelManager : MonoBehaviour
{

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI timeText2;
    public Button skipButton;
    public Button nextButton;
    public Timer timer;
    private AudioSource audioSource;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    public void FinishLevel()
    {
        timeText.gameObject.SetActive(false);
        timeText2.gameObject.SetActive(true);
        skipButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(true);
        timer.Pause();

        GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).gameObject.SetActive(true);
        audioSource.Play();

    }
    public void NextLevel()
    {
        timeText.gameObject.SetActive(true);
        timeText2.gameObject.SetActive(false);
        skipButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(false);

        timer.Reset();
        //GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).gameObject.SetActive(false);
        GhostManager.CleanHistory();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
