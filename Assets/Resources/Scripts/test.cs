using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class test : MonoBehaviour
{
    TextMeshProUGUI text;

    private string story;

    private void Start()
    {
        story = "정신나갈 것 같아 ";
        print(story.Length);
        text = GetComponent<TextMeshProUGUI>();
        Duplicate().Forget();
    }
    // Update is called once per frame
    void Update()
    {
    }

    private async UniTaskVoid Duplicate()
    {
        StringBuilder sb = new StringBuilder();
        while (true)
        {
            for (int i = 0; i < story.Length; i++)
            {
                sb.Append(story[i]);
                text.text = sb.ToString();
                await UniTask.DelayFrame(1);
            }
        }
    }
}
