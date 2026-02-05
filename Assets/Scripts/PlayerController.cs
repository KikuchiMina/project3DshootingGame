//using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
//public class PlayerController : MonoBehaviour
//{
//    public float moveSpeed = 5f;
//    private Rigidbody rb;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//    }

//    void FixedUpdate()
//    {
//        float vertical = Input.GetAxis("Vertical"); // W：上昇、S：下降
//        Vector3 move = new Vector3(0, vertical, 0) * moveSpeed * Time.fixedDeltaTime;

//        Vector3 targetPosition = rb.position + move;

//        //  Y=0以下には移動しない
//        if (targetPosition.y < 0f)
//        {
//            targetPosition.y = 0f;
//        }

//        rb.MovePosition(targetPosition);
//    }
//}

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float acceleration = 5f;
    private Rigidbody rb;
    private float verticalVelocity = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float input = Input.GetAxis("Vertical"); // W: +1, S: -1

        // 徐々に入力方向に近づける（滑らかに加減速）
        verticalVelocity = Mathf.Lerp(verticalVelocity, input * moveSpeed, Time.fixedDeltaTime * acceleration);

        Vector3 move = new Vector3(0, verticalVelocity, 0) * Time.fixedDeltaTime;
        Vector3 targetPosition = rb.position + move;

        // Y=0以下に行かないよう制限
        if (targetPosition.y < 0f)
        {
            targetPosition.y = 0f;
            verticalVelocity = 0f; // 接地時は速度もゼロにする
        }

        rb.MovePosition(targetPosition);
    }
}
