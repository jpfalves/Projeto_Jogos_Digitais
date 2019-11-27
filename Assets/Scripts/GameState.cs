using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FGameState
{
    public enum EState { MainMenu, Map1, GameOver};
    private EState currentEState = EState.MainMenu;
    private Fstate _currentState = null;

    public void onUpdate()
    {
       EState frameState = _currentState.onUpdate();
    }
    
}

public abstract class Fstate
{
    protected Fstate _nextState;

    public abstract void onBegin();
    public abstract FGameState.EState onUpdate();
    public abstract void onEND();

}

public class Fmenu : Fstate
{
    public override void onBegin()
    {
        throw new System.NotImplementedException();
    }

    public override FGameState.EState onUpdate()
    {
        return FGameState.EState.MainMenu;
    }

    public override void onEND()
    {
        throw new System.NotImplementedException();
    }
}
