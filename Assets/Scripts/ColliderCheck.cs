using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    public AudioSource winAudioSource;
    public AudioClip winAudioClip;
    public ParticleSystem[] winParticles;
    public float requiredTimeInside = 2.0f;
    private float currentTimeInside = 0.0f;
    private bool isInside = false;
    private bool hasPlayedParticles = false;
    public float particleCooldown = 5.0f;

    private bool isParkTriggerFrontActive = false;
    private bool isParkTriggerBackActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ParkTriggerFront"))
        {
            isParkTriggerFrontActive = true;
        }

        if (other.gameObject.CompareTag("ParkTriggerBack"))
        {
            isParkTriggerBackActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("ParkTriggerFront"))
        {
            isParkTriggerFrontActive = false;
        }

        if (other.gameObject.CompareTag("ParkTriggerBack"))
        {
            isParkTriggerBackActive = false;
        }

        if (isParkTriggerFrontActive && isParkTriggerBackActive)
        {
            isParkTriggerFrontActive = false;
            isParkTriggerBackActive = false;
            currentTimeInside = 0.0f;
            hasPlayedParticles = false;
        }
    }

    private void Update()
    {
        if (isParkTriggerFrontActive && isParkTriggerBackActive)
        {
            currentTimeInside += Time.deltaTime;

            if (currentTimeInside >= requiredTimeInside && !hasPlayedParticles)
            {
                Debug.Log("Both triggers are completely inside for the required time!");
                winAudioSource.PlayOneShot(winAudioClip);

                for (int i = 0; i < winParticles.Length; i++)
                {
                    StartCoroutine(PlayParticleWithDelay(winParticles[i], Random.Range(0.0f, particleCooldown)));
                }

                hasPlayedParticles = true;
            }
        }
    }

    private IEnumerator PlayParticleWithDelay(ParticleSystem particleSystem, float delay)
    {
        yield return new WaitForSeconds(delay);
        particleSystem.Play();
    }
}
