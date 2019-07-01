using UnityEngine;
using System.Collections;

public class Generador : MonoBehaviour {

	public GameObject[] obj;
	public float tiempoMin = 1.25f;
	public float tiempoMax = 2.5f;

	private bool fin = false;

	// Use this for initialization
	void Start () {
		//llamamos la Generar funcion para q inicie al jugar
		//Generar();

		//llamamos la funcion NotificationCener que queremos enterarnos cada vez que el personaje
		//empieza a correr y se lo anade al Observer y el nombre de la identificacion, para llamar al metodo "PersonajeEmpiezaACorrer"
		NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeEmpiezaACorrer");
		NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
	}
	
	void PersonajeHaMuerto(){
		fin = true;
	}
	void PersonajeEmpiezaACorrer(Notification notificacion){
		Generar();
	}

	// Update is called once per frame
	void Update () {
		
	
	}

	void Generar(){
		if(!fin){
		//metodo
		//se le da la referencia al objeto que se quiere instanciar, en el vector obj es donde 
		//guardaremos el objeto que se quiere instanciar y se eligira uno aleatoriamente
		Instantiate(obj[Random.Range(0,obj.Length)], transform.position, Quaternion.identity);
		//minimo 0, maximo el .lenght, y darle la posicion donde se lo instanciara
		
		//creamos un Invoke se generaran uno detras de otro con la llamada a la misma funcion (llamada de una funcion
		//dentro de otra funcion)
		Invoke("Generar", Random.Range(tiempoMin, tiempoMax));
		//entre comillas el nombre del metodo que se quiere llamar, y despues el tiempo que se demorara en generar
	}
	}
}
