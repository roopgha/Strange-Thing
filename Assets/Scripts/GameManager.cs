using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameObject[] key;
    public static int interactionNumber;
    public static bool isUserSeeStory;
    public static int stageNumber;
    public static bool isUserHaveKey;
    public static bool isOnClickKey;
    public static bool isOnClickDoor;

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

    public void OnClickDoor()
    {
        isOnClickDoor = true;
    }

    public void OnClickKey()
    {
        isOnClickKey = true;
        GameManager.key[GameManager.stageNumber].SetActive(false);
    }
}
