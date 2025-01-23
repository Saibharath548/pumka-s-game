using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public static bool Broke = false;
    public GameObject ScoreUI;
    public VideoPlayer Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowUI()
    {
        Player.Play();
        ScoreUI.SetActive(true);
    }
}
