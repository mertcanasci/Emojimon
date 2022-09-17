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
        // Unity Ads'i kullanýma hazýr hale getir
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
                    // Interstitial reklam gösterilmeye hazýr mý diye kontrol et
                    if (Advertisement.IsReady(InterstitialPlacementID))
                    {
                        // Interstitial reklam gösterilmeye hazýr, o halde reklamý göster!
                        Advertisement.Show(InterstitialPlacementID);

                        // Interstitial'ý gösterdik, artýk bu if koþulunu kontrol etmemize gerek yok
                        interstitialGosterilecek = false;
                    }
                }
            }
        }
    
    // Ekranda test amaçlý "Interstitial Göster" butonu göstermeye yarar, bu fonksiyonu silerseniz buton yok olur
    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 300, 0, 300, 300), "Interstitial Göster"))
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