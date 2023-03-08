using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] key;
    public static int interactionNumber;
    public static bool isUserSeeStory = false;
    public static int stageNumber;
    public static bool isUserHaveKey = false;

    void Awake()
    {
        key = GameObject.FindGameObjectsWithTag("key");
        GameManager[] gameManagers = FindObjectsOfType<GameManager>();
        if(gameManagers.Length == 1)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Update() 
    {
       
    }

    public void OnClickKey()
    {

    }
}
