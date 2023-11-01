using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card_Hand : MonoBehaviour
{
    public GameObject[] cardPrefab; // ī�� ������
    private float cardXOffset = 5.0f; // �� ī���� X �� ����
    private float nextCardX = 0.0f; // ���� ī���� X ��ġ
    private float cardZOffset = 0.5f; // �� ī���� Z �� ����
    private float nextCardZ = 0.0f; // ���� ī���� Z ��ġ
    private AudioSource cardAudioSource;
    int draw_count = 0;
    private void Update()
    {
        // Ư�� Ű (��: 'C' Ű)�� ������ �� ī�带 �����մϴ�.
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (draw_count <= 5)
            {
                SpawnCard();
                draw_count++;
            }
        }
    }

    void SpawnCard()
    {
        int minR = 0, maxR = 4;
        int IndexR = Random.Range(minR, maxR);
        // �� ī�� ����
        GameObject newCard = Instantiate(cardPrefab[IndexR]);

        // �� ī���� Y ��ġ�� �����Ͽ� ��ġ�� �ʰ� ����ϴ�.
        Vector3 cardPosition = new Vector3(nextCardX, 0, nextCardZ);
        newCard.transform.position = cardPosition;

        // ���� ī���� X, Z ��ġ�� ������Ʈ
        nextCardX += cardXOffset;
        nextCardZ -= cardZOffset;
    }
}
