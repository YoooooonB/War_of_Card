using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.ComponentModel;

public class Card : MonoBehaviour
{
    [SerializeField] SpriteRenderer card;
    [SerializeField] SpriteRenderer image;
    [SerializeField] TMP_Text cardname;
    [SerializeField] TMP_Text description;
    [SerializeField] TMP_Text damage;
    [SerializeField] TMP_Text time;
    [SerializeField] TMP_Text health;
    [SerializeField] TMP_Text cost;
   
    public CardData cardData;
    bool isFront;

    public void Setup(CardData cardData, bool isFront)
    {
        this.cardData = cardData;
        this.isFront = isFront;
        if(this.isFront )
        {
            image.sprite = this.cardData.card_Sprite;
            cardname.text = this.cardData.card_Name;
            if (this.cardData.card_Type == 'c')
            {//Ŀ��� ī�� ǥ��
                damage.text = this.cardData.damage.ToString();
                health.text = this.cardData.max_HP.ToString();

            }
            else if (this.cardData.card_Type == 'm')
            {//���� ī�� ǥ��

            }
            else if (this.cardData.card_Type == 'p')
            {//�ǹ� ī�� ǥ��

            }
            else 
            {//���� ī�� ǥ��

            }

        }
        else
        {// ī���� ���� 180�� ȸ�� ���Ѽ� �޸��� ǥ�� ����

        }
    }

}
