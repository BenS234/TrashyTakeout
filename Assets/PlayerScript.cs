using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public int health;
    public float timer;
    public TMP_Text healthInfo;
    public Slider healthBar;
    public TMP_Text statusText;
    public Transform spawn;
    public GameObject boss;
    public BossScript bossScript;
    public bool loseMessage;
    public float timer2;
    public bool winMessage;
    public bool hit;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        timer = 0;
        healthInfo.text = "Health:";
        healthBar = GameObject.Find("HealthBar").GetComponent<Slider>();
        statusText.text = "";
        bossScript = boss.GetComponent<BossScript>();
        loseMessage = false;
        timer2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            bossScript.health -= 4;
            hit = false;
        }
        timer += Time.deltaTime;
        if(timer > 10 && health <= 95)
        {
            timer = 0;
            health += 5;
        }
        healthBar.value = health;
        if(health <= 0 && bossScript.health > 0)
        {
            loseMessage = true;
            bossScript.health = 500;
            health = 100;
            transform.position = spawn.position;
        }
        if (loseMessage)
        {
            statusText.text = "You lose! Try again!";
            timer2 += Time.deltaTime;
            if(timer2 > 2)
            {
                loseMessage = false;
                statusText.text = "";
                timer2 = 0;
            }
        }
        if(health <= 0)
        {
            transform.position = spawn.position;
            health = 100;
        }
        if(bossScript.health <= 0)
        {
            winMessage = true;
            health = 100;
        }
        if (winMessage)
        {
            statusText.text = "The boss has been defeated!";
            timer2 += Time.deltaTime;
            if (timer2 > 2)
            {
                winMessage = false;
                statusText.text = "";
                timer2 = 0;
            }
        }
    }
}
