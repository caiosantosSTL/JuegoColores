using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelojRegresiv : MonoBehaviour {

    public GameObject UIfinjogo;

    public static int valconta = 30;
    public static int contador = valconta + 5;

    public Text ttempo;

	// Use this for initialization
	void Start () {

        ttempo.text = "" + contador;

        StartCoroutine(CountDownTimer());

        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    // Co rotina para disminuir valor de reloj
    IEnumerator CountDownTimer()
    {

        while (contador > 0)
        {
            yield return new WaitForSeconds(1);
            contador--;
            ttempo.text = contador.ToString();
            if (contador == 0)
            {
                //ttemp.text = "Stop";
                UIfinjogo.SetActive(true);

                 break;
            }
        }


    }//end contador
}
