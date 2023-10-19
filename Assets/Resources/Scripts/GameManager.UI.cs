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
        //���ø����̼� ����
        Application.Quit();

        //���� ����Ƽ �����Ͱ� �ƴ϶��?
#if !UNITY_EDITOR

        //��� ���μ����� ���δ�!
        System.Diagnostics.Process.GetCurrentProcess().Kill();
#else
        //����Ƽ �����Ͷ�� �÷��� ��� ����
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
