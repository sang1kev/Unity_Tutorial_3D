using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public ParticleSystem ps;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ps.Play();
            ps.Pause();
            ps.Stop();
        }
    }
}