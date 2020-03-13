using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class AttackBattleAction : GenericBattleAction
{
    public override void Action(Actor target1, Actor target2)
    {
        // randomly generate how hard we hit the other target
        // this is based on the attack range of the player and enemies actors located in BattleSystem > Actors
        var attackValue = (int)Random.Range(target1.attackRange.x, target1.attackRange.y);
        target2.DescreaseHealth(attackValue);

        var sb = new StringBuilder();

        // if the attack value is the max value or just under, its a critical hit
        if (attackValue >= target1.attackRange.y - 1)
        {
            sb.Append("Critical hit! ");
        }

        sb.Append(target1.name);
        sb.Append(" attacks ");
        sb.Append(target2.name);
        sb.Append(". ");

        // if we hit the other target at all...
        if(attackValue > 0)
        {
            sb.Append(target2.name);
            sb.Append(" loses ");
            sb.Append(attackValue);
            sb.Append(" hp. ");
        }
        else
        {
            sb.Append(target1.name);
            sb.Append(" misses!");
        }

        message = sb.ToString();

    }
}
