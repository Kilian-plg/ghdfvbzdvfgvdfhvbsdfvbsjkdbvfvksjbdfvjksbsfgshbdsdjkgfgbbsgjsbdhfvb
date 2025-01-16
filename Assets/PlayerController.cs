using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Camera cam;

    public NavMeshAgent agent;
	public static PlayerController instance;

  	private void Awake()
    {
        instance = this;
    }

    public Vector3 GetPlayerPosition()
    {
        return agent != null ? agent.transform.position : transform.position; // Retourne la position actuelle du joueur
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
			Inventory.instance.addRune(1);
			Inventory.instance.addPotion(1);
            HealthBar.instance.SetActualHealth(20);
            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Inventory.instance.addPotion(-1);
            HealthBar.instance.SetActualHealth(-20);
        }
    }
}
