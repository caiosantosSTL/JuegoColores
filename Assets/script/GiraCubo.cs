using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiraCubo : MonoBehaviour {

    public float move_vel, giro_vel, alt, alt2;
    bool chao = true;
    public GameObject referencia;

    private Transform tsf;
    private Rigidbody rbody;

    // Use this for initialization
    void Start () {
        tsf = GetComponent<Transform>();
        rbody = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {

        //mover
        if (Input.GetKey(KeyCode.W))
        {
            tsf.Translate(new Vector3(-move_vel, 0, 0) * Time.deltaTime);//frente
        }
        if (Input.GetKey(KeyCode.S))
        {
            tsf.Translate(new Vector3(move_vel, 0, 0) * Time.deltaTime);//tras
        }

        //giro -y+
        if (Input.GetKey(KeyCode.D))
        {
            tsf.transform.Rotate(0, giro_vel * Time.deltaTime, 0);//dir
        }
        if (Input.GetKey(KeyCode.A))
        {
            tsf.transform.Rotate(0, -giro_vel * Time.deltaTime, 0);//esq
        }

        //lado
        if (Input.GetKey(KeyCode.E))
        {
            tsf.Translate(new Vector3(0, 0, move_vel) * Time.deltaTime);//gesq
        }
        if (Input.GetKey(KeyCode.Q))
        {
            tsf.Translate(new Vector3(0, 0, -move_vel) * Time.deltaTime);//gesq
        }

        //pulo +y
        if (Input.GetKeyDown(KeyCode.Space) && chao)
        {
            rbody.AddForce(new Vector3(0, alt, 0), ForceMode.Impulse);

        }

    }

    //fora do metodo upadte
    void OnCollisionStay(Collision collision)
    {
        chao = true;
    }
    void OnCollisionExit(Collision collision)
    {
        chao = false;
    }


    


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "pulax")
        {
            print("Item atocado");
            alt2 = 30;
            rbody.AddForce(new Vector3(0, alt, 0), ForceMode.Impulse);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "pulax")
        {
            print("Item atocado");
            
            rbody.AddForce(new Vector3(0, alt, 0), ForceMode.Impulse);

        }
    }


}
