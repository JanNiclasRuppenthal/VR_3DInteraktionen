using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breatheParticles : MonoBehaviour
{
    [SerializeField]
    private useMic mic;
    [SerializeField]
    private ParticleSystem particles;
    [SerializeField]
    private AudioSource audioS;
    [SerializeField]
    private float freqTime = 10f;
    private float loudness;
    private float factor;
    private float passedTime = 0f;
    private ParticleSystem.EmissionModule emission;
    // Start is called before the first frame update
    void Start()
    {
        emission = particles.emission;
        freqTime *= 2;
    }

    // Update is called once per frame
    void Update()
    {
        loudness = mic.getLoudness();
        if(loudness == 0)
        {
            particles.Stop();
            if (audioS.isPlaying)
            {
                audioS.Stop();
            }
        }
        else
        {
            particles.Play();
            factor = loudness * 1000;
            factor = Mathf.Clamp(factor, 7 * Mathf.Abs(Mathf.Sin((Mathf.PI / freqTime) * passedTime)), 100);
            emission.rateOverTime = factor;

            if(factor > 5 && !audioS.isPlaying)
            {
                audioS.Play();
            }
            passedTime += Time.deltaTime;
        }
    }
}
