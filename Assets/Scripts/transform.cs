using UnityEngine;

public class transform : MonoBehaviour
{
    Animator m_Animator;
    private int x = 0;
    void Start()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent<Animator>();
        m_Animator.ResetTrigger("Transform");
    }

    void Update()
    {
        if(SimpleInput.GetKey(KeyCode.Backspace)){
            m_Animator.SetTrigger("Attack");
        }

        if (SimpleInput.GetKey(KeyCode.Space))
        {
            m_Animator.SetTrigger("Transform");
            if ((x%2)==0){
                Vector3 Scaler = transform.localScale;
                Scaler.x *= -1;
                transform.localScale = Scaler;
                x=x+1;
            }
        }
    }

}