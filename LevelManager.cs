using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;

	private player player;

	public GameObject deathParticle;

	public int pointPenaltyOnDeath;

	public float respawnDelay;

    private new CameraCtrl camera;

    // Use this for initialization
    void Start ()
    {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RespawnPlayer()
	{
		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo()
	{
        //Instantiate (deathParticle, player.transform.position, player.transform.rotation);
        player.enabled = false;
		player.GetComponent<Renderer>().enabled = false;
		camera.isFollowing = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		//ScoreManager.AddPoints (-pointPenaltyOnDeath);
		yield return new WaitForSeconds (respawnDelay);
        player.transform.position = currentCheckpoint.transform.position;
        player.enabled = true;
		camera.isFollowing = true;
        player.GetComponent<Renderer>().enabled = true;
	}
}
