/*
struct Node {
  int data;
  struct Node *next;
  Node(int x) {
    data = x;
    next = NULL;
  }
};
*/

// Function to insert a node in the middle of the linked list.
class Solution {
  public:
    Node *insertInMiddle(Node *head, int x) {
        // Code Here
        Node *it = head;
        int cnt = 0 ;
        while(it){
            cnt++;
            it = it->next;
        }
        Node *ins = new Node(x);
        if(!cnt) return ins;
        cnt = (cnt-1)/2;
        it = head;
        while(cnt--)
            it=it->next;
        ins->next = it->next;
        it->next = ins;
        return head;
    }
};