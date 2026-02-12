/*

class Node {
public:
    int data;
    Node* next;

    Node(int x) {
        data = x;
        next = NULL;
    }
};
*/
class Solution {
  public:
    bool areIdentical(Node *head1, Node *head2) {
        // code here
        Node *it1 = head1 , *it2 = head2 ;
        bool flg = 1;
        while(it1 && it2){
            if(it1->data != it2->data) return 0;
            it1=it1->next;
            it2=it2->next;
        }
        if(it1 != NULL || it2 != NULL)return 0;
        return 1;
    }
};