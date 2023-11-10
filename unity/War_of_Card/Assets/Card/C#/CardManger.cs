using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject[] cardPrefabs; // ī�� ������ => dack

    private float cardXOffset = 15.0f; // �� ī���� x �� ����
    private float nextCardX = 0.0f; // ���� ī���� x ��ġ
    private float cardZOffset = -1.0f; // �� ī���� z �� ����
    private float nextCardZ = 0.0f; // ���� ī���� z ��ġ
    private List<GameObject> DackList = new List<GameObject>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            CreateCard();
        }
    }
    void CreateCard()
    {
        // ������ ī�� �������� ���� => dack �ȿ��� ī�� ���
        // cardPrefabs => dack 
        int randomIndex = Random.Range(0, cardPrefabs.Length);
        GameObject newCardPrefab = cardPrefabs[randomIndex];

        // �� ī�� ���� -> ������ dack�� �������� �ʱ� ���ؼ� ���ο� 
        GameObject newCard = Instantiate(newCardPrefab);

        // �� ī���� ��ġ�� �����Ͽ� ��ġ�� �ʰ� ����ϴ�.
        newCard.transform.position += new Vector3(nextCardX, 0, nextCardZ);
        // ���� ī���� ��ġ�� ������Ʈ
        nextCardX += cardXOffset;
        nextCardZ += cardZOffset;

        DackList.Add(newCard);
    }
    
}