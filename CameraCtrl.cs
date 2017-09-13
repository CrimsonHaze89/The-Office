using UnityEngine;
using System.Collections;

public class CameraCtrl : MonoBehaviour {

	public player player;

	public bool isFollowing;

	public float xOffset;
	public float yOffset;

    public bool bounds;

    public Vector3 minCameraPosition;
    public Vector3 maxCameraPosition;

    // Use this for initialization
    void Start () 
    {
		player = FindObjectOfType<player> ();

		isFollowing = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (isFollowing)
			transform.position = new Vector3 (player.transform.position.x + xOffset, player.transform.position.y + yOffset, -8.385f);

        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPosition.x, maxCameraPosition.x),
                Mathf.Clamp(transform.position.y, minCameraPosition.y, maxCameraPosition.y),
                Mathf.Clamp(transform.position.z, minCameraPosition.z, maxCameraPosition.z));
        }
    }
}
