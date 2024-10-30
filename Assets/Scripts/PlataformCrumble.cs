using System.Collections;
using UnityEngine;


public class PlatformCrumble : MonoBehaviour
{
    public float crumbleDelay = 2f; // Time in seconds before the platform crumbles
    public float reappearDelay = 2f; // Time in seconds before the platform reappears

    private Collider2D platformCollider;
    private Renderer platformRenderer;

    void Start()
    {
        platformCollider = GetComponent<Collider2D>();
        platformRenderer = GetComponent<Renderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(CrumbleAndReappearPlatform());
        }
    }

    IEnumerator CrumbleAndReappearPlatform()
    {
        yield return new WaitForSeconds(crumbleDelay);
        platformCollider.enabled = false;
        platformRenderer.enabled = false;

        yield return new WaitForSeconds(reappearDelay);
        platformCollider.enabled = true;
        platformRenderer.enabled = true;
    }
}