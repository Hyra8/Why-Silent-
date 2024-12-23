using UnityEngine;



public class DraggableObjectCanvas : MonoBehaviour
{
    public int width;

    public int height;

    public MoveDirection direction;

    [SerializeField] private Grid grid;

    private Vector2 position;

    private Rigidbody2D rb;
    private bool isDrag = false;

    private void Awake()
    {
        if (grid == null)
        {
            grid = GetComponentInParent<Grid>();
        }
        rb = GetComponent<Rigidbody2D>();

        transform.localScale = new Vector3(width, height);

    }

    private void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.velocity = Vector2.zero;

    }
    private void OnMouseDrag()
    {
        Debug.Log("OnMouseDrag");
        position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb.MovePosition(position);

    }

    private void OnMouseUp()
    {
        Debug.Log("OnMouseUp");
        SnappedPosition();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    public void SnappedPosition()
    {
        Vector3Int cellPosition = grid.LocalToCell(grid.WorldToLocal(transform.position));

        Debug.Log("snappedPosition" + cellPosition);

        switch (direction)
        {
            case MoveDirection.Horizontal:
                rb.MovePosition(new Vector2(cellPosition.x + (width / 2f), rb.position.y));
                break;
            case MoveDirection.Vertical:
                rb.MovePosition(new Vector2(rb.position.x, cellPosition.y + (height / 2f)));
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.otherCollider.gameObject.name + " Va chạm với: " + collision.gameObject.name);
    }
}


public enum MoveDirection
{
    Vertical,
    Horizontal
}