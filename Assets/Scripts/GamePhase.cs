using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GamePhase
{
    MENU,
    PICK_DICE,
    PICK_DICE_LOCATION,
    DICE_IN_AIR,
    DICE_ROLLED,
    DICE_IN_MOTION,
    DICE_LANDED,
    ROUND_IN_PROGRESS,
    ROUND_ENDED,
    PICK_BONUS,
    GAME_OVER
}
