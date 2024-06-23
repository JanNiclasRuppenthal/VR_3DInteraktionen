using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Video;
public class PostProcessGray : MonoBehaviour
{
    [SerializeField]
    private PostProcessVolume volume;
    [SerializeField]
    public float gameover;
    [SerializeField]
    private List<GameObject> goList;
    [SerializeField]
    private GameObject Locomotion;
    [SerializeField]
    private GameObject GameOverRoom;
    [SerializeField]
    private VideoPlayer video;
    private float timer = 0;
    public int aliveCorals = 2251;
    private bool started = false;
    // Start is called before the first frame update

    void Update(){
        if (aliveCorals <= 0 && !started){
            started = true;
            StartCoroutine(ChangeWeight(5f));
        }
    }
    
    IEnumerator ChangeWeight(float time)
    {
        float gone = 0;
        while (gone < time)
        {
            volume.weight = gone / time;
            gone += Time.deltaTime;
            yield return null;
        }
        volume.weight = 0;

        foreach (GameObject go in goList)
        {
            go.SetActive(false);
        }
        foreach (GameObject gameObject in GameObject.FindObjectsOfType<GameObject>())
        {
            if (gameObject.name.StartsWith("Fish"))
            {
                gameObject.SetActive(false);
            }
        }
        GameOverRoom.transform.position = Locomotion.transform.position;
        GameOverRoom.transform.rotation = Quaternion.Euler(GameOverRoom.transform.rotation.eulerAngles.x, Locomotion.transform.eulerAngles.y, GameOverRoom.transform.rotation.eulerAngles.z);
        GameOverRoom.SetActive(true);
        video.Play();
    }
}
