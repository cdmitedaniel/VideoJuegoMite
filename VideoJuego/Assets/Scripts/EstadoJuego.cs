using UnityEngine;
using System.Collections;
using System;
//nos permite serializar de forma binaria
using System.Runtime.Serialization.Formatters.Binary;
//para todo lo que es archivo
using System.IO;

public class EstadoJuego : MonoBehaviour {

	public int puntuacionMaxima = 0;

	public static EstadoJuego estadoJuego;
	
	private String rutaArchivo;

	void Awake(){
		rutaArchivo = Application.persistentDataPath + "/datos.dat";
		if(estadoJuego==null){
			estadoJuego = this;
			DontDestroyOnLoad(gameObject);
		}else if(estadoJuego!=this){
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		Cargar();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Guardar(){
		//se necesita una instancia de la clase que tenga el dato que queremos
		BinaryFormatter bf = new BinaryFormatter();
		//cremos un objeto con la ruta donde queremos que se guarde
		FileStream file = File.Create(rutaArchivo);
		//instanciamos la clase y se le asignan los datos directamente
		DatosAGuardar datos = new DatosAGuardar();
		datos.puntuacionMaxima = puntuacionMaxima;
		//serializamos el objeto
		bf.Serialize(file, datos);
		
		file.Close();
	}
	
	void Cargar(){
		if(File.Exists(rutaArchivo)){
			//se crea una instancia
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(rutaArchivo, FileMode.Open);
			
			DatosAGuardar datos = (DatosAGuardar) bf.Deserialize(file);
			
			puntuacionMaxima = datos.puntuacionMaxima;
			
			file.Close();
		}else{
			puntuacionMaxima = 0;
		}
	}
}
//usamos el using System para poder usar el srializable del sistema
[Serializable]
class DatosAGuardar{
	public int puntuacionMaxima;
}