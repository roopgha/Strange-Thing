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
        public string storyError = "스토리를 불러오는데 문제가 발생했습니다.\n 게임을 종료합니다.";
    }

    private void ErrorMessage(string errorMessage)
    {
        TextMeshProUGUI text = errorView.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        text.text = errorMessage;

        errorView.Show();
    }
}
