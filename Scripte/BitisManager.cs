using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using itfriedl.Highscores;
using TMPro;

public class BitisManager : MonoBehaviour
{
    public GameObject _ReklamPanel;
    public GameObject _BitisPanel;
    public HighscoreManager hm;
    public TMP_InputField name;
    



    void Start()
    {
        if (RewardedReklam.reklamcani==0)
        {
            _ReklamPanel.SetActive(false);
            _BitisPanel.SetActive(true);
        }


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   


    public void ReklamGecButonu()
    {
        _ReklamPanel.SetActive(false);
        _BitisPanel.SetActive(true);

    }
    public void SubmitButonu()
    {
        //isim ve puaný veritabanýna ekle
        
        hm.InsertScore(name.text, Sahne_Kup.puan,0,0);
        SceneManager.LoadScene(0);




    }


}
