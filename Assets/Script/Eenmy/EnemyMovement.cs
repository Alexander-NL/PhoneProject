using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [Header("Object Reference")]
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Transform player;
    [SerializeField] Transform enemyRespawn;
    [SerializeField] SkillButton skillButton;
    [SerializeField] EnemyTest enemyTest;

    [Header("Layer Masks")]
    [SerializeField] private LayerMask wallLayer;

    private const string STUNNED_TRIGGER_PARAM = "Stunned";
    private bool stunnedTrigger;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    [Header("Reference")]
    public NavMeshAgent Agent;
    public bool canChangeDirection;

    public bool isPaused;

    private void Start()
    {
        Agent.updateRotation = false;
        Agent.updateUpAxis = false;
    }

    public void TurnOnStunTrigger()
    {
        stunnedTrigger = true;
    }

    private void Update()
    {
        isPaused = playerMovement.isPaused;
        if (skillButton.PlayerUseSkill)
        {
            StartCoroutine(InvulnerabilityTimer(skillButton.duration));
        }
        if (ShouldStopMovement())
        {
            StopAgentInstantly();
        }
        else
        {
            Agent.SetDestination(player.position);
        }
    }

    IEnumerator InvulnerabilityTimer(float duration)
    {
        enemyTest.TurnOffBox();
        if (stunnedTrigger)
        {
            animator.SetTrigger(STUNNED_TRIGGER_PARAM);
            stunnedTrigger = false;
        }
        yield return new WaitForSeconds(duration);
        enemyTest.TurnOnBox();
    }
    
    private bool ShouldStopMovement()
    {
        return playerMovement.playerWon || playerMovement.isDead || skillButton.PlayerUseSkill || isPaused;
    }

    private void StopAgentInstantly()
    {
        Agent.isStopped = true;
        Agent.ResetPath();
        Agent.velocity = Vector2.zero;
    }

    public void ResetEnemy()
    {
        transform.position = enemyRespawn.position;
        Agent.isStopped = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(IsWall(collision.gameObject))
        {
            canChangeDirection = true;
        }
    }

    private bool IsWall(GameObject obj)
    {
        return wallLayer == (wallLayer | (1 << obj.layer));
    }
}