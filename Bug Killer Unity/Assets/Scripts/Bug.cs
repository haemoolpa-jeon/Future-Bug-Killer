using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{
    private bool isDead;
    public float speed = 0.5f;

    public UnityEngine.Events.UnityEvent bugDeadEvent;

    void Start()
    {
        InvokeRepeating("ChangeDirection", 0.3f, 0.3f);
    }

    void ChangeDirection()
    {
        float angle = 0.0f;
        int random = Random.Range(0, 3);

        switch (random)
        {
            case 0:
                angle = 45;
                break;

            case 1:
                angle = 0;
                break;

            case 2:
                angle = -45;
                break;
        }

        transform.Rotate(0.0f, 0.0f, angle);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;

        transform.position += this.transform.up * speed * Time.deltaTime;
        
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator OnMouseDown()
    {
        if (isDead)
        {
            yield break;
        }

        bugDeadEvent.Invoke();

        isDead = true;
        CancelInvoke();

        Animator animator = GetComponent<Animator>();
        animator.SetBool("IsDead", true);

        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
