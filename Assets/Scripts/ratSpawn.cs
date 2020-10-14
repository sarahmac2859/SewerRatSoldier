using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ratSpawn : MonoBehaviour {
    public GameObject RightRemyPrefab;
    public GameObject LeftRemyPrefab;
    public float respawnTime = 2.0f;
    private Vector2 screenBounds;

    // Use this for initialization
    void Start ()
    {
        if (!(Camera.main is null))
            screenBounds =
                Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,
                    Camera.main.transform.position.z));
        StartCoroutine(ratWave());
    }
    private void spawnEnemy(){
        GameObject a = Instantiate(RightRemyPrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x, Random.Range(-screenBounds.y, screenBounds.y));
        GameObject b = Instantiate(LeftRemyPrefab) as GameObject;
        b.transform.position = new Vector2(-20f, Random.Range(-screenBounds.y, screenBounds.y));
    }
    IEnumerator ratWave(){
        while(true){
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}
