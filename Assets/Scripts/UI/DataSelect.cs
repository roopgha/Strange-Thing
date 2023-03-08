using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DataSelect : MonoBehaviour
{
    public void ChangeGameScene(){
        SceneManager.LoadScene("Stage1");
    }

    public void ChangeMainScene(){
        SceneManager.LoadScene("Main");
    }
}
