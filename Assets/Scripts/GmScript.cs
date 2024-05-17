using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GmScript : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public TMP_Text gameText;
    public float score;
    public float timer;
    public bool winner;
    public bool doneDeal;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("Score Text").GetComponent<TMP_Text>();
        timerText = GameObject.Find("Timer Text").GetComponent<TMP_Text>();
        gameText = GameObject.Find("Game Text").GetComponent<TMP_Text>();
        gameText.text = "";
        winner = false;

        score = 0;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        


    }
}
