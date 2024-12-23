using UnityEngine;

public class Ghost : MonoBehaviour
{
    [Header("Colliders")]
    public CircleCollider2D visionRange;
    public Collider2D ghostBody;

    [Header("interaction")]
    public GameObject player;
    public bool chasePlayer = false;

    [Header("Movement")]
    public int currentPointIndex = 0;
    public float moveSpeed = 2f;
    public GameObject[] targetPoints;

    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.IsTouching(visionRange))
            {
                Debug.Log("it's looking");
                chasePlayer = true;
            }
            if (collision.IsTouching(ghostBody))
            {
                GameManager.instance.GameOver();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("it's not looking");
            chasePlayer = false;
            SetClosestPointAsTarget();
        }
    }

    void Update()
    {
        if (!chasePlayer)
        {
            Patrol();
        }
        else
        {
            Chase();
        }
    }
    void Patrol()
    {
        if (currentPointIndex >= targetPoints.Length || targetPoints[currentPointIndex] == null)
        {
            SetClosestPointAsTarget();
            return;
        }

        Vector3 target = targetPoints[currentPointIndex].transform.position;
        // Di chuyển vật thể tới điểm hiện tại
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        // Kiểm tra xem đã tới điểm hiện tại chưa
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            // Nếu đã tới, chọn điểm tiếp theo
            currentPointIndex++;

            // Nếu đã đến điểm cuối, đi về điểm đầu
            if (currentPointIndex >= targetPoints.Length)
            {
                currentPointIndex = 0; // Đi ngược lại về điểm đầu 
            }
        }
    }
    void Chase()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        if (targetPoints != null && targetPoints.Length > 1)
        {
            for (int i = 0; i < targetPoints.Length; i++)
            {
                if (targetPoints[i] == null)
                {
                    Debug.Log("Null targetPoint");
                    return;
                }
                // Hiển thị điểm
                Gizmos.DrawSphere(targetPoints[i].transform.position, 0.1f);

                // Vẽ đường nối giữa các điểm
                if (i < targetPoints.Length - 1)
                {
                    Gizmos.DrawLine(targetPoints[i].transform.position, targetPoints[i + 1].transform.position);
                }
            }

            // Vẽ đường nối từ điểm cuối về điểm đầu
            Gizmos.DrawLine(targetPoints[targetPoints.Length - 1].transform.position, targetPoints[0].transform.position);
        }
    }
    public void SetClosestPointAsTarget()
    {
        if (targetPoints.Length == 0)
        {
            Debug.Log("No targetPoint available");
            return;
        }

        float closestDistance = Vector3.Distance(transform.position, targetPoints[0].transform.position);
        int closestPointIndex = 0;

        // Duyệt qua tất cả các điểm để tìm điểm gần nhất
        for (int i = 0; i < targetPoints.Length; i++)
        {
            float distanceToPoint = Vector3.Distance(transform.position, targetPoints[i].transform.position);
            if (distanceToPoint < closestDistance)
            {
                closestDistance = distanceToPoint;
                closestPointIndex = i;
            }
        }

        // Cập nhật currentPointIndex để di chuyển đến điểm gần nhất
        currentPointIndex = closestPointIndex;
        Debug.Log("Closest point set as target: " + targetPoints[currentPointIndex]);
    }
}
