using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject victoryscreen;
    private float time;
    private float seconds;
    private float minutes;
    private bool timing;

    // Start is called before the first frame update
    void Start()
    {
        timing = true;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timing)
        {
            time += Time.deltaTime;
            float minutes = Mathf.Floor(time / 60);
            float seconds = Mathf.RoundToInt(time % 60);

            text.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }

    public void Victory()
    {
        victoryscreen.SetActive(true);
        timing = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
