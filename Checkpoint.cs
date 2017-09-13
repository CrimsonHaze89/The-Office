using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	public LevelManager levelManager;
    private Animator animator;
	
	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.name == "Bob") 
        {
        	levelManager.currentCheckpoint = gameObject;
            StartCoroutine(Do());
        }

        //ResetBool();
    }

    //IEnumerator Run(float WaitSeconds)
    //{
    //       animator.SetBool("Active", true);
    //    yield return new WaitForSeconds(WaitSeconds);
    //        animator.SetBool("Active", false);
    //}

    IEnumerator Do()
    {
        animator.SetBool("Active", true);
        yield return new WaitForSeconds(3);
        animator.SetBool("Active", false);
    }

    void ResetBool ()
    {
        animator.SetBool("Active", false);
    }
}
