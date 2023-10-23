using Cysharp.Threading.Tasks;
using NUnit.Framework.Constraints;
using System;
using System.Text;
using System.Threading;
using TMPro;
using UnityEngine;

public class UITypingEffect : MonoBehaviour
{
    GameObject gameCanvas;

    TextMeshProUGUI text;
    
    GameManager.UserData userData;

    GameObject storyWindow;

    bool endStory;

    string[] story;

    private void Awake()
    {
        gameCanvas = GameObject.Find("GameCanvas");

        gameCanvas.SetActive(false);

        userData = new GameManager.UserData();

        storyWindow = GameObject.Find(transform.parent.name);

        text = GetComponent<TextMeshProUGUI>();

        story = GameManager.localStory.story[userData.stageNumber].Split('\n');
    }

    private async void Start()
    {
        if (!userData.isSeeStory[userData.stageNumber])
        {
            await TypingEffect(story);

            gameCanvas.SetActive(true);

            userData.isSeeStory[userData.stageNumber] = true;

            storyWindow.SetActive(false);
        }
    }

    private async UniTask TypingEffect(string[] strings)
    {
        int length = strings.Length;
        var sb = new StringBuilder();
        int num = 0;
        endStory = false;
        while(endStory != true)
        {
            if (num < length)
            {
                for (int i = 0; i < story[num].Length; i++)
                {
                    sb.Append(" ");
                    sb[i] = story[num][i];
                    text.text = sb.ToString();
                    await UniTask.WaitForSeconds(0.15f);
                }

                for(int i = story[num].Length - 1; i >= 0; i--)
                {
                    sb[i] = ' ';
                    text.text = sb.ToString();
                    await UniTask.WaitForSeconds(0.05f);
                }
            }
            else
            {
                endStory = true;
            }
            num++;
        }
        await UniTask.Yield();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void UnPause()
    {
        Time.timeScale = 1f;
    }
}