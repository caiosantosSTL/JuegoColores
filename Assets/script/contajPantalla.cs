using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class contajPantalla : MonoBehaviour {

    //Contaje inicial de 5 segs

    public Text ContajT;
    static public GameObject UIcontaj;

    int counter = 5;

	// Use this for initialization
	void Start () {
        StartCoroutine(CountDownTimer());// iniciar contaje 

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator CountDownTimer() // metodo de los segundos 
    {
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
            print(counter);
            ContajT.text = counter.ToString();
            if (counter == 0)
            {
                UIcontaj.SetActive(false);
                //iniciarG.UIareajogo.SetActive(true);
                //break;
            }
        }
    }
}
