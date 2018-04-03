using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private CharacterController _charController;
    public float gravity = -9.8f;
    public const float baseSpeed = 6.0f;

    private void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
    }

    // Use this for initialization
    void Start () {
        _charController = GetComponent<CharacterController>();
	}

    public float speed = 1.0f;

	// Update is called once per frame
	void Update () {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
	}
}
