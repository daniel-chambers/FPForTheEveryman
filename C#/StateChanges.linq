<Query Kind="Program" />

void Main()
{
    var stateChanges = new List<StateChange>
    {
        new StateChange { State = State.State1, StartDate = new DateTime(2015, 7, 1) },
        new StateChange { State = State.State2, StartDate = new DateTime(2015, 7, 2) },
        new StateChange { State = State.State3, StartDate = new DateTime(2015, 7, 5) },
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
    public DateTime StartDate { get; set; }
}

public class StateChangeViewModel
{
    public State State { get; set; }
    public DateTime StartDate { get; set; }
    public TimeSpan Duration { get; set; }
}

// Time Difference Between States
// ------------------------------
// State1 Duration = State2 - State1
// State2 Duration = State3 - State2
// State3 Duration = Now    - State3

public IList<StateChangeViewModel> ImperativeToViewModel(IList<StateChange> stateChanges)
{
    var viewModels = new List<StateChangeViewModel>();
    
    for (int i = 0; i < stateChanges.Count; i++)
    {
        var currentState = stateChanges[i];
               
        DateTime endDate;
        if (i < stateChanges.Count - 1)
            endDate = stateChanges[i + 1].StartDate; 
        else
            endDate = DateTime.UtcNow; //If we're at the end use now time
            
        var viewModel = new StateChangeViewModel
        {
            State = currentState.State,
            StartDate = currentState.StartDate,
            Duration = endDate - currentState.StartDate,
        };
        viewModels.Add(viewModel); //Side effect against mutable list
    }
    
    return viewModels;
}

public IList<StateChangeViewModel> FunctionalToViewModel(IList<StateChange> stateChanges)
{
    var nextStates = stateChanges
        .Skip(1)
        .Concat(new[] { new StateChange { StartDate = DateTime.UtcNow } });
        
    return stateChanges
        .Zip(nextStates, (current, next) => new StateChangeViewModel
        {
            StartDate = current.StartDate,
            State = current.State,
            Duration = next.StartDate - current.StartDate
        })
        .ToList();
}