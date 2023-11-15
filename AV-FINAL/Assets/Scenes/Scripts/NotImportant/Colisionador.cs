using UnityEngine;

public class Colisionador : MonoBehaviour
{
    public int powerLvl;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && powerLvl > collision.gameObject.GetComponent<Colisionador>().powerLvl)
        {
            Destroy(collision.gameObject);
            powerLvl++;
        }
        else if (collision.gameObject.CompareTag("Player") && powerLvl < collision.gameObject.GetComponent<Colisionador>().powerLvl)
        {
            Destroy(gameObject);
        }
    }
}




