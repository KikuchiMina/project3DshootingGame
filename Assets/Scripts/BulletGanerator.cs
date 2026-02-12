using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGanerator : MonoBehaviour
{
    public GameObject bulletPrefab;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pos = GameObject.Find("Red").transform.position;//ƒqƒGƒ‰ƒ‹ƒL[‚Ì"player"‚ğŒŸõ‚µæ“¾
            pos.x = pos.x + 5.2f;
            pos.y = pos.y + 1.55f;

            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = pos;
        }
    }
}