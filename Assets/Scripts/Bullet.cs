using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public GameObject impact_effect; // impact effect when hit;
    public int attackdmg = 0;
    public string defTag = "Defense";
    public string Killabletag = "Enemy";
    public void Seek(Transform _target) // bullet seeking the target called in turrent script
    {
        target = _target;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return; // destroy takes a time so return ends it quicker and if the target is gone in the end of the stage and becomes null
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame) // if this happens than we hit something of some form
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Killabletag) // calls if trigger collider colides with player
        {
            HitTarget();
            return;
            //Debug.Log("killableobject has enter the field");
        }
        if (other.gameObject.tag == defTag) // calls if trigger collider colides with player
        {
            Destroy(gameObject);
            return;
            //Debug.Log("killableobject has enter the field");
        }
    }
    void HitTarget()
    {
        GameObject effectins = (GameObject)Instantiate(impact_effect, transform.position, transform.rotation);
        Destroy(effectins, 2f);
        //Destroy(target.gameObject); // gonna set this to do set amount of damage to enemies
        Enemyhealth enemyhp = target.gameObject.GetComponent<Enemyhealth>();
        enemyhp.TakeDamage(attackdmg);
        Destroy(gameObject);
        return;
    }
}
