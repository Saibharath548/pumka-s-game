using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public static bool Broke = false;
    public GameObject ScoreUI;
    public GameObject[] Set;
    public VideoPlayer Player;
    public GameObject P;
    private float health = 15;
    private int Score ;
    public TextMeshProUGUI ScoreO;
    public TextMeshProUGUI UI;
    public Slider Slider1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spwan());
    }

    // Update is called once per frame
    void Update()
    {
        if (bubble.Move)
        {
            Set[0].SetActive(true);
            Set[1].SetActive(true);
            Set[2].SetActive(true);
            Score += ((int)Time.time) / 2;
            ScoreO.text = Score.ToString();
            Debug.Log(Score);
            healthUI();
        }
        UI.text = (bubble.Fuel.ToString() + "\n" + "  " + bubble.Hard.ToString());
    }

    public void healthUI()
    {
        if (health > 0)
        {
            health -= Time.deltaTime;
            Slider1.value = health;
        }
    }

    public void ShowUI()
    {
        Player.Play();
        ScoreUI.SetActive(true);
    }

    IEnumerator Spwan()
    {
        yield return new WaitForSeconds(.75f);
        P.SetActive(true);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Clone"))
        {
            Destroy(collision.gameObject);
        }
    }
}
