using Doozy.Runtime.UIManager.Containers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager //.UI
{
    [Header("--UI-----------------------------------")]
    [SerializeField] private UIView errorView;
    [SerializeField] private UIView loadingView;

    public void OnClickStart()
    {
      
    }

    public void OnClickExit()
    {
        //애플리케이션 종료
        Application.Quit();

        //만약 유니티 에디터가 아니라면?
#if !UNITY_EDITOR

        //모든 프로세스를 죽인다!
        System.Diagnostics.Process.GetCurrentProcess().Kill();
#else
        //유니티 에디터라면 플레이 모드 종료
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
