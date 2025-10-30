using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Transform movePoint;
    public LayerMask whatStopsMovement;
    public float previousX;
    public float previousY;
    public Animator animator;
    void Start(){
        movePoint.parent = null;
    }
    private void FixedUpdate() {

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, movePoint.position) <= 0f){
            if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f){
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .25f, whatStopsMovement)){
                    previousX = movePoint.position.x;
                    previousY = movePoint.position.y;
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
                animator.SetFloat("x", Input.GetAxisRaw("Horizontal"));
                animator.SetFloat("y", 0);
            }
            else if(Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f){
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopsMovement)){
                    previousX = movePoint.position.x;
                    previousY = movePoint.position.y;
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
                animator.SetFloat("x", 0);
                animator.SetFloat("y", Input.GetAxisRaw("Vertical"));
            }else{
                animator.SetFloat("x", 0);
                animator.SetFloat("y", 0);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision){
        movePoint.position = new Vector3(previousX, previousY);
    }
}

