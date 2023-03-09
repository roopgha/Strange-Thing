using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DataSelect : MonoBehaviour
{
    void Awake()
    {
        DataSelect[] dataSelects = FindObjectsOfType<DataSelect>();
        if(dataSelects.Length == 1)
        {
           DontDestroyOnLoad(this.gameObject);   
        } 
        else
        {
            Destroy(this.gameObject);
        }  
    }
    public void ChangeStage1()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void ChangeOtherStage()
    {
        SceneManager.LoadScene("Stage2");
        GameManager.isUserSeeStory = false;
        GameManager.stageNumber++;
    }

    public void ChangeMainScene()
    {
        SceneManager.LoadScene("Main");
    }
}
