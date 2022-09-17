using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class RewardedReklam : MonoBehaviour, IUnityAdsListener
{
    public string GameID = "4081699";
    public string RewardedPlacementID = "Rewarded_Android";
    public bool testModu = true;
    public static int reklamcani = 1;



    private bool rewardedReklamGosterilecek = false;

    void Start()
    {
        //Advertisement.AddListener(this);
        Advertisement.AddListener(this);
        Advertisement.Initialize(GameID, testModu);

    }

    // Update is called once per frame

    public void showAd(string p)
    {
        Advertisement.Show(p);

    }
    public void RewardedReklamGoster()
    {
        rewardedReklamGosterilecek = true;
    }



    // Buradan sonraki fonksiyonlar, IUnityAdsListener'�n geri bildirim fonksiyonlar�d�r.
    // Bu fonksiyonlar Unity Ads taraf�ndan otomatik olarak �a�r�l�rlar.




    // placementId'ye sahip reklam�n g�sterilmeye haz�r hale geldi�ini s�yler
    // Bu fonksiyon �a�r�ld�ktan sonra Advertisement.IsReady(placementID) true d�nd�r�rmeye ba�lar
    public void OnUnityAdsReady(string placementId)
    {
        // Advertisement.IsReady(placementId);
    }

    // Bir reklam� sunucudan indirirken hata olu�mu�tur
    public void OnUnityAdsDidError(string message)
    {
        // Hata mesaj�n� konsola bast�r
        //Debug.LogError(message);
    }

    // placementId'ye sahip interstitial veya rewarded reklam�n, Advertisement.Show vas�tas�yla g�sterilmeye ba�lad���n� s�yler
    public void OnUnityAdsDidStart(string placementId)
    {
        //Advertisement.Show(placementId);
    }

    // placementId'ye sahip interstitial veya rewarded reklam�n kapat�ld���n� s�yler
    // Reklam�n sonuna kadar izlenip izlenmedi�ini kontrol etmek i�in showResult'tan faydalan�l�r
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // E�er bu geri bildirim rewarded reklam i�in �a�r�lm��sa
        if (placementId == RewardedPlacementID)
        {
            if (showResult == ShowResult.Finished)
            {
                // Oyuncu reklam� sonuna kadar izlemi�tir: oyuncuyu �d�llendir

                //skor ayn� kals�n ve oyun sahnesi ba�las�n
                Sahne_Kup.puan = Sahne_Kup.yedekpuan;
                SceneManager.LoadScene(1);
                Time.timeScale = 1;
                Sahne_Kup.can = 3;
                
                reklamcani--;


            }
            else if (showResult == ShowResult.Skipped)
            {
                Time.timeScale = 0;

                SceneManager.LoadScene(2);
                // Oyuncu reklam� ge�mi�, yani sonuna kadar izlememi�tir: oyuncuya �d�l verme

                //oyuncuya ge�me tu�u vermeyece�iz
            }

            else if (showResult == ShowResult.Failed)
            {
                Time.timeScale = 0;

                SceneManager.LoadScene(2);
                // Bir sebepten �t�r� rewarded reklam g�sterilirken hata olu�mu�tur: oyuncuya �d�l verme
                // ama m�mk�nse durumu izah eden bir mesaj g�sterip tekrar reklam� izlemeyi denemesini s�yle
            }
        }
    }


}

