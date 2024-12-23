using UnityEngine;

public class MainCamera : MonoBehaviour
{
    #region Singleton
    public static MainCamera instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject target;


    void Update()
    {
        if (target != null)
        {
            transform.position = target.transform.position;
        }
    }

    public void ChangeTarget(GameObject gameObject)
    {
        if (target != null)
        {
            target = gameObject;
        }
    }
}
