using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public static bool Broke = false;
    public GameObject ScoreUI;
    public GameObject[] Set;
    public VideoPlayer Player;
    public GameObject P;
    [SerializeField]private float health = 30;
    private int Score ;
    public TextMeshProUGUI ScoreO;
    public TextMeshProUGUI UI;
    private float elapsedTime;
    public Slider Slider1;
    public static bool CollectedH;
    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0f;
        Score = 0;
        ScoreO.text = Score.ToString();
        Broke = false;
        ScoreUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (bubble.Move)
        {
            Set[0].SetActive(true);
            Set[1].SetActive(true);
            Set[2].SetActive(true);
            elapsedTime += Time.deltaTime;
            Score = (int)(elapsedTime * 100);
            ScoreO.text = Score.ToString();
            //Debug.Log(Score);
            healthUI();
        }
        if (Broke)
        {
            Score = 0;
        }
        UI.text = bubble.Hard.ToString();
        if (Scene_Manager.ChangeCheck)
        {
            StartCoroutine(Spwan());
        }
    }

    public void healthUI()
    {
        if (health > 0)
        {
            health -= Time.deltaTime;
            Slider1.value = health;
        }
        if(CollectedH)
        {
            health = 30;
            CollectedH = false;
        }
    }

    public void ShowUI()
    {
        ScoreUI.SetActive(true);
    }

    IEnumerator Spwan()
    {
        yield return new WaitForSeconds(1.25f);
        P.SetActive(true);
        movement.MoveP = true;
    }
}
