/* struct Node {
  int data;
  struct Node *next;
  Node(int x) {
    data = x;
    next = NULL;
  }
};*/

class Solution {
  public:
    int getKthFromLast(Node* head, int k) {
        // code here
        Node* it = head;
        Node* prev = NULL;
        while(it){
            Node* tmp = it->next;
            it->next = prev;
            prev = it;
            it = tmp;
        }
        it = prev;
        while(it){
            --k;
            if(k == 0)break;
            it = it->next;
        }
        if(k) return -1;    
        return it->data;
    }
};