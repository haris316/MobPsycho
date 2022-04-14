using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject gameWonPanel;
    public GameObject gameLostPanel;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;
    
    public BattleState state;
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    //coroutines are functions that work independent of other functions
    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();


        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

       dialogueText.text = "The " + enemyUnit.unitName + " is here! Fight and Win!";
       playerHUD.SetHUD(playerUnit);
       enemyHUD.SetHUD(enemyUnit);

       yield return new WaitForSeconds(2f);

       state = BattleState.PLAYERTURN;
       PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        //Check if enemy is dead
        //Change State based on what happened
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "The attack is successful";

        yield return new WaitForSeconds(2f);

        if(isDead){
            //end battle
            state = BattleState.WON;
            StartCoroutine(EndBattle());
        }
        else{
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

    }

    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(10);

        playerHUD.SetHP(playerUnit.currentHP);
        dialogueText.text = "You feel renewed strength";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.unitName + " attacks!";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if(isDead)
        {
            state = BattleState.LOST;
            StartCoroutine(EndBattle());
        }
        else{
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    IEnumerator EndBattle()
    {
        if(state == BattleState.WON)
        {
            dialogueText.text = "You have defeated the enemy!";
            yield return new WaitForSeconds(4f);
            gameWonPanel.SetActive(true);
        }
        else{
            dialogueText.text = "You were defeated!";
            yield return new WaitForSeconds(4f);
            gameLostPanel.SetActive(true);
        }
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose an action:";
    }

    public void OnAttackButton()
    {
        if(state != BattleState.PLAYERTURN)
        return;

        StartCoroutine(PlayerAttack());
    }

    public void OnHealButton()
    {
        if(state != BattleState.PLAYERTURN)
        return;

        StartCoroutine(PlayerHeal());
    }




}
    
