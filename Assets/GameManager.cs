using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public static bool Broke = false;
    public GameObject ScoreUI;
    public GameObject Clouds;
    public VideoPlayer Player;
    public GameObject P;
    private int Score ;
    public TextMeshProUGUI ScoreO;
    public TextMeshProUGUI UI;
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
            Clouds.SetActive(true);
            Score += ((int)Time.time) / 2;
            ScoreO.text = Score.ToString();
            Debug.Log(Score);
        }
        UI.text = (bubble.Fuel.ToString() + "\n" + "  " + bubble.Hard.ToString());
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
}
