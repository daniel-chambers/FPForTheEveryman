<Query Kind="Program" />

void Main()
{
    var stateChanges = new List<StateChange>
    {
        new StateChange { State = State.State1, DateTime = new DateTime(2015, 7, 1) },
        new StateChange { State = State.State2, DateTime = new DateTime(2015, 7, 2) },
        new StateChange { State = State.State3, DateTime = new DateTime(2015, 7, 5) },
    };

    ImperativeToViewModel(stateChanges).Dump();
}
 
public enum State
{
    State1, State2, State3,
}

public class StateChange
{
    public State State { get; set; }
    public DateTime DateTime { get; set; }
}

public class StateChangeViewModel
{
    public State State { get; set; }
    public DateTime DateTime { get; set; }
    public TimeSpan Duration { get; set; }
}

// Time Difference Between States
// ------------------------------
// State2 - State1
// State3 - State2
// Now    - State3

public IList<StateChangeViewModel> ImperativeToViewModel(IList<StateChange> stateChanges)
{
    var viewModels = new List<StateChangeViewModel>();
    
    //Loop starting from one in
    for (int i = 1; i <= stateChanges.Count; i++)
    {
        //Get previous state
        var currentState = stateChanges[i - 1];
               
        DateTime nextDate;
        if (i >= stateChanges.Count) //If we're at the end...
            nextDate = DateTime.UtcNow; //..use now time
        else
            nextDate = stateChanges[i].DateTime;
            
        var viewModel = new StateChangeViewModel
        {
            State = currentState.State,
            DateTime = currentState.DateTime,
            Duration = nextDate - currentState.DateTime,
        };
        viewModels.Add(viewModel); //Side effect against mutable list
    }
    
    return viewModels;
}

public IList<StateChangeViewModel> FunctionalToViewModel(IList<StateChange> stateChanges)
{
    var offByOneStates = stateChanges
        .Skip(1)
        .Concat(new[] { new StateChange { DateTime = DateTime.UtcNow } });
        
    return stateChanges
        .Zip(offByOneStates, (current, next) => new StateChangeViewModel
        {
            DateTime = current.DateTime,
            State = current.State,
            Duration = next.DateTime - current.DateTime
        })
        .ToList();
}
