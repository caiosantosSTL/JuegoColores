using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class iniciarG : MonoBehaviour {

    public GameObject UIRed;
    public GameObject UIareajogo;
    public GameObject UIareanivelo;
    //contador inicial
    public GameObject UIcontaj;
    public Text ContajT;
    public Text UIkolor;
    int counter = 5;

    bool config = false;



    // Use this for initialization
    void Start () {
        Time.timeScale = 0;
        print("esta pausada");
        UIareajogo.SetActive(false);
        config = false;


        

    }
	
	// Update is called once per frame
	void Update () {


    }

    public void iniciar()
    {
        Time.timeScale = 1;
        print("esta despausada");

        UIRed.SetActive(false);
        UIcontaj.SetActive(true);

        ContajT.text = "5";
        StartCoroutine(CountDownTimer());
        //UIareajogo.SetActive(true);
        if (config == false)
        {
            //objinkorekt.valcont = 10;
            //objinkorekt.counter = objinkorekt.valcont;
            //print("eee foi"+ objinkorekt.valcont);
        }
        else
        {
            print("ee config nos botoes");
        }
    }

    public void butono_nivelo()
    {
        Time.timeScale = 0;
        UIareanivelo.SetActive(true);
        UIRed.SetActive(false);

    }

    // butono regresar pantalla inicial en area level
    public void butono_regres()
    {
        Time.timeScale = 0;
        UIRed.SetActive(true);
        UIareanivelo.SetActive(false);

    }

    // area butono de tiempos

    public void butono_10s()
    {

        //RelojRegresiv.valconta = 10;
            config = true;

        print("ee config 10");

        
    }

    public void butono_5s()
    {

        //RelojRegresiv.valconta = 5;
            config = true;
            print("ee config 5");

        
    }

    public void butono_3s()
    {

        //RelojRegresiv.valconta = 3;
            config = true;
            print("ee config 3");

    }

    //contador inicial de juego
    IEnumerator CountDownTimer()
    {
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
            print("inicial "+counter);
            ContajT.text = counter.ToString();
            if (counter == 0)
            {
                UIcontaj.SetActive(false);
                UIareajogo.SetActive(true);

                OBJnekorekt.desvenko = 0;
                OBJkorekt1.venko = 0;

                break;
            }
            else
            {
                OBJnekorekt.desvenko = 1;
                OBJkorekt1.venko = 1;
            }
        }
    }
}
