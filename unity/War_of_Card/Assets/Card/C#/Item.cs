using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Item 
{
    public string name;
    public int attack;
    public int health;
    public Sprite sprite;
    public float percent;
    public enum kind{c,m };
    public string Description;
}
//[CreateAssetMenu(fileName =)] 
public class ItemSO : ScriptableObject
    // ���� �̸� ItemSO
{
    public Item[] items;
    //Item ����Ʈ ������ ���� ����
}