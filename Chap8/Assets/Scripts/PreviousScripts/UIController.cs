using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIController : MonoBehaviour {
    [SerializeField] private Text scoreLabel;
    [SerializeField] private SettingsPopup settingsPopup;
    [SerializeField] private Button gear;
    private int _score;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    // Use this for initialization
    void Start () {
        settingsPopup.Close();
        _score = 0;
        scoreLabel.text = _score.ToString();
	}

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    private void OnEnemyHit()
    {
        _score++;
        scoreLabel.text = _score.ToString();
    }
    public void OnOpenSettings()
    {
        settingsPopup.Open();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gear.onClick.Invoke();
        }
    }
}
