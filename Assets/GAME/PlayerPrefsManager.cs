using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string CLAVE_VOLUMEN_MAESTRO = "volumen_maestro";
	const string CLAVE_DIFULTAD = "dificultad";
	const string CLAVE_NIVEL = "nivel_desbloqueado_";
	
	public static void SetVolumenMaestro(float volumen) {
		if(volumen >= 0f && volumen <= 1f) {
			PlayerPrefs.SetFloat(CLAVE_VOLUMEN_MAESTRO, volumen);
		} else {
			Debug.LogError("Volumen maestro fuera de rango");
		}
	}
	
	public static float GetVolumenMaestro() {
		return PlayerPrefs.GetFloat(CLAVE_VOLUMEN_MAESTRO);
	}
	
	public static void DesbloquearNivel(int nivel) {
		if(nivel < Application.levelCount) {
			PlayerPrefs.SetInt(CLAVE_NIVEL + nivel.ToString(), 1);
		} else {
			Debug.LogError("El nivel que intenta desploquear no existe");
		}
	}
	
	public static bool EsNivelDesbloqueado(int nivel) {
		int nivelDesbloqueado = PlayerPrefs.GetInt(CLAVE_NIVEL + nivel.ToString());
		bool esNivelDesbloqueado = (nivelDesbloqueado == 1);
		if(nivel < Application.levelCount) {
			return esNivelDesbloqueado;
		} else {
			Debug.LogError("El nivel indicado no existe");
			return false;
		}
	}
	
	public static void SetDificultad (float dificultad) {
		if(dificultad >= 1f && dificultad <= 3f) {
			PlayerPrefs.SetFloat(CLAVE_DIFULTAD, dificultad);
		} else {
			Debug.LogError("La dificultad indicada esta fuera de rango");
		}
	}
	
	public static float getDificultad () {
		return PlayerPrefs.GetFloat(CLAVE_DIFULTAD);
	}
}
