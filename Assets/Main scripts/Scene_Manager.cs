using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene_Manager : MonoBehaviour
{
    public Animator Ani;
    public static Scene_Manager instance;
    public string scene;
    public AudioSource AS;
    public GameManager GM;
    public static bool ChangeCheck = false;
    public GameObject TapAgain;

    // Start is called before the first frame update
    void Start()
    {
        Ani = GetComponent<Animator>();
        AS = GetComponent<AudioSource>();
        if (instance && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        scene = SceneManager.GetActiveScene().name;
        if (scene != "Menu")
        {
            if (TapAgain == null)
            {
                TapAgain = GameObject.Find("TapAgain");
                TapAgain.SetActive(false);
            }
            GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        }
        if (scene == "Menu" && Input.GetMouseButtonDown(0))
        {
            ChangeCheck = true;
            AS.Play();
            Ani.SetTrigger("Game");
        }
        else if (scene == "Game" && GameManager.Broke && ChangeCheck)
        {
            StartCoroutine(Change(2));
        }
        else if (scene == "Game" && GameManager.Broke && !ChangeCheck && Input.GetMouseButtonDown(0))
        {
            AS.Play();
            Ani.SetTrigger("Menu");
        }
    }
    public void WhichMenu(int num)
    {
        switch (num)
        {
            case 1:SceneManager.LoadScene("Game");
                break;
            case 2:
                SceneManager.LoadScene("Menu");
                break;
            case 3:TapAgain.SetActive(true);
                   GM.ShowUI();
                break;
        }
    }
    IEnumerator Change(float Time)
    {
        movement.MoveP = false;
        ChangeCheck = false;
        yield return new WaitForSeconds(Time);
        AS.Play();
        Ani.SetTrigger("All");
    }
}
