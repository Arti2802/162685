using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ScoreManager : MonoBehaviour
{
    public Text points1Text;
    public Text points2Text;
    public int points1 = 0;
    public int points2 = 0;
    public Text setsText;
    public int sets1 = 0;
    public int sets2 = 0;
    public Text info;
    public Text result;
    public AudioSource source;
    public AudioClip clip;

    void Start()
    {
        points1Text.text = points1.ToString();
        points2Text.text = points2.ToString();
        setsText.text = sets1.ToString() + ":" + sets2.ToString();
    }
    public void Change()
    {
        points1Text.text = points1.ToString();
        points2Text.text = points2.ToString();
        source.PlayOneShot(clip);
        Debug.Log(points1 + " : " + points2);
        if ((points1 >= 5 || points2 >= 5) && Mathf.Abs(points1 - points2) >= 2)
        {
            StartCoroutine(Delay(ChangeSets));
        }
    }
    IEnumerator Delay(Action function)
    {
        yield return new WaitForSeconds(1.5f);
        function.Invoke();
    }
    void ChangeSets()
    {
        source.PlayOneShot(clip);
        Debug.Log("Koniec seta!");
        info.text = "Koniec seta!";
        source.PlayOneShot(clip);
        if (points1 > points2)
        {
            sets1++;
        }
        else
        {
            sets2++;
        }
        points1 = 0;
        points2 = 0;
        points1Text.text = points1.ToString();
        points2Text.text = points2.ToString();
        setsText.text = sets1.ToString() + ":" + sets2.ToString();
        if (sets1 == 2 || sets2 == 2)
        {
            source.PlayOneShot(clip);
            info.text = "Koniec gry";
            StartCoroutine(Delay(End));
        }
    }
    void End()
    {
        result.text = setsText.text;
        SceneManager.LoadScene(3);
    }
}
