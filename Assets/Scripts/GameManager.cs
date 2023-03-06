using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isUserSeeStory = false;

    void Awake()
    {
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
    private void Update() {
        print(isUserSeeStory);
    }
}
