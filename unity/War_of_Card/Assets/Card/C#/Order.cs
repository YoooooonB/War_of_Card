using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    [SerializeField] Renderer[] backrender;
    int originOrder;
    void setoriginOrder(int originOrder)
    {
        this.originOrder = originOrder;
        SetOrder(originOrder);
    }
    void MousFront(bool isMouson)
    {//Hit�� �����Ͽ� ī���� ���� ���� Ȯ�� ����
        SetOrder(isMouson ? 100 : originOrder);
    }
    void SetOrder(int order)
    {
        int mulOrder = order * 10; // �������� ��ȯ ����
        foreach (var renderer in backrender) 
        {
            renderer.sortingOrder = mulOrder;
        }
    }
    private void Start()
    {
        SetOrder(0);
    }

}
