// @Author: Nathaniel Baulch-Jones

// This class gives other classes static access to events strings pertaining to actions for the entire game.

internal class GameNotification
{
    // Card Actions (AI)
    public const string PlayCard = "playCard";
    public const string CleanSlate = "clean.state";

    // Special Card Strings
    public const string TriumphCard = "triumph.card";

    // Actions
    public const string CardPlayed = "card.played";
    public const string CardPickedUp = "card.picked.up";
    public const string ActionTaken = "action.taken";
    public const string TimeRanOut = "time.ran.out";
    public const string AiTookTurn = "ai.took.turn";
    public const string PauseGame = "pause.game";

    // States
    public const string GameVictory = "game.victory";
    public const string GameDefeat = "game.defeat";
    public const string GameDraw = "game.draw";
    public const string GamePaused = "game.paused";

}