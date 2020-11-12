using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExp : MonoBehaviour
{
    public float blastRadius;
    public float explosionForce;

    public GameObject smoke;
    public GameObject gunshoot;


    private Collider[] hitColliders;

    private void OnCollisionEnter(Collision col)
    {
        //Debug.Log(col.contacts[0].point.ToString());
        DoExplosion(col.contacts[0].point);
        Instantiate(smoke, transform.position, Quaternion.identity);
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void DoExplosion(Vector3 explosionPoint)
    {
        hitColliders = Physics.OverlapSphere(explosionPoint, blastRadius);

        foreach (Collider hitcol in hitColliders)
        {
            //Debug.Log(hitcol.gameObject.name);
            if (hitcol.GetComponent<Rigidbody>() != null)
            {
                if (hitcol.gameObject.tag == "Enemy")
                {
                    EnemyDamage e = hitcol.GetComponent<EnemyDamage>();

                    e.ExDamage();
                }
                if (hitcol.gameObject.tag == "Tank")
                {
                    TankDamage t = hitcol.GetComponent<TankDamage>();

                    t.ExDamage();
                }

                hitcol.GetComponent<Rigidbody>().isKinematic = false;
                hitcol.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, explosionPoint, blastRadius, .005f, ForceMode.Impulse);
                
                Destroy(gameObject);
            }
        }
        
    }
}
