using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Gecisreklam : MonoBehaviour, IUnityAdsListener
{
    public string GameID = "GAME ID";
    public string InterstitialPlacementID = "video";
    public bool testModu = true;
    private int rand,rand1;
    private bool interstitialGosterilecek = false;

    void Start()
    {
        Advertisement.AddListener(this);
        // Unity Ads'i kullan�ma haz�r hale getir
        Advertisement.Initialize(GameID, testModu);
        rand = Random.Range(9, 14)*10;
        rand1 = Random.Range(25, 30)*10;
    }

    void Update()
    {
        
            

            if (Sahne_Kup.puan == rand || Sahne_Kup.puan == rand1)
            {
                if (interstitialGosterilecek)
                {
                    // Interstitial reklam g�sterilmeye haz�r m� diye kontrol et
                    if (Advertisement.IsReady(InterstitialPlacementID))
                    {
                        // Interstitial reklam g�sterilmeye haz�r, o halde reklam� g�ster!
                        Advertisement.Show(InterstitialPlacementID);

                        // Interstitial'� g�sterdik, art�k bu if ko�ulunu kontrol etmemize gerek yok
                        interstitialGosterilecek = false;
                    }
                }
            }
        }
    
    // Ekranda test ama�l� "Interstitial G�ster" butonu g�stermeye yarar, bu fonksiyonu silerseniz buton yok olur
    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 300, 0, 300, 300), "Interstitial G�ster"))
            InterstitialGoster();
    }

    public void InterstitialGoster()
    {
        interstitialGosterilecek = true;
    }

    public void OnUnityAdsReady(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        throw new System.NotImplementedException();
    }
}