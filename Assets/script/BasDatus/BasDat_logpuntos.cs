using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

using Mono.Data.Sqlite;
using System.Data;

public class BasDat_logpuntos : MonoBehaviour {

    public GameObject inputNOMOlog;
    public GameObject inputPASVlog;

    public GameObject pantalla_log;
    public GameObject pantalla_reg;
    public GameObject pantalla_inicial;

    //Variables para comparacion de los datos en tabla sql
    string nomox;
    string pasvortox;
    int idx;
    string fechax;

    public static int idlog;
    public static string fechanac;

    //agarra inputs de los puntos
    public GameObject EsKorekto;
    public GameObject NoEsKorekto;

    IDbConnection dbconn;
    private IDbCommand comand;
    private IDataReader reader;

    // Use this for initialization
    void Start () {
        Conect();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Conect()
    {
        string conn = "URI=file:" + Application.dataPath + "/script/BasDatus/BDKolor.db"; //Path to database.
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.


        print("Conectou logpuntos");

    }

    public void AgarrarReg()
    {
        comand = dbconn.CreateCommand();

       // string query = "SELECT * FROM Registro";
        string query = "SELECT * FROM Registro2";
        comand.CommandText = query;
        IDataReader reader = comand.ExecuteReader();

        while (reader.Read())
        {
            //agarra em array columnas de la tabla sql
            idx = reader.GetInt32(0);
            nomox = reader.GetString(1);
            pasvortox = reader.GetString(2);
            fechax = reader.GetString(3);

            print("valor de nome e pasv " + nomox + " e " + pasvortox + " e fech "+ fechax);

            if ((nomox == inputNOMOlog.GetComponent<Text>().text) && (pasvortox == inputPASVlog.GetComponent<Text>().text))
            {
                pantalla_log.SetActive(false);
                pantalla_reg.SetActive(false);
                SceneManager.LoadScene("SampleScene");
                //pantalla_inicial.SetActive(true);


                print("Nossa info aqui => " + inputNOMOlog.GetComponent<Text>().text + " *|* " + inputPASVlog.GetComponent<Text>().text);
                print("achou");
                //idlog = idx;
                print("Valor de id de log   --- " + idx);
                print("Valor de fecha de log   --- " + fechax);


                //aqui cerramos el query
                reader.Close();
                reader = null;

                //aqui fechamos o conect
                /*dbconn.Close();
                dbconn = null;*/

                //fecharemos esta base dado no codigo de pontos
                //pois so assim vai dar para resgatar o idx para o idlog e a fecha

                break;

            }
            else //indicar ya existe tal valor en la BD
            {
                print("tal valor no existe en la DB");

            }

        }
        //visualizar debug infos
        print("hohohooh " + inputNOMOlog.GetComponent<Text>().text + " ** " + inputPASVlog.GetComponent<Text>().text);

        idlog = idx;
        fechanac = fechax;
        print("Valor de id de log 2  === " + idx);


    }

    public void AgarrarPuntos()// metodo para insertar puntos
    {
        IDbCommand comand = dbconn.CreateCommand();
        /*string sqlInsert = "Insert into Puntos (correcto, incorrecto, id_reg) " +
         "values ('" + EsKorekto.GetComponent<Text>().text + "', '"  + NoEsKorekto.GetComponent<Text>().text + "' , '"+ idlog + "')";*/

        string sqlInsert = "Insert into Puntos (correcto, incorrecto, idade, id_reg) " +
       "values ('" + EsKorekto.GetComponent<Text>().text + "', '" + NoEsKorekto.GetComponent<Text>().text + "' , '" + BasDat_reg.idadex + "', '" + idlog + "')";


        comand.CommandText = sqlInsert;
        comand.ExecuteNonQuery();
        print("Colocou pontoss");

        print("valor id  " + idlog);

        comand.Dispose();
        comand = null;

        //aqui cerramos el conect
        dbconn.Close();
        dbconn = null;

        if (dbconn == null)
        {
            print("A base de dado foi desconectadoxx");
        }

    }
}
