using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour {
    public float speed = 3.0f;
    public float obsticleRange = 5.0f;
    [SerializeField] private GameObject fireballPrefab;
    private GameObject projectile;

    public const float baseSpeed = 3.0f;

    private bool _alive;

    private void Awake()
    {
        Messenger.AddListener<float>(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    void OnDestroy()
    {
        Messenger.RemoveListener<float>(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    private void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
    }

    // Use this for initialization
    void Start () {
        _alive = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    if (projectile == null)
                    {
                        projectile = Instantiate(fireballPrefab) as GameObject;
                        projectile.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        projectile.transform.rotation = transform.rotation;

                    }
                } else if (hit.distance < obsticleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
	}

    public void SetAlive (bool alive)
    {
        _alive = alive;
    }
}
