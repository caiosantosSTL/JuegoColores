using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarCena : MonoBehaviour { // cambiar escena

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.V))
        {

            SceneManager.LoadScene("CenadeReg");//vamos para pantalla de login en la escena de registro




        }

    }
}
