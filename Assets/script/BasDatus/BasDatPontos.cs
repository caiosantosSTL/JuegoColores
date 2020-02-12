using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BasDatPontos : MonoBehaviour {
   /* private IDbConnection conect;
    private IDbCommand comand;
    private IDataReader read;*/


    //private string dbFile = "URI=file:" + Application.dataPath + "/BasDat/BDpuntos1.db"; 

    // Use this for initialization
    void Start () {

        
        
	}
	
	// Update is called once per frame
	void Update () {
        //Insert();
    }

    /*public void Conex()
    {
        string conn = "URI=file:" + Application.dataPath + "/BasDat/BDpuntos1.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT *  FROM Puntos";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        string query =
    "insert into puntos (Korekto, Nekorekto) values " +
    "('" + OBJkorekt1.STGcorret + "', " +

    "'" + OBJnekorekt.STGincorret + "')";

        dbcmd.CommandText = query;

            dbcmd.ExecuteNonQuery();
            print("ja foi");


        while (reader.Read())
        {
            int corect = reader.GetInt32(0);
            int necorect = reader.GetInt32(1);

            Debug.Log("value= " + corect + "  name =" + necorect );
        }


        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }*/

    /*public void Insert()
    {
        string query =
            "insert into puntos (Korekto, Nekorekto) values " +
            "('"+OBJkorekt1.STGcorret+"', " +

            "'"+OBJnekorekt.STGincorret + "')";

        comand.CommandText = query;
        if (RelojRegresiv.contador == 0)
        {
        comand.ExecuteNonQuery();
            print("ja foi");
        }


    }*/


}
