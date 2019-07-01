using UnityEngine;
using System.Collections;

public class Bloque : MonoBehaviour {

	private bool haColisionadoConElJugador = false;
	public int puntosGanados = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision){
		//nos permite saber si a colisionamos con alguna de las plataformas, para ello usaremos la informacion que nos
		//llegara en la variable collision
		//usamos el tag del personaje que es "Player"
		if(!haColisionadoConElJugador && collision.gameObject.tag == "Player"){
			GameObject obj = collision.contacts[0].collider.gameObject;
			//sirve para saber si esta haciendo colision con las patas, ya que con las otras partes tambien estaba sumando
			if(obj.name == "PataInferiorDerechaB" || obj.name == "PataInferiorIzquierdaB"){
				haColisionadoConElJugador = true;
				NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntos", puntosGanados);
			}
		}
	}
}
