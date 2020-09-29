using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    
    public Material []color;
    Material ballColor;
    Renderer rend;
    //Layermask kullanımını sor
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material = color[0];
    }
    private void FixedUpdate()
    {
        ballColor = rend.material;   
    }


    private void OnTriggerEnter(Collider other)
    {   
        
        if (other.gameObject.CompareTag("ballRed"))
        {
            rend.material = color[0];
            Destroy(other.gameObject);

        } 
        if (other.gameObject.CompareTag("ballYellow"))
        {
            rend.material= color[1];
            Destroy(other.gameObject);

        }
        if (other.gameObject.CompareTag("ballGreen"))
        {
            rend.material = color[2];
            Destroy(other.gameObject);
        }
        if (!other.GetComponent<MeshRenderer>().material.name.Equals(ballColor.name) && !other.gameObject.transform.parent.gameObject.transform.CompareTag("changeColor"))
        {
            UIManager.instance.EndGame(false);
            Destroy(transform.parent.gameObject);
        }
     
    }
 }

    


