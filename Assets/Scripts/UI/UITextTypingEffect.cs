using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class UITextTypingEffect : MonoBehaviour
{   
    [SerializeField] private GameObject[] storyTextWindows;
    [SerializeField] private TextMeshProUGUI[] storyTexts;
    [SerializeField] private GameObject interactionTextWindow;
    [SerializeField] private TextMeshProUGUI interactionText;

    List<string> story = new List<string>();
    List<string> interaction = new List<string>(); 
    int printState = 0;

    int storyCount = 0;

    void Awake()
    {
        UITextTypingEffect[] textTypingEffects = FindObjectsOfType<UITextTypingEffect>();
        if(textTypingEffects.Length == 1)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        AddStroyText("story" + GameManager.stageNumber + ".txt", story);
        AddStroyText("interaction.txt", interaction);

        if(!GameManager.isUserSeeStory)
        {
            storyTextWindows[GameManager.stageNumber].SetActive(true);
            print("activate textWindow");
        }
        // foreach(string text in story)
        // {
        //     PlayText(text);
        // }
    }

    protected virtual void Update()
    {
        //print(printState);
        if(GameManager.isUserSeeStory)
        {
            if(Input.GetMouseButtonDown(0))
            {
                storyTextWindows[GameManager.stageNumber].SetActive(false);
            }
        }
        if(GameManager.isOnClickDoor)
        {
            interactionTextWindow.SetActive(true);
            if(GameManager.isUserHaveKey)
            {
                GameManager.isUserHaveKey = false;
                PlayTypingEffect(interaction[1], interactionText, interactionTextWindow);
            }
            else
            {
                PlayTypingEffect(interaction[0], interactionText, interactionTextWindow);
            }
        }
        else if(GameManager.isOnClickKey)
        {
            GameManager.isUserHaveKey = true;
            interactionTextWindow.SetActive(true);
            PlayTypingEffect(interaction[2], interactionText, interactionTextWindow);
        }
        else
        {
            PlayTypingEffect(story, storyTexts[GameManager.stageNumber]);
        }
    }

    public void PlayTypingEffect(string text, TextMeshProUGUI textObject, GameObject interactionTextWindow)
    {
        
        if(printState == 0)
        {
            print("input!!");
            StartCoroutine(PlayText(textObject,text,0.5f,1));
            printState = 1;
        }
        else if(printState == -1)
        {
            interactionTextWindow.SetActive(false);
            printState = 0;
            GameManager.isOnClickDoor = false;
            GameManager.isOnClickKey = false;
        }
        else if(printState == 2)
        {
            if(Input.GetMouseButtonDown(0))
            {
                printState = -1;
            }
        }
        
    }

    public void PlayTypingEffect(List<string> text, TextMeshProUGUI textObject)
    {
        if(GameManager.isOnClickDoor) return;

        if(storyCount >= text.Count)
        {    
            //GameManager.isUserSeeStory = true;
            storyTextWindows[GameManager.stageNumber].SetActive(false);
            printState = 0;
            return;
        }

        if(printState == 0)
        {
            StartCoroutine(PlayText(textObject,text[storyCount],0.5f,1));
            printState = 1;
        }

        else if(printState == 2)
        {
            if(Input.GetMouseButtonDown(0))
            {
                //print("!");
                storyCount++;
                printState = 0;
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

    
    IEnumerator PlayText(TextMeshProUGUI textObject, string story, float printSkipDelay, float afterPrintSkipDelay)
    {
        textObject.text = "";

        float countTime = 0;
        float countSkipTIme = 0;
        foreach(char c in story){
            textObject.text += c;

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

        textObject.text = story;
        
        yield return new WaitForSeconds(afterPrintSkipDelay);

        printState = 2;
    }
}
