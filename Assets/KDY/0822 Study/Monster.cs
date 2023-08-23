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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("충돌감지");

        if (collision.gameObject.layer == LayerMask.NameToLayer("Weapon"))
        {
            Debug.Log($"{collision.gameObject.GetComponent<Weapon>().damage} 데미지 받음");  
            Hit(collision.gameObject.GetComponent<Weapon>().damage);
        }
    }
}