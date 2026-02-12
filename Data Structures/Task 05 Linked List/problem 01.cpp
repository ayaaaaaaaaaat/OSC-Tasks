/*
class Node {
  public:
    int data;
    Node *next;

    Node(int x) {
        data = x;
        next = NULL;
    }
};
*/

class Solution {
  public:
    vector<int> displayList(Node *head) {
        // code here
        vector <int> ans;
        Node *it = head;
        while(it){
            ans.push_back(it->data);
            it = it->next;
        }
        return ans;
    }
};