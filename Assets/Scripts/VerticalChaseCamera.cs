using UnityEngine;

public class VerticalChaseCamera : MonoBehaviour
{
    public GameObject chasedObject;
    public double MinimumY;
    public double MaximumY;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (chasedObject.transform.position.y > MinimumY &&
            chasedObject.transform.position.y < MaximumY)
        {
            transform.position = new Vector3(transform.position.x, chasedObject.transform.position.y,
                transform.position.z);
        }
    }
}