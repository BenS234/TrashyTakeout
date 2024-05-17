using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class badcollectionscript : MonoBehaviour
{
    public TMP_Text info;
    public Slider Bar;
    public IEnumerator collect;
    public float timer;
    public float timerMax;
    public GmScript Gm;
    // Start is called before the first frame update
    void Start()
    {
        timerMax = 2f;
        Bar.gameObject.SetActive(false);
        info.text = "";
        Gm = GameObject.Find("GameManager").GetComponent<GmScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            info.text = "Collecting";
            Bar.gameObject.SetActive(true);
            collect = Collecting();
            StartCoroutine(collect);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            timer += Time.deltaTime;
            Bar.value = timer;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        StopCoroutine(collect);
        info.text = "";
        Bar.gameObject.SetActive(false);
        Bar.value = 0;
        timer = 0;
    }
    public IEnumerator Collecting()
    {
        yield return new WaitForSeconds(timerMax);
        Gm.score -= 1;
        Destroy(gameObject);
    }
}
