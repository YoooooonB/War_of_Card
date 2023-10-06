using UnityEngine;

public class CubeInteraction : MonoBehaviour
{
    public Material hoverMaterial; // ���콺�� ������Ʈ�� ����� ���� ���׸���
    private Material originalMaterial; // ������ ���׸���

    void Start()
    {
        originalMaterial = GetComponent<Renderer>().material;
    }

    void OnMouseEnter()
    {
        GetComponent<Renderer>().material = hoverMaterial;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material = originalMaterial;
    }
}
