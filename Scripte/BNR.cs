using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BNR : MonoBehaviour, IUnityAdsListener
{
    public string GameID = "4113645";
    public string BannerPlacementID = "albanner";
    public bool testModu = true;

    private bool bannerGosterilecek = true;

    void Start()
    {
        Advertisement.AddListener(this);
        // Unity Ads'i kullanýma hazýr hale getir
        Advertisement.Initialize(GameID, testModu);

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        BannerGoster();
    }

    void Update()
    {
        if (bannerGosterilecek)
        {
            // Banner reklam gösterilmeye hazýr mý diye kontrol et
            if (Advertisement.IsReady(BannerPlacementID))
            {
                // Banner reklam gösterilmeye hazýr, o halde reklamý göster!
                Advertisement.Banner.Show(BannerPlacementID);

                // Banner'ý gösterdik, artýk bu if koþulunu kontrol etmemize gerek yok
                bannerGosterilecek = false;
            }
        }
    }

    // Ekranda test amaçlý "Banner Göster" ve "Banner Gizle" butonlarý göstermeye yarar, bu fonksiyonu silerseniz butonlar yok olur
    /* void OnGUI()
     {
         if (GUI.Button(new Rect(Screen.width / 2 - 300, Screen.height - 300, 300, 300), "Banner Göster"))
             BannerGoster();

         if (GUI.Button(new Rect(Screen.width / 2, Screen.height - 300, 300, 300), "Banner Gizle"))
             BannerGizle();
     }*/

    public void BannerGoster()
    {
        bannerGosterilecek = true;
    }

    public void BannerGizle()
    {
        bannerGosterilecek = false;

        // Banner'ý gizle
        Advertisement.Banner.Hide();
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
