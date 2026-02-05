using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float span = 0.3f;
    float delta = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject enemy = Instantiate(enemyPrefab);
            int px = (Random.Range(0, 4) - 2) * 2;            
            enemy.transform.position = new Vector3(8, px, 0);
            enemy.transform.rotation = new Quaternion(0, 1, 0, -1);
        }

    }
}
