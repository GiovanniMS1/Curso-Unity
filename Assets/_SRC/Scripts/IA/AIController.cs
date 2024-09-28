using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [Header("Main Data")]
    [SerializeField] private EnemyScriptable brain;

    [Header("Player Reference")]
    [SerializeField] private Transform playerTransform;

    [Header("Transform Data")]
    [SerializeField] private Transform GFXTransform;

    [Header("Scripts References")]
    private AIStates AIStatesScript;
    private AIMovement AIMovementScript;
    private AICombat AICombatScript;

    [Header("Reference Check")]
    [SerializeField] private bool referemcesOk;

    private void Init(EnemyScriptable pBrain)
    {
        referemcesOk = false;

        AIStatesScript = GetComponent<AIStates>();
        AIMovementScript = GetComponent<AIMovement>();
        AICombatScript = GetComponent<AICombat>();

        brain = pBrain;

        AICombatScript.Init(brain);

        InstantiateGraphics();
        FindPlayerReference();

        referemcesOk = true;
    }
    private void Update()
    {
        if (referemcesOk == false) return;
        if (playerTransform == null) return;

        if (AIStatesScript.States == AIStateType.CHASING)
        {
            ChaseBehaviour();
            return;
        }

        if (AIStatesScript.States == AIStateType.ATTACK)
        {
            AttackBehaviour();
            return;
        }
    }

    void ChaseBehaviour()
    {
        AIMovementScript.Chase(playerTransform);
    }

    void AttackBehaviour()
    {
        var success = AICombatScript.CheckAttack(playerTransform);

        if (success == false)
        {
            AIStatesScript.States = AIStateType.CHASING;
        }
    }

    void InstantiateGraphics()
    {
        Instantiate(brain.GFX, GFXTransform);
    }

    void FindPlayerReference()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
