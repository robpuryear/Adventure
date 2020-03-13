using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleWindow : GenericWindow
{
    public Image[] decorations;
    public GameObject actionsGroup;
    public Text monsterLabel;
    public GenericBattleAction[] actions;
    public bool nextActionPlayer = true;
    [Range(0, .9f)]
    public float runOdds = .3f;
    public RectTransform windowRect;
    public RectTransform monsterRect;
    public delegate void BattleOver(bool playerWin);
    public BattleOver battleOverCallback;

    private ShakeManager shakeManager;
    private System.Random rand = new System.Random();
    private Actor player;
    private Actor monster;


    protected override void Awake()
    {
        shakeManager = GetComponent<ShakeManager>();
        base.Awake();
    }


    public override void Open()
    {
        base.Open();

        foreach(var decoration in decorations)
        {
            decoration.enabled = rand.NextDouble() >= .5;
        }

        actionsGroup.SetActive(false);
    }

    public void StartBattle(Actor target1, Actor target2)
    {
        player = target1;
        monster = target2;

        // determine who attacks first
        nextActionPlayer = rand.NextDouble() >= .5f;

        if (nextActionPlayer)
        {
            DisplayMessage("A " + monster.name + " approaches");
        }
        else
        {
            DisplayMessage(monster.name + " attacks first");
        }

        StartCoroutine(NextAction());
        UpdateMonsterLabel();
    }

    private void DisplayMessage(string text)
    {
        var messageWindow = manager.Open((int)Windows.MessageWindow - 1, false) as MessageWindow;
        messageWindow.text = text;
    }

    IEnumerator NextAction()
    {
        yield return new WaitForSeconds(2);

        if(!player.alive || !monster.alive)
        {
            StartCoroutine(OnBattleOver());
        }
        else
        {
            if (nextActionPlayer)
            {
                actionsGroup.SetActive(true);
                OnFocus();
            }
            else
            {
                OnMonsterAction();
            }
        }
    }

    public void OnAction(GenericBattleAction action, Actor target1, Actor target2)
    {
        // attacks
        action.Action(target1, target2);

        DisplayMessage(action.ToString());
        actionsGroup.SetActive(false);

        UpdatePlayerStats();
        UpdateMonsterLabel();

        StartCoroutine(NextAction());
    }

    public void OnPlayerAction(int id)
    {
        switch (id){
        case 1:
            StartCoroutine(OnRun());
                break;
        default:
            var action = actions[id];
            OnAction(action, player, monster);
            shakeManager.Shake(monsterRect, .5f, 1);
            break;
    }
        nextActionPlayer = false;
    }

    public void OnMonsterAction()
    {
        var action = actions[0];
        OnAction(action, monster, player);
        nextActionPlayer = true;
        shakeManager.Shake(windowRect, 1f, 2);

    }

    private void UpdatePlayerStats()
    {
        ((StatsWindow)manager.GetWindow((int)Windows.StatsWindow - 1)).UpdateStats();
    }

    private void UpdateMonsterLabel()
    {
        monsterLabel.text = monster.name + " HP " + monster.health.ToString("D2");
    }

    IEnumerator OnRun()
    {
        actionsGroup.SetActive(false);

        var chance = Random.Range(0, 1f);
        if(chance < runOdds)
        {
            DisplayMessage("You were able to run away");

            yield return new WaitForSeconds(2);

            if (battleOverCallback != null)
            {
                battleOverCallback(player.alive);
            }
        }
        else
        {
            DisplayMessage("You were not able to run away");
            StartCoroutine(NextAction());
        }
    }

    IEnumerator OnBattleOver()
    {
        var message = (player.alive ? player.name : monster.name) + " has won the battle";

        var gold = Random.Range(0, monster.gold);

        // reward the player with some gold if he won the battle
        if(gold > 0 && player.alive)
        {
            message += " " + player.name + " receives " + gold + " gold.";
            player.IncreaseGold(gold);
            UpdatePlayerStats();
        }

        DisplayMessage(message);

        yield return new WaitForSeconds(2);

        if(battleOverCallback != null)
        {
            battleOverCallback(player.alive);
        }

        
    }
}
