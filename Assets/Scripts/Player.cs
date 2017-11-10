using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D rb;
	//Contagem do tempo do tiro
	private float shootTimer = 0;

	public GameObject laserObject;
    //Controle de velocidade da aeronave
    public float speedy = 4f;
	//Tempo para o próximo tiro
	public float minTimeToShoot = 1f;
    //Explosão da nave
    public GameObject explosionObject;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	void Update(){
		//Contador de Tempo do tiro
		if(minTimeToShoot > shootTimer){
			shootTimer += Time.deltaTime;
		}
		//Só Atira quando é precionado
		if(Input.GetKeyDown(KeyCode.Space)){
			Shoot ();
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //Configuração do teclado para movimentação
        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
        }else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
        }
        if(Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
        }else if(Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
        }

        rb.velocity = dir * speedy;
	}

	private void Shoot()
	{
		if(minTimeToShoot > shootTimer){
			return;
		}
		shootTimer = 0;
		if (laserObject != null) {
			Vector3 pos = this.transform.position;
			GameObject.Instantiate (laserObject, pos, Quaternion.identity);
		

		}

	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Verifico se o meteoro colidiu com a nave
        if(collision.collider.tag == ("Meteor"))
        {
            GameObject.Instantiate(explosionObject, this.transform.position, Quaternion.identity);
            GameObject.Destroy(this.gameObject);
            GameObject.Find("MainCamera").GetComponent<MainCameraScript>().ShowRestartBtn();
        }
    }
}
