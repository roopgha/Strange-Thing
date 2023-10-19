using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public partial class GameManager //.Save
{
    Story storyData = new Story();
    //만약 스토리 저장 파일이 삭제 되었거나 변형 되었을때를 위한 백업 본
    private void SaveStory()
    {
        storyData.story[0] = "나는 흔하디 흔한 기자다\n 그리고 지금은 미끼를 물어 마을에 갔지\n 그렇게 내 뚝배기는 조져졌다.\n";
        storyData.story[1] = "hello";
        storyData.story[2] = "hello";
         
        string json = JsonUtility.ToJson(storyData);
        File.WriteAllText(storyPath, json);
    }
}
