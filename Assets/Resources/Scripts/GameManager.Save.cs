using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public partial class GameManager //.Save
{
    Story storyData = new Story();
    //���� ���丮 ���� ������ ���� �Ǿ��ų� ���� �Ǿ������� ���� ��� ��
    private void SaveStory()
    {
        storyData.story[0] = "���� ���ϵ� ���� ���ڴ�\n �׸��� ������ �̳��� ���� ������ ����\n �׷��� �� �ҹ��� ��������.\n";
        storyData.story[1] = "hello";
        storyData.story[2] = "hello";
         
        string json = JsonUtility.ToJson(storyData);
        File.WriteAllText(storyPath, json);
    }
}
