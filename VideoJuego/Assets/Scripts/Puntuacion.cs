using UnityEngine;
using System.Collections;

public class Puntuacion : MonoBehaviour {

	public int puntuacion = 0;
	public TextMesh marcador;

	// Use this for initialization
	void Start () {
		//llamamos el metodo "IncrementarPuntos"
		NotificationCenter.DefaultCenter().AddObserver(this, "IncrementarPuntos");

		NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
		ActualizarMarcador();
	}
	//aqui comprobaremos la puntiacion actual con la del record que sera la maxima
	void PersonajeHaMuerto(Notification notificacion){
		//si la puntuacion maxima de disco es mayor a nombre de la clase. nombre de variable estatica
		//estadoJuego y de alli a la instancia de la clase que es puntuacionMaxima
		if(puntuacion > EstadoJuego.estadoJuego.puntuacionMaxima){
			//antes de guardar actualizamos el valor de la variable
			EstadoJuego.estadoJuego.puntuacionMaxima = puntuacion;
			EstadoJuego.estadoJuego.Guardar();
		}
	}

	void IncrementarPuntos(Notification notificacion){
		//enviaremos la cantidad de puntos que se podra incrementar y estos seran de los datos que nos
		//nos lleguen de la norificacion y hacemos el cat del tipo de objeto que meteremos
		int puntosAIncrementar = (int)notificacion.data;
		puntuacion+=puntosAIncrementar;
		//Debug.Log("Incrementado "+puntosAIncrementar+" puntos. Total ganados: "+puntuacion);
		ActualizarMarcador();
	}
	
	void ActualizarMarcador(){
		marcador.text = puntuacion.ToString();
	}

	// Update is called once per frame
	void Update () {
	
	}
}
