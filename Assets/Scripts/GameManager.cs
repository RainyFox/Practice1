using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject[] players;

    private int _charIndex;

    public int charIndex
    {
        get { return _charIndex; }
        set { _charIndex = value; }
    }
    // Start is called before the first frame update

    public void Awake()
    {
        //Set up s
        //ingleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "GamePlay")
        {
            Instantiate(players[charIndex]);
        }
    }
}
