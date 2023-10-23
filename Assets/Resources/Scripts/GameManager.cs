using Doozy.Runtime.UIManager.Containers;
using Palmmedia.ReportGenerator.Core.Reporting.History;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    Story storyData = new Story();
    UserData userData = new UserData();
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        userData.isSeeStory[0] = false;
        error = new Error();
        localStory = new Story();
        SetDirectory();
        SetUserData();

    }

    // Start is called before the first frame update
    private void Start()
    {
        SetStoryData();
    }

    // Update is called once per frame
   private void Update()
    {
        
    }

}
