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
    public static bool ChangeCheck = true;
    public Button Menu;

    // Start is called before the first frame update
    void Start()
    {
        Menu = GameObject.Find("Button").GetComponent<Button>();
        Menu.onClick.AddListener(ScoreB);
        GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        AS = GetComponent<AudioSource>();
        Ani = GetComponent<Animator>();
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
        //Debug.Log(scene);
        if (scene == "Menu" && Input.GetMouseButtonDown(0))
        {
            AS.Play();
            Ani.SetTrigger("Game");
        }
        if (scene == "Game" && GameManager.Broke && !ChangeCheck)
        {
            StartCoroutine(Change());
        }
    }
    public void ScoreB()
    {
        if (scene == "Game" && GameManager.Broke && ChangeCheck)
        {
            ChangeCheck = false;
            AS.Play();
            Ani.SetTrigger("Menu");
        }
    }
    
    public void LoadGame(string Level)
    {
        SceneManager.LoadScene(Level);
    }
    public void ScoreUI()
    {
        GM.ShowUI();
    }
    IEnumerator Change()
    {
        ChangeCheck = true;
        yield return new WaitForSeconds(3);
        AS.Play();
        Ani.SetTrigger("All");
    }
}
