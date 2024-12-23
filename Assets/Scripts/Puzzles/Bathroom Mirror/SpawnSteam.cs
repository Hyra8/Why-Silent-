using System.Collections;
using UnityEngine;

public class SpawnSteam : MonoBehaviour
{
    BathroomMirrorPuzzle bathroomMirrorPuzzle;
    public RectTransform canvasTransform; // Tham chiếu đến RectTransform của Canvas
    public GameObject imagePrefab;       // Prefab của Image
    public float lifetime = 3f;          // Thời gian sống của Image
    public float moveSpeed = 50f;        // Tốc độ di chuyển lên trên
    public float spawnRate = 0.1f;
    public float timeCount = 0f;


    public float minX = -200f; // Giá trị x tối thiểu
    public float maxX = 200f;  // Giá trị x tối đa
    public float minY = -200f; // Giá trị y tối thiểu
    public float maxY = 200f;  // Giá trị y tối đa

    private void Start()
    {
        bathroomMirrorPuzzle = GetComponent<BathroomMirrorPuzzle>();
    }

    public void CreateFloatingImage(Vector2 startPosition)
    {
        // Tạo một instance của prefab
        GameObject imageObject = Instantiate(imagePrefab, canvasTransform);

        // Lấy RectTransform và đặt vị trí ban đầu
        RectTransform rectTransform = imageObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = startPosition;

        // Bắt đầu coroutine di chuyển và hủy
        StartCoroutine(MoveAndDestroy(imageObject, rectTransform));
    }

    private IEnumerator MoveAndDestroy(GameObject imageObject, RectTransform rectTransform)
    {
        float elapsed = 0f;

        while (elapsed < lifetime && rectTransform != null)
        {
            // Di chuyển lên trên
            rectTransform.anchoredPosition += new Vector2(0f, moveSpeed * Time.deltaTime);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Hủy đối tượng sau thời gian sống
        Destroy(imageObject);
    }

    void Update()
    {
        timeCount += Time.deltaTime;
        if (bathroomMirrorPuzzle.usingHotWaterTap && timeCount > spawnRate)
        {
            timeCount = 0f;

            // Tính toán tọa độ ngẫu nhiên trong khoảng bạn chọn
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            GetComponent<SpawnSteam>().CreateFloatingImage(new Vector2(randomX, randomY));
        }
    }
}
