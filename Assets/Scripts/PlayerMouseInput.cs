using UnityEngine;

public class PlayerMouseInput : MonoBehaviour
{
    private Vector3 fromPosition;
    private Vector3 toPosition;
    private float damper = 20;
    private float jumpHeight = 10;
    private float jumpLength = 5;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fromPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            toPosition = Input.mousePosition;
            jump(calculateJump(fromPosition, toPosition));
        }
    }

    private Vector3 calculateJump(Vector3 from, Vector3 to)
    {
        Vector3 vector = from - to;
        Debug.Log("Vector: " + vector);
        vector /= damper;
        Debug.Log("Damped Vector: " + vector);
        return reduceVector(vector);
    }

    private Vector3 reduceVector(Vector3 vector)
    {
        float x = reduceValue(vector.x, jumpLength);
        float y = reduceValue(vector.y, jumpHeight);
        float z = 0;
        return new Vector3(x, y, z);
    }

    private float reduceValue(float value, float maximum)
    {
        if (value > maximum)
        {
            return maximum;
        }
        if (value < -maximum)
        {
            return -maximum;
        }
        return value;
    }

    private void jump(Vector3 jumpVector)
    {
        Debug.Log("Hello Jump with " + jumpVector);
        GetComponent<Jump>().StartJump(jumpVector);
    }
}
