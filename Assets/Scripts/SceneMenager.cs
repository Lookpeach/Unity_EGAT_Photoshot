using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMenager : MonoBehaviour
{
    public int numOfFrame = 0;
    public GameObject canvasStart, canvasFrame, canvasCountDown, canvasTakePhoto, canvasOutPut, canvasThank;
    public float timeLeft = 5.0f;
    public Text startText; // used for showing countdown from 3, 2, 1 
    public List<Sprite> imgCount = new List<Sprite>();
    public GameObject img;
    public bool flagCountdown = false;

    void Update()
    {
        
        if (flagCountdown == true)
        {
            CountDonw();
        }
        
    }

    public void StartButton()
    {
        canvasStart.SetActive(false);
        canvasFrame.SetActive(true);
        canvasCountDown.SetActive(false);
        canvasTakePhoto.SetActive(false);
        canvasOutPut.SetActive(false);
        canvasThank.SetActive(false);
    }
    public void SeletedFrame(int num)
    {
        if(num == 1) //frame 1
        {
            numOfFrame = 1;
        }
        else if(num == 2) //frame 2
        {
            numOfFrame = 2;
        }
        else if(num == 3) //frame 3
        {
            numOfFrame = 3;
        }
        else if(num == 4) //click ok
        {
            canvasStart.SetActive(false);
            canvasFrame.SetActive(false);
            canvasCountDown.SetActive(true);
            canvasTakePhoto.SetActive(false);
            canvasOutPut.SetActive(false);
            canvasThank.SetActive(false);
            flagCountdown = true;
        }
    }
    public void CountDonw()
    {
        timeLeft -= Time.deltaTime;
        Debug.Log("time" + timeLeft);
        startText.text = (timeLeft).ToString("0");
        if (startText.text == "3")
        {
            img.GetComponent<Image>().sprite = imgCount[0];
        }
        else if (startText.text == "2")
        {
            img.GetComponent<Image>().sprite = imgCount[1];
        }
        else if (startText.text == "1")
        {
            img.GetComponent<Image>().sprite = imgCount[2];
        }
        else if (startText.text == "0")
        {
            img.GetComponent<Image>().sprite = imgCount[3];
        }
        if (timeLeft < 0)
        {
            AsyncOperation async = SceneManager.LoadSceneAsync(1);
            flagCountdown = false;
        }   
    }
}
