using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float span = 0.3f;
    float delta = 0.0f;
    int app = 1;
    int px = 0;
    int cnt = 0;

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
            if (cnt % 3 == 0)
            {
                px = Random.Range(-6, 6) * 3;
                app = Random.Range(0, 5);
                this.delta = -0.8f;
            }

            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.position = new Vector3(50, px, 35);
            enemy.transform.rotation = new Quaternion(0, 1, 0, -1);

            if (3 < app && (px < -2 || 2 < px))
            {
                GameObject enemy2 = Instantiate(enemyPrefab);
                enemy2.transform.position = new Vector3(50, -px, 35);
                enemy2.transform.rotation = new Quaternion(0, 1, 0, -1);
            }

            this.delta = 0;
            cnt++;
        }

    }
}
