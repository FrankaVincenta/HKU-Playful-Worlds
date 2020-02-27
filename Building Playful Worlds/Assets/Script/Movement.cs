using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{    // Public zorgt ervoor dat iedereen het kan benaderen
    Rigidbody player; // player is een riggidbody
    public float speed;

    public int VolgendeKleuCycle; // welke kleur moet hij uitvoeren in mijn if-statements
    public GameObject cillinder; // Definitie van een object. Public zodat we dit aan de cillinder kunnen verbinden zonder nieuw script te maken.

    // je zet iets op public zodat je het in Unity zelf kan aanpassen en andere classen benadreren
     void Start()
    {
       player = GetComponent<Rigidbody>(); // rigibody vast stellen welke het is. 

        VolgendeKleuCycle = 1; // startwaarde verbinden

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float movementHorizontal = Input.GetAxis("Horizontal"); // Registreerd de input van beweging bv wasd
        float movementVertical = Input.GetAxis("Vertical");

        player.velocity = new Vector3(movementHorizontal * speed, player.velocity.y, movementVertical * speed); // x,y,z -as
        
        
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.gameObject == cillinder)
        {
            var CilinderMaterial = cillinder.GetComponent<Renderer>(); // Pak de rendererer uit de cillinder. 

           if  (VolgendeKleuCycle == 1)
            {
                CilinderMaterial.material.SetColor("_Color", Color.black);
                VolgendeKleuCycle = 2; // ga naar volgende cycle 
            } else if (VolgendeKleuCycle == 2)
            {
                CilinderMaterial.material.SetColor("_Color", Color.yellow);
                VolgendeKleuCycle = 3;
            } else if (VolgendeKleuCycle == 3)
            {
                CilinderMaterial.material.SetColor("_Color", Color.cyan);
                VolgendeKleuCycle = 1;
            }


        }
    }

}

