using UnityEngine;

public class Drop : MonoBehaviour
{
    public Texture[] partTexture = new Texture[6];
    public GameObject part;
    private int position = 0;

    public void drop()
    {
        if (position < partTexture.Length)
        {
            dropPart(position);
            position++;
        }
    }

    private void dropPart(int partId)
    {
        Vector3 position = transform.position + new Vector3(0, -0.5f, 0);
        GameObject bodyPart = (GameObject) Instantiate(part, position, Quaternion.identity);
        bodyPart.GetComponent<MeshRenderer>().material.mainTexture = partTexture[partId];
    }
}
