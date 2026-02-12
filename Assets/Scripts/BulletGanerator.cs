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
            GameObject tagM = GameObject.Find("TagManager");
            GameObject deadM = GameObject.Find("DeadManager");
            GameObject hitM = GameObject.Find("HitManager");
            pos = GameObject.Find("Red").transform.position;//ÉqÉGÉâÉãÉLÅ[ÇÃ"player"ÇåüçıÇµéÊìæ
            pos.x = pos.x + 5.2f;
            pos.y = pos.y + 1.55f;

            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = pos;
            CollsionManager coll = bullet.GetComponent<CollsionManager>();
            coll.tagManager = tagM.GetComponent<TagManager>();
            coll.deadManager = deadM.GetComponent<DeadManager>();
            coll.hitManager = hitM.GetComponent<HitManager>();
        }
    }
}