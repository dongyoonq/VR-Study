using study0822;
using UnityEngine;

public class Monster : MonoBehaviour, IHitable
{
    [SerializeField] public int hp;

    public void Hit(int damage)
    {
        hp -= damage;

        if (hp <= 0)
            Destroy(gameObject);
    }
}