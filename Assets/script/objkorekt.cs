using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class objkorekt : MonoBehaviour {

    public GameObject capsula;
    public Text tcolor;
    public Text tcorrect;

    int distanc = 2;
    int distanc2 = 3;
    int subir = 2;
    public static int correct;
    int val = 1;
    int vrand;
    public static int venko = 0;

    int counter;
    public Text ttemp2;

    //Array color
    private string[] colori = new string[4] {"Azul", "Rojo", "Verde", "Amarillo" };

    //color texto invers
    Color[] randcolor = {new Color(1, 0, 0, 1), new Color(1, 0.92f, 0.016f, 1),
        new Color(0, 0, 1, 1), 
        new Color(0, 1, 0, 1) };

    //color objt corret
    Color[] colorobjColor = {new Color(1, 0, 0, 1), new Color(1, 0.92f, 0.016f, 1),
        new Color(0, 0, 1, 1),
        new Color(0, 1, 0, 1) };

    //color objt del text obj incorret
    Color[] colorobjText = {new Color(0, 0, 1, 1),
        new Color(1, 0, 0, 1),new Color(0, 1, 0, 1),
        new Color(1, 0.92f, 0.016f, 1)
         };

    // Use this for initialization
    void Start () {
        // tcolor.text = "Area color ";

        this.GetComponent<Transform>().transform.localPosition = 
            new Vector3(-0.3559999f, 0.25f, 0.3641536f * distanc);

        capsula.GetComponent<Transform>().transform.localPosition = 
            new Vector3(-0.3559999f, 0.25f, -0.5148463f * distanc);

        correct = 0;
        tcorrect.text = "Correcto =  "+correct;

        //tcolor.color = randcolor[3];

        // Random colores text
        System.Random r2 = new System.Random();
        vrand = r2.Next(0, 4);

        tcolor.color = randcolor[vrand];
        tcolor.text = "== " + colori[vrand] + " ==";
        print("valor cor texto " + vrand);

        this.GetComponent<Renderer>().material.color = colorobjColor[vrand];
        print("corekto rnd " + vrand);

        // capsula extrang
        capsula.GetComponent<Renderer>().material.color = colorobjText[vrand];
        print("ne korekt " + vrand);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {

        if (venko == 0)
        {
            //esconder reloj
            objinkorekt.counter = objinkorekt.valcont;
            ttemp2.gameObject.SetActive(false);

            if (other.gameObject.tag == "jogador")
        {
            
            //this.GetComponent<Renderer>().material.color = Color.red;
            print("Triger ativado vermelho");
            print("dodod "+val);
            // this.GetComponent<Collider>().isTrigger = false;

            //-60.6f, 49.94f, -6.19f
            //-60.6f, 49.94f, -13.1f


            //capsula.GetComponent<Renderer>().material.color = Color.blue;

            // posicion
            if (val == 1)
            {
                this.GetComponent<Transform>().transform.localPosition = 
                        new Vector3(-0.3559999f, 0.25f, 0.3641536f * distanc);

                capsula.GetComponent<Transform>().transform.localPosition = 
                        new Vector3(-0.3559999f, 0.25f, -0.5148463f * distanc);

                System.Random r = new System.Random();
                val = r.Next(0, 2);
                
                //val = 0;
            }
            else if(val == 0)
            {
                capsula.GetComponent<Transform>().transform.localPosition = 
                        new Vector3(-0.3559999f, 0.25f*subir, 0.3641536f * distanc2);

                this.GetComponent<Transform>().transform.localPosition = 
                        new Vector3(-0.3559999f, 0.25f*subir, -0.5148463f * distanc2);

                System.Random r = new System.Random();
                val = r.Next(0, 2);
                //val = 1;
            }

            // Random textos
            System.Random r2 = new System.Random();
            vrand = r2.Next(0, 4);

            print(" num rand " + vrand);

           // print("Tal valor elegido de color === "+colori[vrand]);
            tcolor.text = "== "+ colori[vrand] + " ==";
            print("valor cor texto "+vrand);

            // pontuacao
            correct += 1;
            tcorrect.text = "Corecto =  " + correct;
                if (correct >= 5)
                {
                    tcorrect.text = "Ganaste!";
                    venko = 1;
                    print("valox " + venko);
                }


                // Random colores text
                tcolor.color = randcolor[vrand];

            print("corekto rnd e nkorek" + vrand);

            // color objeto igual valor colorTexto
            this.GetComponent<Renderer>().material.color = colorobjColor[vrand];
            // color amigo
            capsula.GetComponent<Renderer>().material.color = colorobjText[vrand];


        }

        }
        else if(venko == 1)
        {
            capsula.GetComponent<Collider>().enabled = false;
            
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (venko == 0)
        {

            this.GetComponent<Renderer>().enabled = false;
            capsula.GetComponent<Renderer>().enabled = false;

            this.GetComponent<Collider>().enabled = false;
            capsula.GetComponent<Collider>().enabled = false;

            print("desativado");
            StartCoroutine(po());

        }

    }



    IEnumerator po()
    {
        yield return new WaitForSeconds(3);
        this.GetComponent<Collider>().enabled = true;
        capsula.GetComponent<Collider>().enabled = true;

        this.GetComponent<Renderer>().enabled = true;
        capsula.GetComponent<Renderer>().enabled = true;

        //regresar com o reloj
        ttemp2.gameObject.SetActive(true);
        objinkorekt. counter = objinkorekt.valcont;
        ttemp2.text = ""+ objinkorekt.counter;

        print("ativado");
        Debug.Log("Acabou");
    }

    IEnumerator CountDownTimer()
    {
        while (objinkorekt.counter > 0)
        {
            yield return new WaitForSeconds(1);
            objinkorekt.counter--;
            ttemp2.text = counter.ToString();
            if (objinkorekt.counter >= 0)
            {
                correct += 1;
                tcorrect.text = "Correcto =  " + correct;
                if (correct >= 5)
                {
                    tcorrect.text = "Ganaste!";
                    venko = 1;
                    break;
                }
                //ttemp.text = "Stop";
                if (objinkorekt.counter == 0)
                {
                    objinkorekt.counter = objinkorekt.valcont;
                }

                // break;
            }
        }
    }



}
