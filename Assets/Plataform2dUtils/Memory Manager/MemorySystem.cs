using System.Collections;
//esta tambien se necesita para la memoria
using System.Collections.Generic;
using UnityEngine;
//transforma la información a binario
using System.Runtime.Serialization.Formatters.Binary;
//controla el input y output de los datos
using System.IO;

namespace Platform2DUtils.MemorySystem
{
     public class MemorySystem
    {
        public static void SaveData(GameData gameData)
        {
            string path = $"{Application.persistentDataPath}/myGame.data";
            //este objeto se usa para que formatee un espacio en la memoria y deje espacio en donde se va a guardar lo que quieras
            BinaryFormatter bf = new BinaryFormatter();
            //archivo de tramado de datos, que es el encargado de traer la información y el que se va a convertir en binario
            //asi se concatena en vez de con el + 
            FileStream file = File.Create(path);
            //se convierte a string en formato json para poder serializarlo
            string json= JsonUtility.ToJson(gameData);
            //se serializa el filestream y el object que se quiere guardar, lo que se va a convertir en trama de datos
            bf.Serialize(file,json);
            //de preferencia se cierra la comunicación por optimización
            file.Close();
            Debug.Log(path);
        }
    }
}

