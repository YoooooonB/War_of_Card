using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSO : ScriptableObject
{
    public CardData[] items;
}
public class CardMain : MonoBehaviour
{
    [SerializeField] ItemSO itemso;
    [SerializeField] GameObject[] cardPrefab;
    List<CardData> cardsBuffer;
    public CardData PopItem()//ī�� ���� ��
    {//�̹� ������ �� �����̹Ƿ� ������ ���� �ϳ���
        CardData card = cardsBuffer[0];
        cardsBuffer.RemoveAt(0);
        return card;
    }
    void SetupBuffer()
    {
        cardsBuffer = new List<CardData>(); //�� ���� ����ϱ� ������
        for(int i = 0; i < itemso.items.Length; i++)//���� ���� ī�� ���� �� = itemso.items.Length
        {
            CardData card = itemso.items[i];
            for (int j = 0; j < card.card_Cost; j++)//Cost�� ���߿� ī�尡 ���� �� ���ִ����� ����
            {//�� ����
                cardsBuffer.Add(cardsBuffer[i]);
            }
        }
        for(int i = 0;i < cardsBuffer.Count; i++)
        {//������ ������ ��� �κ�
            int rand = Random.Range(i, cardsBuffer.Count);
            CardData temp = cardsBuffer[i];
            cardsBuffer[i] = cardsBuffer[rand];
            cardsBuffer[rand] = temp;
        }
    }
    private void Start()
    {
        SetupBuffer();
    }
    public void Update()
    {
        print(PopItem().card_Name); //ī�� �̴� ���
    }
    void AddCard()
    {
        
    }
}
