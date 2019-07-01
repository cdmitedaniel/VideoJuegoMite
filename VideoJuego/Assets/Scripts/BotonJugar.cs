using UnityEngine;
using System.Collections;

public class BotonJugar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		GetComponent<AudioSource>().Stop();
		GetComponent<AudioSource>().Play();
		Invoke("CargarNivelJuego", GetComponent<AudioSource>().clip.length);
	}

    [System.Obsolete]
    void CargarNivelJuego(){
		Application.LoadLevel ("GameScene");
	}
}
