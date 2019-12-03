using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public BirdState birdState {set; get;}
    private LineRenderer lineRenderer;
    private Rigidbody2D rigidbody2D;
    private CircleCollider2D circleCollider2D;
    private AudioSource audioSource;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        audioSource = GetComponent<AudioSource>();

        lineRenderer.enabled = false;
        lineRenderer.sortingLayerName = "FG";

        rigidbody2D.isKinematic = true;
        circleCollider2D.radius = GameVariables.BirdColliderRadiusBig;
        birdState = BirdState.BeforeThrown;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(birdState == BirdState.Thrown && rigidbody2D.velocity.sqrMagnitude <= GameVariables.MinVelocity){
            StartCoroutine(DestroyAfterDelay(3f));
        }
    }

    public void OnThrow(){
        audioSource.Play();
        lineRenderer.enabled = true;
        rigidbody2D.isKinematic = false;
        circleCollider2D.radius = GameVariables.BirdColliderRadiusNormal;
        birdState = BirdState.Thrown;
    }

    IEnumerator DestroyAfterDelay(float delay){
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
