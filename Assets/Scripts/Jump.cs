using UnityEngine;

public class Jump : MonoBehaviour
{
	private Vector3 fromPosition;
	private Vector3 toPosition;

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
			jump(fromPosition-toPosition);
		}
	}

	private void jump(Vector3 jumpVector)
	{
		GetComponent<Rigidbody>().AddForce(jumpVector);
	}
}
