using UnityEngine;
using System.Collections;

public class MyReplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MyKeyFrame testKey = new MyKeyFrame(1.0f, Vector3.up, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

public class MyKeyFrame {
    public float frameTime;
    public Vector3 position;
    public Quaternion rotation;

    public MyKeyFrame(float aTime, Vector3 aPosition, Quaternion aRotation) {
        frameTime = aTime;
        position = aPosition;
        rotation = aRotation;
    }
}
