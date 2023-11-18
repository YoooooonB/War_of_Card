using UnityEngine;

public class DrawCard : MonoBehaviour
{
    public GameObject cardDeck; // CardDeck���� ���� �θ� ������Ʈ�� �ν����Ϳ��� �Ҵ����ּ���.
    public GameObject cardPrefab; // Card �������� �ν����Ϳ��� �Ҵ����ּ���.

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaceRandomCard();
        }
    }

    void PlaceRandomCard()
    {
        Transform[] cards = cardDeck.GetComponentsInChildren<Transform>();

        if (cards.Length > 1)
        {
            // ������ �ε��� ����
            int randomIndex = Random.Range(1, cards.Length);

            // ���õ� Card �������� �����Ͽ� ���ο� ������Ʈ ����
            GameObject newCard = Instantiate(cardPrefab);

            Vector3 newPosition = new Vector3(67f, 34f, -19f); // ������ �ϴ�

            // �ִ� 5�� �õ��Ͽ� ��ġ�� �ʴ� ��ġ ã��
            int maxAttempts = 5;
            int attempts = 0;

            while (CheckOverlap(newPosition, 1.0f) && attempts < maxAttempts)
            {
                newPosition.x -= 10f; // �������� 10 ���� �̵�
                attempts++;
            }

            newCard.transform.position = newPosition;

            // ȸ���� ũ�� ����
            newCard.transform.rotation = Quaternion.Euler(0, 180, 0);
            newCard.transform.localScale = new Vector3(8f, 2f, 14f);
        }
    }

    // �־��� ��ġ �ֺ��� �ٸ� ī�尡 �ִ��� Ȯ���ϴ� �Լ�
    bool CheckOverlap(Vector3 position, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(position, radius); // ������ radius�� ���� ����Ͽ� �浹 üũ

        return hitColliders.Length > 0;
    }
}
