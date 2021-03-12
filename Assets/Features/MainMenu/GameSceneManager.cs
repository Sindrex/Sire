using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public enum Scene
    {
        MainMenu = 0, 
        MainGame = 1, 
        MapMaker = 2
    }

    public static GameSceneManager Instance {get;private set;}
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene((int)scene);
    }

    public void LoadScene(int scene)
    {
        LoadScene((Scene)scene);
    }

}
