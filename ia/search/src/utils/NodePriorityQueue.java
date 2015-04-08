package utils;

import agent.State;
import java.util.HashMap;
import java.util.PriorityQueue;
import searchmethods.Node;

public class NodePriorityQueue extends PriorityQueue<Node> implements NodeCollection {

    private HashMap<State, Node> contents;

    public NodePriorityQueue() {
        super();
        contents = new HashMap<State, Node>(128);
    }

    @Override
    public boolean add(Node e) {
        contents.put(e.getState(), e);
        return super.add(e);
    }

    @Override
    public void clear() {
        super.clear();
        contents.clear();
    }

    @Override
    public boolean remove(Object o) {
        if (o instanceof Node) {
            Node no = (Node) o;
            contents.remove(no.getState());
        }
        return super.remove(o);
    }

    @Override
    public Node remove() {
        Node no = super.remove();
        contents.remove(no.getState());
        return no;
    }

    @Override
    public boolean containsState(State e) {
        return contents.containsKey(e);
    }

    public Node getNode(State e) {
        return contents.get(e);
    }

    public boolean removeNode(State e) {
        return remove(contents.get(e));
    }
}
