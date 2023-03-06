using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITextTypingEffect : MonoBehaviour
{
    [SerializeField] private GameObject textWindow;
    [SerializeField] private TextMeshProUGUI storyText;
    List<string> story = new List<string>();

    int printState = 0;

    int storyCount = 0;

    void Start(){
        string[] filenames = {"story1.txt"};

        foreach(string filename in filenames)
        {
            AddStroyText(filename,story);
        }

        if(!GameManager.isUserSeeStory)
        {
            textWindow.SetActive(true);
            print("activate textWindow");
        }
        // foreach(string text in story)
        // {
        //     PlayText(text);
        // }
    }

    void Update()
    {
        if(GameManager.isUserSeeStory == false)
        {
            if(storyCount >= story.Count)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    textWindow.SetActive(false);
                    GameManager.isUserSeeStory = true;
                }

                return;
            }

            if(printState == 0)
            {
                StartCoroutine(PlayText(story[storyCount],0.5f,1));
                printState = 1;
            }

            else if(printState == 2)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    storyCount++;
                    printState = 0;
                }
            }

        }
    }


    void AddStroyText(string filename, List<string> story)
    {
        string path = System.IO.Path.Combine(Application.streamingAssetsPath, filename);
        System.IO.FileStream fileStream = new System.IO.FileStream(path,System.IO.FileMode.Open);
        System.IO.StreamReader streamReader = new System.IO.StreamReader(fileStream);
        
        string line = null;
        while((line = streamReader.ReadLine()) != null)
        {
            story.Add(line);
        }
    }

    IEnumerator PlayText(string story, float printSkipDelay, float afterPrintSkipDelay)
    {
        storyText.text = "";

        float countTime = 0;
        float countSkipTIme = 0;
        foreach(char c in story){
            storyText.text += c;

            while(countTime<=0.125f)
            {
                countTime+=Time.deltaTime;
                countSkipTIme+=Time.deltaTime;
                if(countSkipTIme >= printSkipDelay)
                {
                    if(Input.GetMouseButtonDown(0))
                    {
                        goto BREAK;
                    }
                }
                yield return null;
            }
            countTime = 0;
        }
        BREAK:

        storyText.text = story;
        
        yield return new WaitForSeconds(afterPrintSkipDelay);

        printState = 2;
    }
}
