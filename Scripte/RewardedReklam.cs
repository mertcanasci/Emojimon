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



    // Buradan sonraki fonksiyonlar, IUnityAdsListener'ýn geri bildirim fonksiyonlarýdýr.
    // Bu fonksiyonlar Unity Ads tarafýndan otomatik olarak çaðrýlýrlar.




    // placementId'ye sahip reklamýn gösterilmeye hazýr hale geldiðini söyler
    // Bu fonksiyon çaðrýldýktan sonra Advertisement.IsReady(placementID) true döndürürmeye baþlar
    public void OnUnityAdsReady(string placementId)
    {
        // Advertisement.IsReady(placementId);
    }

    // Bir reklamý sunucudan indirirken hata oluþmuþtur
    public void OnUnityAdsDidError(string message)
    {
        // Hata mesajýný konsola bastýr
        //Debug.LogError(message);
    }

    // placementId'ye sahip interstitial veya rewarded reklamýn, Advertisement.Show vasýtasýyla gösterilmeye baþladýðýný söyler
    public void OnUnityAdsDidStart(string placementId)
    {
        //Advertisement.Show(placementId);
    }

    // placementId'ye sahip interstitial veya rewarded reklamýn kapatýldýðýný söyler
    // Reklamýn sonuna kadar izlenip izlenmediðini kontrol etmek için showResult'tan faydalanýlýr
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Eðer bu geri bildirim rewarded reklam için çaðrýlmýþsa
        if (placementId == RewardedPlacementID)
        {
            if (showResult == ShowResult.Finished)
            {
                // Oyuncu reklamý sonuna kadar izlemiþtir: oyuncuyu ödüllendir

                //skor ayný kalsýn ve oyun sahnesi baþlasýn
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
                // Oyuncu reklamý geçmiþ, yani sonuna kadar izlememiþtir: oyuncuya ödül verme

                //oyuncuya geçme tuþu vermeyeceðiz
            }

            else if (showResult == ShowResult.Failed)
            {
                Time.timeScale = 0;

                SceneManager.LoadScene(2);
                // Bir sebepten ötürü rewarded reklam gösterilirken hata oluþmuþtur: oyuncuya ödül verme
                // ama mümkünse durumu izah eden bir mesaj gösterip tekrar reklamý izlemeyi denemesini söyle
            }
        }
    }


}

