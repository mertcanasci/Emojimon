using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using itfriedl.Highscores;

public class AnaMenuManager : MonoBehaviour
{
    public GameObject _AnaMenuPanel;
    public GameObject _RankingPanel;
    public HighscoreManager hm;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RankingAc()
    {
        _AnaMenuPanel.SetActive(false);
        _RankingPanel.SetActive(true);

        hm.ShowScores(hm.GetSavedScores(0), Sahne_Kup.puan, "Name");
        //hm.ShowScores(hm.GetSavedScores(0), Kazandik.puandegeri, "Name");


    }
    public void RankingKapat()
    {
        _RankingPanel.SetActive(false);
        _AnaMenuPanel.SetActive(true);
    }

    public void StartButton()
    {
       SceneManager.LoadScene(1);
        Time.timeScale = 1;
        
        Sahne_Kup.can = 3;
    }
    public void QuitButton()
    {
        Application.Quit();
    }



}
