using UnityEngine;



public class DraggableObject : MonoBehaviour
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


    }

    private void OnMouseDown()
    {
        /*        Debug.Log("OnMouseDown");*/
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.velocity = Vector2.zero;

    }
    private void OnMouseDrag()
    {
        /*        Debug.Log("OnMouseDrag");*/
        position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        rb.MovePosition(position);

    }

    private void OnMouseUp()
    {
        /*        Debug.Log("OnMouseUp");*/

        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    public void SnappedPosition()
    {
        Vector3Int cellPosition = grid.LocalToCell(grid.WorldToLocal(transform.position));

        Debug.Log("snappedPosition" + cellPosition);

        switch (direction)
        {
            case MoveDirection.Horizontal:
                rb.position = (new Vector2(cellPosition.x + (width / 2f), rb.position.y));
                break;
            case MoveDirection.Vertical:
                rb.position = (new Vector2(rb.position.x, cellPosition.y + (height / 2f)));
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name.Equals("Keybox"))
        {

        }

        /*Debug.Log(collision.otherCollider.gameObject.name + " ("+ collision.otherCollider.gameObject.transform.position + ") Va chạm với: " + collision.gameObject.name);*/
    }
}
