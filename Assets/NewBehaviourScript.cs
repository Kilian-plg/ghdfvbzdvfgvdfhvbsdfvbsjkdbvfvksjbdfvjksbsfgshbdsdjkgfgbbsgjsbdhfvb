using UnityEngine;
using UnityEngine.AI;
public class NewBehaviourScript : MonoBehaviour
{
    public NavMeshAgent agent2; 
    public float stopDistance = 2.5F; // Distance minimale avant d'arrêter la poursuite

    private Vector3 lastTargetPosition;

    void Update()
    {
        if (PlayerController.instance != null)
        {
            // Récupérer la position actuelle du joueur
            Vector3 targetPos = PlayerController.instance.GetPlayerPosition();

            // Vérifier la distance entre l'agent et le joueur
            float distanceToPlayer = Vector3.Distance(agent2.transform.position, targetPos);

            // Si la distance est supérieure à la distance minimale ou que la cible a changé, recalculer le chemin
            if (distanceToPlayer > stopDistance || targetPos != lastTargetPosition)
            {
                agent2.SetDestination(targetPos);
                lastTargetPosition = targetPos; 
            }
            else
            {
                // Arrêter le mouvement si l'agent est dans la portée minimale
                agent2.ResetPath(); 
            }
        }
    }
}
