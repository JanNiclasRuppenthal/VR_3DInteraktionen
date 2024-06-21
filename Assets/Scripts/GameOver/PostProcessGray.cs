using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class PostProcessGray : MonoBehaviour
{
    [SerializeField]
    private PostProcessVolume volume;
    [SerializeField]
    private float gameover = 20;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameOverTime());
    }

    IEnumerator GameOverTime()
    {
        while (timer < gameover)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        volume.weight = 1;
    }
 
}
