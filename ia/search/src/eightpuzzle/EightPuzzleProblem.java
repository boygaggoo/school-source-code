package eightpuzzle;

import agent.Action;
import agent.Problem;
import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;

public class EightPuzzleProblem extends Problem<EightPuzzleState> {
    
    private EightPuzzleState goalState;
    
    public EightPuzzleProblem(EightPuzzleState initialState){
        super(initialState, new ArrayList<Action>());
        actions.add(new ActionUp());
        actions.add(new ActionRight());
        actions.add(new ActionDown());
        actions.add(new ActionLeft());
        this.goalState = new EightPuzzleState(EightPuzzleState.goalMatrix);
    }
    
    public List<EightPuzzleState> executeActions(EightPuzzleState state){
        List<EightPuzzleState> sucessors = new LinkedList<EightPuzzleState>();
        
        for(Action action : actions){
            if(action.isValid(state)){
                EightPuzzleState sucessor = (EightPuzzleState) state.clone();
                action.execute(sucessor);
                sucessors.add(sucessor);
            }
        }
        
        return sucessors;
    }
    
    public EightPuzzleState getGoalState(){
        return goalState;
    }
    
    public boolean isGoal(EightPuzzleState state){
        return goalState.equals(state);
    }
    
    @Override
    public double computePathCost(List<Action> path){
        return path.size();
    }
}
