using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 231;
        timeText.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        float minutes = Mathf.Floor((timeLeft*2.6f)/60);
        float seconds = Mathf.RoundToInt((timeLeft*2.6f)%60);

        if (minutes < 6 && minutes > 4)   
            timeText.color = Color.yellow;
        if(minutes < 4)
            timeText.color = Color.red;

         if (timeLeft < 0)
             timeText.text = "Game Over!";

        timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
