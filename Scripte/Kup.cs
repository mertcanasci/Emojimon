using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;



public class Kup : MonoBehaviour
{
    public Sprite Sari, Kirmizi, Mavi, Yesil, Gri, Siyah;
    public SpriteRenderer ressam,olu;
    public TextMeshProUGUI Score, canim;
    


    void Start()
    {


        ressam = GetComponent<SpriteRenderer>();
        StartCoroutine(SpawnObject());

        Score.text = "Point: " + Sahne_Kup.puan;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (ressam.sprite == Sahne_Kup.ressam.sprite)
        {
            ressam.sprite = olu.sprite;

            Sahne_Kup.puan += 10;
            Score.text = "Point: " + Sahne_Kup.puan;

        }
        else if (ressam.sprite == Siyah)
        {
            Sahne_Kup.puan += 0;

        }
        else
        {
            //Sahne_Kup.puan -= 10;
            ressam.sprite = olu.sprite;
            Sahne_Kup.can--;
            canim.text = "" + Sahne_Kup.can;

            if (Sahne_Kup.can == 0)
            {
                Time.timeScale = 0;
                SceneManager.LoadScene(2);
            }
        }
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


            int veko = Random.Range(1, 7);
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
                case 6:
                    ressam.sprite = Siyah;
                    break;
            }

            
            if(Sahne_Kup.puan>100 && Sahne_Kup.puan <= 150)
            {
                yield return new WaitForSeconds(0.8f);
            }
            if (Sahne_Kup.puan > 150)
            {
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
