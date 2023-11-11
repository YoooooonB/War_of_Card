using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CardManager : MonoBehaviour
{
    public GameObject[] cardPrefabs; // ī�� ������ => dack

    private float cardXOffset = 15.0f; // �� ī���� x �� ����
    private float nextCardX = 0.0f; // ���� ī���� x ��ġ
    private float cardZOffset = -1.0f; // �� ī���� z �� ����
    private float nextCardZ = 0.0f; // ���� ī���� z ��ġ
    private List<GameObject> DackList = new List<GameObject>();

    //ui �Ѱ����� ��ũ��Ʈ
    public Camera camera;

    // �ӽ÷� ī�� ������ public ���� �޾ƿ�
    public GameObject card;

    //ī�� �ö� ����
    GameObject summonObject = null;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();


        //ī�� �ö� ���� ����
        for (int j = 0; j < this.transform.childCount; j++)
        {
            if (this.transform.GetChild(j).name == "CardHint")
            {
                summonObject = this.transform.GetChild(j).gameObject;
            }
        }
    }
    private void Update()
    {
        MouseKeyDown_object();
        MouseKeyUp_object();
        if (Input.GetKeyDown(KeyCode.C))
        {
            CreateCard();
        }
    }
    void MouseKeyUp_object()
    {
        if (Input.GetMouseButtonUp(0))
        {
            for (int j = 0; j < summonObject.transform.childCount; j++)
            {
                Destroy(summonObject.transform.GetChild(j).gameObject);
            }
        }
    }

    //���콺 Ŭ�����϶� �ش��ϴ� ��ü�� ī�� ������ ���
    void MouseKeyDown_object()
    {

        // ��Ŭ��
        if (Input.GetMouseButton(0))
        {
            GameObject hitObject;


            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            //ī�޶󿡼� �߻��� ������ ��Ʈ��
            if (Physics.Raycast(ray, out hit))
            {
                // Debug.Log(hit.transform.gameObject.name);
                hitObject = hit.transform.gameObject;
                // if���ǿ� �˸´� ������Ʈ 
                if (true)
                {
                    if (summonObject != null && summonObject.transform.childCount == 0)
                    {
                        Get_Card(hitObject.name).transform.parent = summonObject.transform;
                        GameObject obj = summonObject.transform.GetChild(0).gameObject;
                        if (camera.ScreenToViewportPoint(hitObject.transform.position).x < 0)
                        {
                            obj.transform.localPosition = new Vector3(+250, hitObject.transform.position.y, -120);
                        }
                        else
                        {
                            obj.transform.localPosition = new Vector3(-250, hitObject.transform.position.y, -120);

                        }
                    }
                }
            }
        }
    }
    public GameObject Get_Card(String s)
    {
        GameObject obj = Instantiate(card, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject gameObject;
        for (int i = 0; i < obj.transform.childCount; i++)
        {
            if (obj.transform.GetChild(i).name == "Name")
            {
                gameObject = obj.transform.GetChild(i).gameObject;

                for (int j = 0; j < gameObject.transform.childCount; j++)
                {
                    if (gameObject.transform.GetChild(j).name == "Name_text")
                    {
                        gameObject = gameObject.transform.GetChild(j).gameObject;
                    }
                }
                if (gameObject.name == "Name_text")
                {
                    gameObject.GetComponent<TextMeshPro>().text = s;
                    break;
                }
            }
        }


        obj.transform.parent = this.transform;

        obj.transform.localPosition = new Vector3(0, 0, -120);
        // obj.transform.position=new Vector3(0,0,-120);
        obj.transform.localRotation = Quaternion.identity;
        // obj.transform.rotation = Quaternion.identity;
        obj.transform.localScale = new Vector3(60, 60, 1);
        // obj.transform.localScale = new Vector3(1,1,1);

        return obj;
    }
    void CreateCard()
    {
        // ������ ī�� �������� ���� => dack �ȿ��� ī�� ���
        // cardPrefabs => dack 
        int randomIndex = Random(cardPrefabs.Length);
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