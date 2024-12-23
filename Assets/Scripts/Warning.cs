using UnityEngine;

public class Warning : MonoBehaviour
{
    [Header("Basic")]
    [SerializeField] SpriteRenderer spriteRenderer;
    float alpha;
    [SerializeField] float distance;
    [SerializeField] float minWarningDistance = 2.4f;
    [SerializeField] float maxWarningDistance = 6;
    [SerializeField] float warningRadius = 2.4f;
    [SerializeField] bool canBlink = true;
    [SerializeField] float blinkTimeCount = 0;
    [SerializeField] float blinkTime = 0.5f;
    [SerializeField] bool isBlinking = false;

    [Header("Others")]
    [SerializeField] Transform object0;
    [SerializeField] Transform object1;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (transform.parent != null)
        {
            object0 = transform.parent.GetComponent<Transform>();
        }
    }

    void Update()
    {
        if (object1 == null || object0 == null) return;

        // Tính vector hướng từ A đến B
        Vector3 directionAB = (object1.position - object0.position).normalized;

        // Đảm bảo C nằm trên đường tròn xung quanh A với bán kính cố định
        transform.position = object0.position + directionAB * warningRadius;

        // Giữ nguyên rotation của C
        transform.rotation = Quaternion.identity;

        // Tính khoảng cách người chơi với ghost
        distance = Mathf.Clamp(
            Vector3.Distance(object0.position, object1.position),
            minWarningDistance,
            maxWarningDistance);

        // Hiêu ứng mờ/đậm
        alpha = Mathf.InverseLerp(maxWarningDistance, minWarningDistance, distance);
        //SetSpriteAlpha(alpha);

        Blink();
    }
    private void SetSpriteAlpha(float alpha)
    {
        Color color = spriteRenderer.color;
        color.a = alpha;
        spriteRenderer.color = color;
    }
    private void Blink()
    {
        if (!canBlink) return;
        blinkTimeCount += Time.deltaTime;
        if (blinkTimeCount < blinkTime) return;

        if (isBlinking)
        {
            SetSpriteAlpha(alpha / 2); // Mờ sprite
            isBlinking = false;
            blinkTimeCount = 0;
        }
        else
        {
            SetSpriteAlpha(alpha); // Làm rõ sprite
            isBlinking = true;
            blinkTimeCount = 0;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(object0.position, warningRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(object0.position, minWarningDistance);
        Gizmos.DrawWireSphere(object0.position, maxWarningDistance);
    }
}
