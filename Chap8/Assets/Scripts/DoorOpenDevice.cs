using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenDevice : MonoBehaviour {
    [SerializeField] private Vector3 dPos;
    public float duration = 1.0f;

    private bool _open;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
        _open = true;
    }

    public void Activate()
    {
        if (_open)
        {
            StartCoroutine(workDoor(startPos, dPos, duration));
        }
    }

    public void Deactivate()
    {
        if (!_open)
        {
            StartCoroutine(workDoor(dPos, startPos, duration));
        }
    }

    public void Operate()
    {
        if (_open)
        {
            StartCoroutine(workDoor(startPos, dPos, duration));
        } 
        else
        {
            StartCoroutine(workDoor(dPos, startPos, duration));
        }

    }

    private IEnumerator workDoor(Vector3 start, Vector3 end, float duration)
    {
        float elapsed = 0;
        while (elapsed <= duration)
        {
            float pct = elapsed / duration;
            transform.position = Vector3.Lerp(start, end, pct);
            elapsed += Time.deltaTime;
            yield return null;
        }

        _open = !_open;
    }
}
