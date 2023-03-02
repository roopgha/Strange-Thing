using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomChanger : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeSpeed=1;
    private Color fade;

    private void Awake()
    {
        fade = fadeImage.color;
    }

    public void  FadeInFadeOut(){
        StartCoroutine("FadeInOut");
    }

    private IEnumerator FadeInOut(){
        StartCoroutine(FadeIn());
        yield return new WaitForSeconds(1 / fadeSpeed);
        StartCoroutine(FadeOut());
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
