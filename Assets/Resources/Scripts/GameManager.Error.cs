using Doozy.Editor.UIManager.Windows;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public partial class GameManager //.Error
{
    private Error error;

    public class Error
    {
        public string storyError = "���丮�� �ҷ����µ� ������ �߻��߽��ϴ�.\n ������ �����մϴ�.";
    }

    private void ErrorMessage(string errorMessage)
    {
        TextMeshProUGUI text = errorView.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        text.text = errorMessage;

        errorView.Show();
    }
}
