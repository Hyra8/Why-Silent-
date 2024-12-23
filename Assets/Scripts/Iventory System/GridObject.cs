using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class GridObject : MonoBehaviour
{
    public int column;
    public int row;
    public float width;
    public float height;
    [SerializeField] List<GameObject> objects;


    private List<GameObject> hierachyObjects;

    private void FixedUpdate()
    {
        GetAllChildObjects(hierachyObjects);
    }

    private void Awake()
    {
        GetAllChildObjects(hierachyObjects);
    }

    public void GetAllChildObjects(List<GameObject> container)
    {

        foreach (Transform child in transform)
        {
            container.Add(child.gameObject);
        }
        Debug.Log("Count:" + hierachyObjects.Count);
    }


    public void Sort()
    {
        if (row < 1 || column < 1)
        {
            Debug.Log("So hang/cot khong hop le");
            return;
        }

        for (int i = 0; i < row; i++)
        {
            float posY = transform.position.y - (i * height + height / 2);

            for (int j = 0; j < column; j++)
            {
                if (objects.Count < row * column)
                {
                    Debug.Log("ko co du object");
                    return;
                }
                if (objects[i * row + j] == null)
                {
                    Debug.Log("object null");
                    return;
                }
                float posX = transform.position.x + j * width + width / 2;
                objects[i * column + j].transform.position = new Vector3(posX, posY, 0);
            }
        }
    }

    /// <summary>
    /// Hàm tự sắp sếp các Child Object thuộc Grid Object
    /// </summary>
    public void SortByHierachy()
    {
        if (row < 1 || column < 1)
        {
            Debug.Log("So hang/cot khong hop le");
            return;
        }

        if (hierachyObjects.Count < row * column)
        {
            Debug.Log("ko co du object");
        }

        for (int i = 0; i < row; i++)
        {
            float posY = transform.position.y - (i * height + height / 2);

            for (int j = 0; j < column; j++)
            {
                if (i * column + j >= hierachyObjects.Count)
                {
                    return;
                }

                float posX = transform.position.x + j * width + width / 2;
                hierachyObjects[i * column + j].transform.position = new Vector3(posX, posY, 0);
            }
        }
    }

    private void OnDrawGizmos()
    {
        GetAllChildObjects(hierachyObjects);
        SortByHierachy();
        hierachyObjects.Clear();
    }
}
