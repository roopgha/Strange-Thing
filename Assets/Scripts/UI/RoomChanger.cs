using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomChanger : MonoBehaviour
{
    private int roomNumber;

    public GameObject[] Rooms;
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeSpeed=1;
    [SerializeField] private float fadeChangeSpeed = 1;

    private Color fade;

    private void Awake()
    {
        fade = fadeImage.color;
        Rooms = GameObject.FindGameObjectsWithTag("Room");
        for(int i=0; i<Rooms.Length; i++){
            if(i != roomNumber)
            {
                Rooms[i].SetActive(false);
            }
        }
    }

    

    public void RoomNumber(int next){
        StartCoroutine(FadeInOut(next));
    }

    private IEnumerator FadeInOut(int next){
        StartCoroutine(FadeIn());
        yield return new WaitForSeconds(1 / fadeChangeSpeed);
        ChangeRoom(next);
        StartCoroutine(FadeOut());
    }

    private void ChangeRoom(int next){
        Rooms[roomNumber].SetActive(false);
        roomNumber+=next;
        if(roomNumber>Rooms.Length){
            roomNumber=0;
        }
        Rooms[roomNumber].SetActive(true);
    }

    private IEnumerator FadeIn()
    {
        fadeImage.gameObject.SetActive(true);
        float i = 0;
        while(i < 1){
            i+=Time.deltaTime*fadeSpeed;
            fade.a = i;
            fadeImage.color = fade;
            yield return null;
        }
    }

    private IEnumerator FadeOut()
    {

        float i = 1;
        while(i > 0){
            i-=Time.deltaTime*fadeSpeed;
            fade.a = i;
            fadeImage.color = fade;
            yield return null;
        }
        fadeImage.gameObject.SetActive(false);
    }
}
