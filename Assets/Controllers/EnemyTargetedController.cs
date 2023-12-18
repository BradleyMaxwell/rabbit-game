using System.Collections;
using UnityEngine;

[RequireComponent(typeof(TargetedAbility), typeof(EnemyMovement))]
public class EnemyTargetedController : MonoBehaviour // this script defines how enemies with targeted abilities will act by default
{
    private TargetedAbility targetedAbility; // the component which handles the enemy's targeted ability
    private EnemyMovement enemyMovement; // the component that controls the movement of the enemy
    [SerializeField] private GameObject target; // what the enemy is chasing and using their ability on
    private enum EnemyState
    {
        CHASING,
        CASTING_ABILITY
    }
    private EnemyState enemyState; // used to define how the enemy will act in a given state

    private void Awake()
    {
        targetedAbility = GetComponent<TargetedAbility>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    private void Start()
    {
        enemyState = EnemyState.CHASING; // enemy should start chasing when they are first spawned
    }

    // Update is called once per frame
    void Update()
    {
        switch (enemyState)
        {
            case EnemyState.CHASING:
                if (targetedAbility.IsInRange(target.transform))
                {
                    enemyMovement.StopChasing(); // if the enemy is in range for their ability, it makes no sense to keep chasing
                    if (targetedAbility.IsOffCooldown())
                    {
                        enemyState = EnemyState.CASTING_ABILITY;
                    }
                }
                else
                {
                    enemyMovement.Chase(target.transform);
                }
                break;
            case EnemyState.CASTING_ABILITY:
                StartCoroutine(CastAbilityAndWait());
                enemyState = EnemyState.CHASING;
                break;
        }
    }

    private IEnumerator CastAbilityAndWait() // need this in order to wait for Use effect coroutine to finish
    {
        yield return StartCoroutine(targetedAbility.Use(target));
    }
}
