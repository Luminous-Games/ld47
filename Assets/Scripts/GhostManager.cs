using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostManager : MonoBehaviour
{
    public Ghostable playerPrefab;
    public Ghost ghostPrefab;
    public float deathZone = -30;
    private Ghostable player;
    private static List<ReadOnlyCollection<GhostableState>> histories = new List<ReadOnlyCollection<GhostableState>>();
    static bool help3Shown = false;
    private Timer timer;
    void Start()
    {
        player = FindObjectOfType<Ghostable>();
        timer = FindObjectOfType<Timer>();
        foreach (var history in histories)
        {
            var ghost = Instantiate(ghostPrefab, history[0].pos, Quaternion.identity);
            ghost.history = history;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Respawn"))
        {
            ReplicateTheCat(true, false);
        }

        if (player.transform.position.y < deathZone)
        {
            ReplicateTheCat(true, false);
        }

        if (Input.GetButtonDown("Restart"))
        {
            ReplicateTheCat(false, true);
        }

        if (Input.GetButtonDown("CancelReplay"))
        {
            ReplicateTheCat(false, false);
        }
    }

    public static void CleanHistory()
    {
        histories.Clear();

    }

    void ReplicateTheCat(bool saveHistory, bool cleanHistory)
    {
        GameObject help2 = GameObject.Find("Help2");
        if (help2)
        {
            help2.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
        }
        GameObject help3 = GameObject.Find("Help3");
        if (help3)
        {
            help3.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;

            if (SceneManager.GetActiveScene().buildIndex == 3 && !help3Shown)
            {
                help3.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
                help3Shown = true;
            }
        }
        var newHistory = player.History;
        if (saveHistory)
        {
            histories.Add(newHistory);
        }

        if (cleanHistory)
        {
            timer.Reset();
            CleanHistory();
        }

        var cameraFollow = FindObjectOfType<CameraFollow>();

        foreach (Transform t in FindObjectsOfType<Transform>())
        {
            if (t != cameraFollow.transform && !t.GetComponent<MusicPlayer>() && t.gameObject.layer != 5)
            {
                Destroy(t.gameObject);
            }
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Additive);
        return;

    }

}
