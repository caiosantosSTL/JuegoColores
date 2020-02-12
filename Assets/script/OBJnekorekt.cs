using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OBJnekorekt : MonoBehaviour {

    public GameObject capsula2;

    int incorrect;
    public Text tincorrect;
    public static int STGincorret;
    public Text tcolor;
    int vrandd; //valor random
    int distanc = 2; //distancia de posicion del objeto
    int distanc2 = 3;
    int subir = 2; // distancia para subir los objetos
    //int valcont;// var para ser usada nos botoes de escolher o tempo

    public static int desvenko = 0; //perdio 0 como falso
   //int counter = valcont;
    //public Text ttemp;



    //Array de  colores
    private string[] colori = new string[4] { "Azul", "Rojo", "Verde", "Amarillo" };

    //color texto invers
    Color[] randcolor = {new Color(1, 0, 0, 1), new Color(1, 0.92f, 0.016f, 1),
        new Color(0, 0, 1, 1),
        new Color(0, 1, 0, 1) };

    //Array color del texto
    Color[] colorobjText = {new Color(0, 0, 1, 1),
        new Color(1, 0, 0, 1),new Color(0, 1, 0, 1),
        new Color(1, 0.92f, 0.016f, 1)

         };

    //Array color objeto
    Color[] colorobjColor = {new Color(1, 0, 0, 1), new Color(1, 0.92f, 0.016f, 1),
        new Color(0, 0, 1, 1),
        new Color(0, 1, 0, 1) };

    //variable random para las posiciones
    int val = 1;

    // Use this for initialization
    void Start () {

        incorrect = 0;
        tincorrect.text = "Incorrecto =  " + incorrect;



    }

    // Update is called once per frame
    void Update () {
		
	}


    private void OnTriggerEnter(Collider other)
    {

        
        if (desvenko == 0) // si perdio como falso, ejecutamos codigo abajo
        {


            // posicion 
            if (other.gameObject.tag == "jogador")
            {
                print("Triger ativado azul");
                print("poppo " + val);
                if (val == 1)
                {
                    this.GetComponent<Transform>().transform.localPosition =
                            new Vector3(-0.3559999f, 0.25f, 0.3641536f * distanc);
                    capsula2.GetComponent<Transform>().transform.localPosition =
                            new Vector3(-0.3559999f, 0.25f, -0.5148463f * distanc);


                    //definimos el valor de val random, para saber si será 0 o 1 en un rango de 0 -- 2, 2 es ignorado
                    System.Random r = new System.Random();
                    val = r.Next(0, 2);

                    //val = 0;
                }
                else if (val == 0)
                {
                    capsula2.GetComponent<Transform>().transform.localPosition =
                            new Vector3(-0.3559999f, 0.25f * subir, 0.3641536f * distanc);
                    this.GetComponent<Transform>().transform.localPosition =
                            new Vector3(-0.3559999f, 0.25f * subir, -0.5148463f * distanc);

                    System.Random r = new System.Random();
                    val = r.Next(0, 2);
                    //val = 1;
                }


                // Random textos
                System.Random r2 = new System.Random();
                vrandd = r2.Next(0, 4);
                print(" num rand " + vrandd);
                print("Tal valor elegido de color === " + colori[vrandd]);
                tcolor.text = "== " + colori[vrandd] + " ==";
                print("valor cor texto errad " + vrandd);

                // pontuacion
                incorrect += 1;
                tincorrect.text = "Incorrecto =  " + incorrect;
                STGincorret = incorrect;

                /*if (incorrect >= 5)
                {
                    tincorrect.text = "Perdió!";
                    desvenko = 1;
                    print("valox " + desvenko);
                }*/

                // Random colores del texto
                tcolor.color = randcolor[vrandd];
                print("ne korekt e korekt" + vrandd);

                // color objeto igual valor texto
                this.GetComponent<Renderer>().material.color = colorobjText[vrandd];
                // color obj correcto
                capsula2.GetComponent<Renderer>().material.color = colorobjColor[vrandd];


            }

        }
        else if (desvenko == 1) //si perdio como true, executamos codigo abajo
        {
            capsula2.GetComponent<Collider>().enabled = false;// obj correcto tiene su colider desactivado

        }



    }

    private void OnTriggerExit(Collider other)// si no mas tocamos el objeto
    {

        if (desvenko == 0)// si perdio como false
        {
            //desactivamos objetos render
            this.GetComponent<Renderer>().enabled = false;
            capsula2.GetComponent<Renderer>().enabled = false;

            //desactivamos objetos colider
            this.GetComponent<Collider>().enabled = false;
            capsula2.GetComponent<Collider>().enabled = false;

            print("desativado");
            StartCoroutine(atraso_ativar_colider()); //

        }

    }

    IEnumerator atraso_ativar_colider()// tiempo para reactivar render y colider de los objetos
    {
        yield return new WaitForSeconds(3);
        this.GetComponent<Collider>().enabled = true;
        capsula2.GetComponent<Collider>().enabled = true;

        this.GetComponent<Renderer>().enabled = true;
        capsula2.GetComponent<Renderer>().enabled = true;

        RelojRegresiv.contador += 4; // ponemos + 4 en el reloj por los segundos que los objetos quedaran inactivos

        print("ativado");
        Debug.Log("Acabou");
    }
}
