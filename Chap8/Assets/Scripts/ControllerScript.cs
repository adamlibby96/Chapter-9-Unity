using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour {
    [SerializeField] private GameObject prefab;
    private GameObject enemy;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (enemy == null)
        {
            enemy = Instantiate(prefab) as GameObject;
            enemy.transform.position = new Vector3(0, 1, 0);
            float angle = Random.Range(0, 360);
            enemy.transform.Rotate(0, angle, 0);
        }
	}
}
