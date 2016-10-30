using UnityEngine;
using UnityEngine.SceneManagement;

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
            GetComponent<Jump>().PrepareJump();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            toPosition = Input.mousePosition;
            if ((fromPosition - toPosition).y < 0)
            {
                Debug.Log("NOP NOP NOP");
                GetComponent<Jump>().BreakUpJump();
                return;
            }
            jump(calculateJump(fromPosition, toPosition));
        }
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private Vector3 calculateJump(Vector3 from, Vector3 to)
    {
        Vector3 vector = from - to;
        vector /= damper;
        return reduceVector(vector + new Vector3(0, 2, 0));
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
        GetComponent<Jump>().StartJump(jumpVector);
    }
}