//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{
//    public float moveSpeed = 5f; // 移動速度

//    void Update()
//    {
//        // 入力を取得
//        float horizontal = Input.GetAxis("Horizontal"); // A, D キー
//        float vertical = Input.GetAxis("Vertical");     // W, S キー

//        // 移動方向を作成
//        Vector3 direction = new Vector3(horizontal, 0, vertical);

//        // 移動処理
//        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);

//        // 向きを進行方向に回転させる（オプション）
//        if (direction != Vector3.zero)
//        {
//            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.2f);
//        }
//    }
//}

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical"); // W：上昇、S：下降
        Vector3 move = new Vector3(0, vertical, 0) * moveSpeed * Time.fixedDeltaTime;

        Vector3 targetPosition = rb.position + move;

        //  Y=0以下には移動しない
        if (targetPosition.y < 0f)
        {
            targetPosition.y = 0f;
        }

        rb.MovePosition(targetPosition);
    }
}
