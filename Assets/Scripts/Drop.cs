using System;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public Texture[] partTexture = new Texture[6];
    public GameObject part;
    private int position = 0;
    public Material[] Materials = new Material[6];
    public Row[] Textures = new Row[7];

    void Start()
    {
        UpdateMaterials(0);
    }

    public void drop()
    {
        if (position < partTexture.Length)
        {
            dropPart(position);
            position++;
            UpdateMaterials(position);
        }
    }

    private void dropPart(int partId)
    {
        Vector3 position = transform.position + new Vector3(0, -(transform.lossyScale.y / 2), 0);
        GameObject bodyPart = (GameObject) Instantiate(part, position, Quaternion.identity);
        bodyPart.GetComponent<MeshRenderer>().material.mainTexture = partTexture[partId];
    }

    private void UpdateMaterials(int position)
    {
        for (int i = 0; i < Materials.Length; i++)
        {
            Materials[i].mainTexture = Textures[position].Textures[i];
        }
    }
}

[Serializable]
public class Row
{
    public Texture[] Textures = new Texture[6];
}
