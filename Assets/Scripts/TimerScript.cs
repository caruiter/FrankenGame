using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    private float ct;
    private int timeElapsed;

    [SerializeField] TextMeshProUGUI timerText;
    private BulletSpawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        ct = 0;
        timeElapsed = 0;
        spawner = gameObject.GetComponent<BulletSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        ct += Time.deltaTime;
        if (ct >= 1)
        {
            ct = 0;
            timeElapsed++;
            timerText.text = timeElapsed/60 + ":"+timeElapsed%60;

            if (timeElapsed >= 60)
            {
                spawner.interval = .1f;
            } else if(timeElapsed >= 30)
            {
                spawner.interval = .5f;
            } else if(timeElapsed >= 10)
            {
                spawner.interval = .8f;
            }
        }
    }


    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("FrankenGame");
    }
}
