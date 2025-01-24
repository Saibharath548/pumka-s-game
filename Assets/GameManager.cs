using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public static bool Broke = false;
    public GameObject ScoreUI;
    public VideoPlayer Player;
    public GameObject P;
    private float Timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spwan());
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
    IEnumerator Spwan()
    {
        yield return new WaitForSeconds(.75f);
        P.SetActive(true);
    }
}
