using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LeftRatSpawn : MonoBehaviour {
    public GameObject LeftRemyPrefab;
    public float lrespawnTime = 2.0f;
    private Vector2 leftBounds;

    // Use this for initialization
    void Start () {
        leftBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width , Screen.height, Camera.main.transform.position.z));
        StartCoroutine(lratWave());
    }
    private void spawnLeftEnemy(){
        GameObject a = Instantiate(LeftRemyPrefab) as GameObject;
        a.transform.position = new Vector2(leftBounds.x, Random.Range(-leftBounds.y, leftBounds.y));
    }
    IEnumerator lratWave(){
        while(true){
            yield return new WaitForSeconds(lrespawnTime);
            spawnLeftEnemy();
        }
    }
}
