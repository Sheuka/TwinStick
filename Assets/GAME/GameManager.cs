using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool recording = true;

	// Use this for initialization
	void Start () {
        PlayerPrefsManager.DesbloquearNivel(2);
        print(PlayerPrefsManager.EsNivelDesbloqueado(1));
        print(PlayerPrefsManager.EsNivelDesbloqueado(2));
    }
	
	// Update is called once per frame
	void Update () {
        if(CrossPlatformInputManager.GetButton("Fire1")) {
            recording = false;
        } else {
            recording = true;
        }
    }
}
