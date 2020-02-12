using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using Mono.Data.Sqlite;
using System.Data;

public class BasDat_reg : MonoBehaviour {

    public GameObject inputNombre;
    public GameObject inputContrasena;
    // fecha
    public Text inputAno;
    public Text inputMes;
    public Text inputDia;

    public static int idade;
    public static string idadex;

    IDbConnection dbconn;
    private IDbCommand comand;
    private IDataReader reader;

    // Use this for initialization
    void Start () {
        Conect(); // activamos base datos

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Conect()
    {
        string conn = "URI=file:" + Application.dataPath + "/script/BasDatus/BDKolor.db"; //agarra ruta de basdato
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.


        print("Conectou registro");

    }

    public void Poner_info_reg()
    {
        // ====== Area de las fechas

        //int anoinput = 2008, mesinput = 3, diainput = 21;

        //int idade;

        

        bool falha_ingreso = false;// si hay informaciones malas, indica fallo de ingreso

        //agarra ano, mes, y dia de ahora
        int ano_atual = DateTime.Now.Year;
        int mes_atual = DateTime.Now.Month;
        int dia_atual = DateTime.Now.Day;

        //valores colocados en el input
        int an = Int32.Parse(inputAno.text);
        //**
        int mes = Int32.Parse(inputMes.text);
        //**
        int dia = Int32.Parse(inputDia.text);

        //area cod aniversario
        idade = (ano_atual - an)-1; 

        // =========== Area regla de cumpleanos

        //niver bisest
        if ((ano_atual % 400 == 0) || (ano_atual % 4 == 0 && ano_atual % 100 != 0))
        {
            // ano bis feb 29
            Console.WriteLine("E bisexto ano atual " + ano_atual);
            if (mes == mes_atual && mes_atual == 2)
            {
                if (dia == 29 && dia_atual >= 29)
                {
                    Console.WriteLine("faz niver ano bis atual em feb 29 ");
                    idade = idade + 1;
                }


            }
            else// ano bis mas nao é feb dia 29
            {

                if (mes == mes_atual)
                {
                    if (dia <= dia_atual && dia != 29)
                    {
                        Console.WriteLine("faz niver ano bis atual " + ano_atual);
                        idade = idade + 1;
                    }
                    else
                    {
                        //nao faz aniversario ainda em ano bis
                        Console.WriteLine("mantem idade ano bis atual " + ano_atual);
                    }

                }
                else if (mes <= mes_atual)
                {
                    Console.WriteLine("faz niver ano bis atual " + ano_atual);
                    idade = idade + 1;
                }
                else
                {
                    //nao faz aniversario ainda em ano bis
                    Console.WriteLine("mantem idade ano bis atual " + ano_atual);
                }

            }

        }
        else //se nao for bisexto ano atual
        {
            Console.WriteLine("E normal ano atual " + ano_atual);
            if (mes == 2 && dia == 29)
            {
                if (mes_atual == 2 && dia_atual == 28)
                {
                    //quem nasce 29 agora vai ser 1 de marco
                    //mes += 1; dia = 1;
                    Console.WriteLine("faz niver ano normal " + ano_atual + " atual em feb 29 porem em 1 de marzo ");
                    idade = idade + 1;
                }
                else if (mes_atual >= 2)
                {
                    Console.WriteLine("faz niver ano normal " + ano_atual + " atual em feb 29 porem em 1 de marzo ");
                    idade = idade + 1;
                }

            }

            if (mes == mes_atual)
            {
                if (dia <= dia_atual && dia != 29)
                {
                    Console.WriteLine("faz niver ano normal atual " + ano_atual);
                    idade = idade + 1;
                }

            }
            else if (mes <= mes_atual)
            {
                Console.WriteLine("faz niver ano normal atual " + ano_atual);
                idade = idade + 1;
            }
            else
            {
                //nao faz aniversario ainda em ano bis
                Console.WriteLine("mantem idade ano normal atual " + ano_atual);
            }
            //********************

        }


        // ============= Fin area regla cumple

        //string idadex = idade.ToString(); // salida en string de idad del usuario 
        idadex = idade.ToString();


        // ========================= Area regla de los inputs
        //incoerencia de anos
        if (an > ano_atual)
        {
            print("info  incoerente");
            falha_ingreso = true;
        }
        //ultrapasar meses
        if (mes > 12)
        {
            print("esta mal");
            falha_ingreso = true;
        }

        //regras de dias em cada mes
        if (mes == 1)
        {
            if (dia > 31)
            {
                print("esta mal");
                falha_ingreso = true;
            }
        }
        //ano bissext em feb
        if (mes == 2)
        {
            if ((an % 400 == 0) || (an % 4 == 0 && an % 100 != 0))
            {
                print("E bisexto");
                if (dia > 29)
                {
                    print("esta mal");
                    falha_ingreso = true;
                }
            }
            else
            {
                print("No e bisexto");
                if (dia > 28)
                {
                    print("esta mal");
                    falha_ingreso = true;
                }
            }

        }
        // regra dos dias do mes
        // de marz a jul
        if (mes != 2 && mes != 1 && mes >= 3 && mes < 8)
        {
            if (mes != 2 && mes % 2 == 1 || mes == 8)
            {
                print("E mes dias 31 marz a jul");
            }
            if (mes != 2 && mes % 2 == 0 && mes != 8)
            {
                print("E mes dias 30 marz a jul");
            }
        }
        // de sep a dez
        if (mes != 2 && mes != 1 && mes > 8 && mes <= 12)
        {
            if (mes % 2 == 1)
            {
                print("E mes dias 30 sep a dez");
            }
            if (mes % 2 == 0)
            {
                print("E mes dias 31 sep a dez");
            }
        }

        // ========================= Fin area reglas inputs




        // ====== Fin area fechas

        // ============ ============ ============ ============ Area de SQL input
        IDbCommand comand = dbconn.CreateCommand();

        if (falha_ingreso == true)
        {
            print("Hay informaciones incorrectas");
        }
        else // si no hay info incorrect
        {
            /*string sqlInsert = "Insert into Registro (nombre, pasvorto, fechanac) " +
 "values ('" + inputNombre.GetComponent<Text>().text + "' , '" + inputContrasena.GetComponent<Text>().text + "', '" + an.ToString() + "-"
        + mes.ToString() + "-" + dia.ToString() + "')"; // hacemos el insert*/

            string sqlInsert = "Insert into Registro2 (nombre, pasvorto, ano, mes, dia) " +
 "values ('" + inputNombre.GetComponent<Text>().text + "' , '" + inputContrasena.GetComponent<Text>().text + "', '" + an.ToString() + "', '" + mes.ToString() + "', '" + dia.ToString() + "')"; // hacemos el insert

            comand.CommandText = sqlInsert;
            comand.ExecuteNonQuery();
            print("Colocou");

            comand.Dispose();
            comand = null;

            //aqui cerramos el conect
            dbconn.Close();
            dbconn = null;

            if (dbconn == null)
            {
                print("A base de dado foi desconectado");
            }



            // salida de confirmacion ==================================
            Console.WriteLine("Aqui fazemos os inputs das variaveis de an, mes, dia, idade");
            Console.WriteLine(" " + an.ToString() + " - " + mes.ToString() + " - " + dia.ToString() + " idade " + idadex);



        }





    }



}
