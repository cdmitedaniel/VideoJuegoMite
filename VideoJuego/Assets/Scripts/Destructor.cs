using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

//metodo que se llamara cuando colisione con otro colider, recibe el collider2D y destruimos el objeto
//con el que se colisiono
	void OnTriggerEnter2D(Collider2D other){
		//si el collider con el que se colisiono esta marcado con el tag de "Player"
		//esto implica que el personaje se murio por la caida
		if(other.tag == "Player"){
			NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeHaMuerto");
			GameObject personaje = GameObject.Find("Personaje");
			personaje.SetActive(false);
			//Debug.Break();
			// POR HACER... HACER QUE SE MUESTRE LA PUNTUACION MAXIMA
			// (HA MUERTO EL PERSONAJE)
		}else{
			Destroy(other.gameObject);
		}
	}
}
