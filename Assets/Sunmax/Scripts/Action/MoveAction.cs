using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class MoveAction : MonoBehaviour
{
    [SerializeField] private Transform Root;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator animator;



    [Header("Parameter")]
    public Vector3 moving;
    public Vector3 latestPos;
    public float speed = 5;
    public bool IsClicked = false;
    public Vector3 TargetPosition = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        if (Root == null) Root = this.transform;

        rb = Root.GetComponent<Rigidbody>();
        animator = Root.GetComponent<Animator>();
    }
    void Update()
    {
        IsClicked = ClickPosition();

        if (IsClicked)
        {
            var direction = new Vector3(
                TargetPosition.x - transform.position.x,
                0f,
                TargetPosition.z - transform.position.z
            );

            moving = direction.normalized * speed;
            Movement();
            return;
        }

        MovementControll();
        Movement();
    }

    void FixedUpdate()
    {
        RotateToMovingDirection();
    }

    bool ClickPosition()
    {
        if (Input.GetMouseButton(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var raycastHitList = Physics.RaycastAll(ray).ToList();
            if (raycastHitList.Any())
            {
                var distance = Vector3.Distance(Camera.main.transform.position, raycastHitList.First().point);
                var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);

                TargetPosition = Camera.main.ScreenToWorldPoint(mousePosition);
                TargetPosition.y = 0;
            }

            var ismove = new Vector2(TargetPosition.x - transform.position.x, TargetPosition.z - transform.position.z).magnitude >= 1.0f;
            return ismove;
        }
        return false;
    }
    void OnDrawGizmos()
    {
        if (TargetPosition != Vector3.zero)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(TargetPosition, 0.5f);
        }
    }

    void MovementControll()
    {
        //斜め移動と縦横の移動を同じ速度にするためにVector3をNormalize()する。
        moving = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moving.Normalize();
        moving = moving * speed;
    }
    public void RotateToMovingDirection()
    {
        Vector3 differenceDis =
            new Vector3(transform.position.x, 0, transform.position.z) - new Vector3(latestPos.x, 0, latestPos.z);
        latestPos = transform.position;
        //移動してなくても回転してしまうので、一定の距離以上移動したら回転させる
        if (Mathf.Abs(differenceDis.x) > 0.001f || Mathf.Abs(differenceDis.z) > 0.001f)
        {
            Quaternion rot = Quaternion.LookRotation(differenceDis);
            rot = Quaternion.Slerp(rb.transform.rotation, rot, 0.1f);
            this.transform.rotation = rot;
            //アニメーションを追加する場合
            animator.SetFloat("speed", moving.magnitude);
        }
        else
        {
            animator.SetFloat("speed", 0f);
        }
    }

    void Movement()
    {
        rb.velocity = moving;
    }

    float GetCurrentPositionHeight(Vector3 position)
    {
        //グローバル座標から現在の位置の高さを取得する
        var height = 0;
        return height;
    }
}
