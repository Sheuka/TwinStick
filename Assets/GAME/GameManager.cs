using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool recording = true;

    private float initialFixedDelta;
    private bool isPaused = false;

	// Use this for initialization
	void Start () {
        PlayerPrefsManager.DesbloquearNivel(2);
        print(PlayerPrefsManager.EsNivelDesbloqueado(1));
        print(PlayerPrefsManager.EsNivelDesbloqueado(2));
        initialFixedDelta = Time.fixedDeltaTime;
    }
	
	// Update is called once per frame
	void Update () {
        if(CrossPlatformInputManager.GetButton("Fire1")) {
            recording = false;
        } else {
            recording = true;
        }

        if(Input.GetKeyDown(KeyCode.P) && !isPaused) {
            isPaused = true;
            PauseGame();
        } else if (Input.GetKeyDown(KeyCode.P) && isPaused) {
            isPaused = false;
            ResumeGame();
        }
    }

    void PauseGame() {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }

    void ResumeGame() {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = initialFixedDelta;
    }
}
