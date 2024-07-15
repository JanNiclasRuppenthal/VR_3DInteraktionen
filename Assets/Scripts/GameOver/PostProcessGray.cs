using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
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
    private List<GameObject> turtleList;
    [SerializeField]
    private GameObject swarmUnitParent;
    [SerializeField] 
    private CoralManager coralManager;
    [SerializeField]
    private GameObject locomotion;
    [SerializeField]
    private GameObject gameOverRoom;
    [SerializeField]
    private VideoPlayer video;
    [SerializeField]
    private AudioSource audioS;
    [SerializeField] private GameObject wasteSpawner;
    public int aliveCorals;
    private bool _started = false;
    // Start is called before the first frame update

    void Update(){
        if (aliveCorals <= 0 && !_started){
            _started = true;
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

        foreach (Transform waste in wasteSpawner.transform)
        {
            Destroy(waste.gameObject);
        }
        
        // deactivate waste spawner
        wasteSpawner.SetActive(false);
        
        gameOverRoom.transform.position = locomotion.transform.position;
        gameOverRoom.transform.rotation = Quaternion.Euler(gameOverRoom.transform.rotation.eulerAngles.x, locomotion.transform.eulerAngles.y, gameOverRoom.transform.rotation.eulerAngles.z);
        gameOverRoom.SetActive(true);
        video.Play();
        audioS.Play();
    }

    public void RestartGame()
    {
        // video.Stop();
        // audioS.Stop();
        //
        // foreach (GameObject go in goList)
        // {
        //     go.SetActive(true);
        // }
        //
        // foreach (Transform child in swarmUnitParent.transform)
        // {
        //     child.gameObject.SetActive(true);
        // }
        //
        // for (int index = 0; index < coralManager.CallCounts.Length; index++)
        // {
        //     coralManager.CallCounts[index] = 0;
        // }
        //
        //
        // gameOverRoom.SetActive(false);
        // wasteSpawner.SetActive(true);
        // aliveCorals = 9048;
        // _started = false;
        
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);

    }
}
