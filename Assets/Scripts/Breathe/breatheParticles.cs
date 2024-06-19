using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breatheParticles : MonoBehaviour
{
    [SerializeField]
    private useMic mic;
    [SerializeField]
    private ParticleSystem particles;
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
        }
        else
        {
            particles.Play();
            factor = loudness * 1000;
            factor = Mathf.Clamp(factor, 1, 200);
            emission.rateOverTime = factor;
        }
    }
}
