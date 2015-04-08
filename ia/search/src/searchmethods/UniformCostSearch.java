package searchmethods;

import agent.State;
import java.util.List;
import utils.NodePriorityQueue;

public class UniformCostSearch extends GraphSearch<NodePriorityQueue> {

    public UniformCostSearch() {
        frontier = new NodePriorityQueue();
    }

    // f = g
    public void addSuccessorsToFrontier(List<State> successors, Node parent) {

        double cost = s.getAction().getCost() + parent.getG();

        for (State s : successors) {
            f = g(cost);
            if (!frontier.containsState(s)) {
                if()
                cost += parent.getG();
            } else {
                ()
    
            }
        }
    }
        @Override
        public String toString
        
            () {
        return "Uniform cost search";
        }
    }
