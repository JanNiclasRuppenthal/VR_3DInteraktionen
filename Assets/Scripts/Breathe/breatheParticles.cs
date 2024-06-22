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
    private float loudness;
    private float factor;
    private ParticleSystem.EmissionModule emission;
    // Start is called before the first frame update
    void Start()
    {
        emission = particles.emission;
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
            factor = Mathf.Clamp(factor, 1, 100);
            emission.rateOverTime = factor;

            if(factor > 5 && !audioS.isPlaying)
            {
                audioS.Play();
            }
        }
    }
}
