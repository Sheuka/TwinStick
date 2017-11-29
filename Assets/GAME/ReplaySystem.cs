using UnityEngine;
using System.Collections;

public class ReplaySystem : MonoBehaviour {

    private GameManager gameManager;

    private const int bufferFrames = 100;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
    private Rigidbody myRigidBody;
    private bool bufferFull = false;
    private int lastFrameRecorded = 0;

    // Use this for initialization
    void Start() {
        myRigidBody = GetComponent<Rigidbody>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (gameManager.recording) {
            Record();
        } else {
            PlayBack();
        }
    }

    private void PlayBack () {
        myRigidBody.isKinematic = true;
        int framesRecorded = bufferFrames;
        /*if(!bufferFull) {
            framesRecorded = lastFrameRecorded;
        }*/
        int frame = Time.frameCount % framesRecorded;
        print("Reading frame " + frame);
        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;
    }

    private void Record() {
        myRigidBody.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;
        float time = Time.time;
        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
        /*lastFrameRecorded = frame;
        if(frame == bufferFrames - 1) {
            bufferFull = true;
        }*/
    }
}


/// <summary>
/// A structure fir storing time, rotation and position
/// </summary>
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
