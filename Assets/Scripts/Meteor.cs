using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

	private Rigidbody2D rb;
    //Acesso a cor 
    private SpriteRenderer render;

    public GameObject explosionObject;
    public float meteorSpeedy = 5f;
    public int healt = 3;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        rb.velocity = Vector2.down * meteorSpeedy;
        render = GetComponent<SpriteRenderer>();
	}

    public void Hit()
    {
        healt -=1;
        //Troco a cor do meteoro de acordo com o hit
        switch (healt)
        {
            case 1:
                render.color = Color.red;
                break;
            case 2:
                render.color = Color.yellow;
                break;
            default:
                render.color = new Color(122,66,6);
                break;
            
        }
        if (healt == 0)
        {
            GameObject.Find("MainCamera").GetComponent<MainCameraScript>().AddPoints();
            GameObject.Instantiate(explosionObject,transform.position,Quaternion.identity);
            GameObject.Destroy(this.gameObject);
        }
        
    }
}
