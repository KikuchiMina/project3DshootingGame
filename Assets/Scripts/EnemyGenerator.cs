using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;
    float span = 0.3f;
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
            GameObject arrow = Instantiate(enemyPrefab);
            int px = Random.Range(-6, 7);
            arrow.transform.position = new Vector3(px, 7, 0);

        }

    }
}
