using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMove : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        //…Ë÷√LineRendererdµƒŒª÷√
        lineRenderer.SetPosition(0, transform.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit)
        {
            lineRenderer.SetPosition(1, hit.point);
        }
       
        var characterLife = hit.collider.gameObject.GetComponent<CharacterLife>();
        if (characterLife != null)
        {
            characterLife.Hit(gameObject);
            anim.SetBool("isDead", true);
        }
    }
}
