using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCreator : MonoBehaviour {

    public GameObject meteorObject;
    public float minTimeCreator = 1f;
    public float maxTimeCreate = 3f;

    private float timeToNextCreator;
    private float countTimer;
    //Limites da tela para criação do Meteoro
    private float xMin;
    private float xMax;

	// Use this for initialization
	void Start () {
        float horizontalExtension = Camera.main.orthographicSize * Screen.width / Screen.height;
        xMin = -horizontalExtension * 0.8f;
        xMax = horizontalExtension * 0.8f;
        GenerateNextTime();
	}
	
	// Update is called once per frame
	void Update () {
        countTimer += Time.deltaTime;
        if(countTimer >= timeToNextCreator)
        {
            countTimer = 0;
            GenerateNextTime();

            Vector3 pos = transform.position;
            pos.x = Random.Range(xMin, xMax);
            GameObject.Instantiate(meteorObject, pos, Quaternion.Euler(0,0,Random.Range(0, 359)));
        }
	}

    private void GenerateNextTime()
    {
        timeToNextCreator = Random.Range(minTimeCreator, maxTimeCreate);
    }
}
