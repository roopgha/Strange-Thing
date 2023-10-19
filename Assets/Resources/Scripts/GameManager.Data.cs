using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public partial class GameManager //.Data
{
    [System.Serializable]
    public class UserData
    {
        public int key;
        public int stageNumber;
        public int roomNumber;

        public bool[] isSeeStory = new bool[3];
        public bool[] isStageClear = new bool[3];
    }

    [System.Serializable]

    public class Story
    {
        public string[] story = new string[3];
    }

    private readonly string savePath = Application.dataPath + "/Resources/Save/Save.json";
    private readonly string storyPath = Application.dataPath + "/Resources/Save/Stroy.json";

    private bool[] resetBool = new bool[3] { false, false, false };

    private void SetDirectory()
    {
        if (!Directory.Exists(Application.dataPath + "/Resources/Save/"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Resources/Save/");
        }
        if (!File.Exists(savePath))
        {
            Stream stream = File.Create(savePath);
            stream.Close();
        }
        if (!File.Exists(storyPath))
        {
            Stream stream = File.Create(storyPath);
            stream.Close();
        }

    }

    private void SetUserData()
    {
        string saveJson = File.ReadAllText(savePath);

        UserData user = new UserData();
        UserData userData = JsonUtility.FromJson<UserData>(saveJson);

        if (userData != null)
        {
            user.isSeeStory = userData.isSeeStory;
            user.isStageClear = userData.isStageClear;
            user.roomNumber = userData.roomNumber;
            user.stageNumber = userData.stageNumber;
            user.key = userData.key;
        }
        else
        {
            user.isSeeStory = resetBool;
            user.isStageClear = resetBool;

            user.stageNumber = 0;
            user.roomNumber = 0;
            user.key = 0;
        }
    }

    private void SetStoryData()
    {
        string storyJson = File.ReadAllText(storyPath);

        Story storyData = JsonUtility.FromJson<Story>(storyJson);
        print(storyData.story[0]);
        if (storyData != null)
        {
            localStory.story = storyData.story;
        }
        else
        {
            ErrorMessage(error.storyError);
            SaveStory();
        }
    }
}
