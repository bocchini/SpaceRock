using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	private Rigidbody2D rb;
	//Velocidade do tiro
	public float fireSpeedy = 5f;
    //Controle da explosão
    public GameObject explosionObject;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.velocity = Vector2.up * fireSpeedy;
	}

	void OnTriggerEnter2D(Collider2D collision){
		if (collision.name == "Main Camera") {
			GameObject.Destroy (this.gameObject);
		}

        if(collision.CompareTag("Meteor"))
        {
            collision.transform.GetComponent<Meteor>().Hit();
            GameObject.Destroy(this.gameObject);
            GameObject.Instantiate(explosionObject, this.transform.position, Quaternion.identity);
        }
	}
}
