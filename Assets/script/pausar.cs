using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausar : MonoBehaviour {

    public GameObject telapausa;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.P))// codigo para pausar el juego
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                print("Pausad");
                telapausa.SetActive(true);// activar pantalla de pausa
            }
            else
            {
                Time.timeScale = 1;
                print("DesPausad");
                telapausa.SetActive(false);// desactivar pantalla de pausa
            }
        }

        if (Input.GetKeyDown(KeyCode.G))// hacer el restart para la pantalla inicial
        {
            //reset o restart juego
            SceneManager.LoadScene("SampleScene");// escena de juego

            //objinkorekt.counter = 10; // reset o tempo

            RelojRegresiv.contador = RelojRegresiv.valconta + 5;
            OBJnekorekt.desvenko = 0; // reset desativacao de inkorekt
            OBJkorekt1.venko = 0; // reset desativacao de korekt
            /* ideia crir uma cena especifica para registro
                e outra cena para o jogo, pois quando apertar G, nao vamos reiciciar para a tela de registro    
         */
            

        }





		
	}
}
