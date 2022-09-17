using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class Sahne_Kup : MonoBehaviour
{
    
    public Sprite Sari, Kirmizi, Mavi, Yesil, Gri;
    public static SpriteRenderer ressam;
    public float zaman;
    public Text zmn,scr;
    public static int puan=0;
    public static int yedekpuan=0;
    public static int can=3;
    public Animation sarrim, kirmizim, mavim, yesilim, grim;
    

    void Start()
    {
        
        zaman = 6;
        //can = 3;
        ressam = GetComponent<SpriteRenderer>();
        
        StartCoroutine(SpawnObject());
        

    }

    // Update is called once per frame
    void Update()
    {
        zmn.text = "" + (int)zaman;
         if (zaman <= 0)
         {
             zaman = 6;
             zmn.text = "" + (int)zaman;
         }

        yedekpuan = puan;

         zaman -= Time.deltaTime;
         zmn.text = "" + (int)zaman;

       /* if (ressam.sprite == Sari)
        {
            sarrim.Play();
        }
        if (ressam.sprite == Kirmizi)
        {
            kirmizim.Play();
        }
        if (ressam.sprite == Mavi)
        {
            mavim.Play();
        }
        if (ressam.sprite == Yesil)
        {
            yesilim.Play();
        }
        if (ressam.sprite == Gri)
        {
            grim.Play();
        }*/

        

    }
    public IEnumerator SpawnObject()
    {
        /*int rastgele = Random.Range(1, 6);
        switch (rastgele)
        {
            case 1:
                ressam.sprite = Sari;
                break;
            case 2:
                ressam.sprite = Kirmizi;
                break;
            case 3:
                ressam.sprite = Mavi;
                break;
            case 4:
                ressam.sprite = Yesil;
                break;
            case 5:
                ressam.sprite = Gri;
                break;
        }*/

        while (Time.timeScale == 1)
        {


            int veko = Random.Range(1, 6);
            switch (veko)
            {
                case 1:
                    ressam.sprite = Sari;                    
                    break;
                case 2:
                    ressam.sprite = Kirmizi;                    
                    break;
                case 3:
                    ressam.sprite = Mavi;                    
                    break;
                case 4:
                    ressam.sprite = Yesil;                    
                    break;
                case 5:
                    ressam.sprite = Gri;                    
                    break;
            }

            /*if (ressam.sprite == Sari)
            {
                sarrim.Play();
            }
            if (ressam.sprite == Kirmizi)
            {
                kirmizim.Play();
            }
            if (ressam.sprite == Mavi)
            {
                mavim.Play();
            }
            if (ressam.sprite == Yesil)
            {
                yesilim.Play();
            }
            if (ressam.sprite == Gri)
            {
                grim.Play();
            }*/
            yield return new WaitForSeconds(6);



        }
    }


    
}
