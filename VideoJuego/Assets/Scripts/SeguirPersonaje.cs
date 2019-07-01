using UnityEngine;
using System.Collections;

public class SeguirPersonaje : MonoBehaviour {

	//contiene la transformacion, posicion o escala del objeto que se asigne o referencie en esta variable
	public Transform personaje;
	public float separacion = 6f;
	
	// Update is called once per frame
	void Update () {
		//se accede al transform de la camara, se asigna la posicion X del personaje y los otros de la camara q son Y y Z
		transform.position = new Vector3(personaje.position.x+separacion, transform.position.y, transform.position.z);
	}
}
