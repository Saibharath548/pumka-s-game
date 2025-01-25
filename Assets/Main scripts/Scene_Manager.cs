using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public Animator Ani;
    public static Scene_Manager instance;
    public string scene;
    public AudioSource AS;
    public static GameManager GM;
    [HideInInspector]public int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
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
        if (scene == "Game" && GameManager.Broke)
        {
            if (count == 0)
            {
                StartCoroutine(Change());                   
            }
            else if (count == 1 && Input.GetMouseButtonDown(0))
            {
                AS.Play();
                Ani.SetTrigger("Menu");
                count = 0;
            }
        }
        //Debug.Log(count);
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
        count = 1;
        yield return new WaitForSeconds(2);
        AS.Play();
        Ani.SetTrigger("All");
    }
}
