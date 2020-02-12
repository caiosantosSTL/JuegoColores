using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class objinkorekt : MonoBehaviour {
    public GameObject capsula2;

    int incorrect;
    public Text tincorrect;
    public Text tcolor;
    int vrandd;
    int distanc = 2;
    int distanc2 = 3;
    int subir = 2;
    public static int valcont ;// var para ser usada nos botoes de escolher o tempo
    public static int desvenko = 0;
    public static int counter = valcont;
    public Text ttemp;



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

    int val = 1;
    // Use this for initialization
    void Start () {
        
        ttemp.text = "" + counter;

        StartCoroutine(CountDownTimer());

        incorrect = 0;
        tincorrect.text = "Incorrecto =  " + incorrect;

        // Random colores text
       /* System.Random r2 = new System.Random();
        vrandd = r2.Next(0, 4);
        tcolor.color = randcolor[vrandd];*/

        // color objeto este
       /* System.Random r3 = new System.Random();
        vrandd2 = r3.Next(0, 4);
        this.GetComponent<Renderer>().material.color = colorobjText[vrandd];
        print("ne korekt " + vrandd);*/

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //esconder reloj
        counter = valcont;
        ttemp.gameObject.SetActive(false);



        if (desvenko == 0)
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


                System.Random r = new System.Random();
                val = r.Next(0, 2);
                
                //val = 0;
            }
            else if(val == 0)
            {
                capsula2.GetComponent<Transform>().transform.localPosition = 
                        new Vector3(-0.3559999f, 0.25f*subir, 0.3641536f * distanc);
                this.GetComponent<Transform>().transform.localPosition = 
                        new Vector3(-0.3559999f, 0.25f*subir, -0.5148463f * distanc);

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

            // pontuacao
            incorrect += 1;
            tincorrect.text = "Incorrecto =  " + incorrect;
                if (incorrect >= 5)
                {
                    tincorrect.text = "Perdió!";
                    desvenko = 1;
                    print("valox " + desvenko);
                }

                // Random colores text
                tcolor.color = randcolor[vrandd];
            print("ne korekt e korekt" + vrandd);

            // color objeto igual valor texto
            this.GetComponent<Renderer>().material.color = colorobjText[vrandd];
            // color amigo
            capsula2.GetComponent<Renderer>().material.color = colorobjColor[vrandd];


        }

        }
        else if(desvenko == 1)
        {
            capsula2.GetComponent<Collider>().enabled = false;
            
        }



    }

    private void OnTriggerExit(Collider other)
    {

        if (desvenko == 0)
        {

            this.GetComponent<Renderer>().enabled = false;
            capsula2.GetComponent<Renderer>().enabled = false;

            this.GetComponent<Collider>().enabled = false;
            capsula2.GetComponent<Collider>().enabled = false;

            print("desativado");
            StartCoroutine(po());

        }

    }

    IEnumerator po()
    {
        yield return new WaitForSeconds(3);
        this.GetComponent<Collider>().enabled = true;
        capsula2.GetComponent<Collider>().enabled = true;

        this.GetComponent<Renderer>().enabled = true;
        capsula2.GetComponent<Renderer>().enabled = true;

        //reactivar reloj
        ttemp.gameObject.SetActive(true);
        counter = valcont;
        ttemp.text = "" + counter;
     
        print("ativado");
        Debug.Log("Acabou");
    }


    //contador
    IEnumerator CountDownTimer()
    {


        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
            ttemp.text = counter.ToString();
            if (counter == 0 && objkorekt.correct != 5)
            {
                incorrect += 1;
                tincorrect.text = "Incorrecto =  " + incorrect;
                if (incorrect >= 5)
                {
                    tincorrect.text = "Perdió!";
                    desvenko = 1;
                    break;
                }
                if (objkorekt.correct >= 5)
                {

                    objkorekt.venko = 1;
                    break;
                }
                //ttemp.text = "Stop";
                if (counter == 0)
                {
                    counter = valcont;
                }


                // break;
            }
        }//end while

        

    }

}
