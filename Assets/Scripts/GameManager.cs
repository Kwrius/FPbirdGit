using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject main;
    public GameObject tutorial;
    public GameObject score;
    public GameObject bird;
    public GameObject over;
    public GameObject black;

    public Text currentScoreText;
    public Text bestScoreText;
    public GameObject newImg;
    public Image medal;

    public AudioSource startAudioSource;
    public AudioClip startSound;
    public AudioSource getScoreAudioSource;
    public AudioClip getScoreSound;
    public AudioSource deathAudioSource;
    public AudioClip deathSound;
    public AudioSource overAudioSource;
    public AudioClip overSound;

    public List<Sprite> medals;

    public bool isGameReady = false;
    public bool isGameStarted = false;

    public Text scoreText;

    //public void Start()
    //{
    //    Tools.Ins.ShowUI(black);
    //    Invoke("HideBlackUI", 0.6f);
    //}

    public void PlayBtnClick()
    {
        startAudioSource.PlayOneShot(startSound);

        Tools.Ins.HideUI(main);
        Tools.Ins.ShowUI(tutorial);
        Tools.Ins.ShowUI(score);

        //main.GetComponent<UIManager>().HideUI();
        //tutorial.GetComponent<UIManager>().ShowUI();
        //score.GetComponent<UIManager>().ShowUI();

        bird.GetComponent<birdFlap>().ChangeState(true);
        if (!isGameReady) isGameReady = true;
    }

    private void Update()
    {
        if (!isGameReady) return;
        if (isGameStarted) return;  
        if (Input.GetMouseButtonDown(0))
        {
            Tools.Ins.HideUI(tutorial);
            //tutorial.GetComponent<UIManager>().HideUI();
            bird.GetComponent<birdFlap>().Flap();
            bird.GetComponent<birdFlap>().ChangeState(true, true);
            isGameStarted = true;
        }
    }

    public void GameOver()
    {
        if (!isGameStarted) return;

        deathAudioSource.PlayOneShot(deathSound);

        isGameReady = false;
        isGameStarted = false;

        GameObject.Find("PipeController").GetComponent<PipeController>().StopMove();
        GameObject.Find("bgs").GetComponent<bgController>().isMove = false;
        GameObject.Find("lands").GetComponent<landController>().isMove = false;

        //bird.GetComponent<birdFlap>().ChangeState(false);

        //Wait();
        Invoke("ShowOverUI", 0.6f);

        //Tools.Ins.ShowUI(over);
        //over.SetActive(true);

        int score = int.Parse(scoreText.text);

        // ÏÔÊ¾½±ÅÆ
        if (score >= 10)
        {
            medal.sprite = medals[0];
        }
        else if (score >= 20)
        {
            medal.sprite = medals[1];
        }
        else if (score >= 30)
        {
            medal.sprite = medals[2];
        }
        else
        {
            medal.gameObject.SetActive(false);
        }

        if (PlayerPrefs.GetInt("bestScore") < score)
        {
            PlayerPrefs.SetInt("bestScore", score);
            newImg.SetActive(true);
        }

        currentScoreText.text = score.ToString();
        bestScoreText.text = PlayerPrefs.GetInt("bestScore").ToString();
    }

    public void GetScore()
    {
        if (!isGameStarted) return;
        scoreText.text = (int.Parse(scoreText.text) + 1).ToString();
        getScoreAudioSource.PlayOneShot(getScoreSound);
    }

    public void ReStart()
    {
        startAudioSource.PlayOneShot(startSound);
        Tools.Ins.ShowUI(black);
        //System.Threading.Thread.Sleep(1000);
        //Tools.Ins.HideUI(black);
        Invoke("LoadSampleScene", 0.6f);
    }

    private void ShowOverUI()
    {
        overAudioSource.PlayOneShot(overSound);
        Tools.Ins.ShowUI(over);
    }

    private void HideBlackUI()
    {
        Tools.Ins.HideUI(black);
    }

    private void LoadSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
