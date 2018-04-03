using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeatherManager))]
public class Managers : MonoBehaviour {

    public static WeatherManager weather { get; private set; }

    private List<IGameManager> _startSequence;

    void Awake()
    {
        weather = GetComponent<WeatherManager>();

        _startSequence = new List<IGameManager>();
        _startSequence.Add(weather);

        StartCoroutine(StartupManagers());
    }

    private IEnumerator StartupManagers()
    {
        NetworkService network = new NetworkService();

        foreach(IGameManager manager in _startSequence)
        {
            manager.Startup(network);
        }

        yield return null;

        int numModules = _startSequence.Count;
        int numReady = 0;

        while (numReady < numModules)
        {
            int lastReady = numReady;
            numReady = 0;
            
            foreach(IGameManager manager in _startSequence)
            {
                if (manager.status == ManagerStatus.Started)
                {
                    numReady++;
                }
            }

            if (numReady > lastReady)
            {
                Debug.Log("Progress: " + numReady + "/" + numModules);
                yield return null;
            }

            Debug.Log("All managers started up");
        }
    }
}
