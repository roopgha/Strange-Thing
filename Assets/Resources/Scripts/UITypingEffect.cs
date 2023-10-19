using Cysharp.Threading.Tasks;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UITypingEffect : MonoBehaviour
{
    TextMeshProUGUI text;
    GameManager.UserData userData;
    bool endStory;
    string[] story;

    private void Awake()
    {
        userData = new GameManager.UserData();

        text = GetComponent<TextMeshProUGUI>();
        print(userData.stageNumber);
        story = GameManager.localStory.story[userData.stageNumber].Split('\n');
    }

    private async void Start()
    {
        await TypingEffect();
    }

    private async UniTask TypingEffect()
    {
        int length = story.Length;
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
                await UniTask.WaitForSeconds(1);

                for(int i = story[num].Length - 1; i >= 0; i--)
                {
                    sb[i] = ' ';
                    text.text = sb.ToString();
                    await UniTask.WaitForSeconds(0.125f);
                }
                await UniTask.WaitForSeconds(1);
            }
            else
            {
                endStory = true;
            }
            num++;
        }
        await UniTask.Yield();
    }
}