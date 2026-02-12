/*
class Node
{
public:
    int data;
    Node *prev;
    Node *next;

    Node(int x)
    {
        data = x;
        prev = nullptr;
        next = nullptr;
    }
};
*/

class Solution {
  public:
    Node *rotateDLL(Node *head, int p) {

        // code here..
        Node* tmp = head;
        Node* it = head;
        int cnt = 0 ;
        while(it){
            ++cnt;
            it=it->next;
        }
        p%=cnt;
        if(p == 0)return head;
        it = head;
        while(--p)
            it = it->next;  
        head = it->next;
        head->prev = NULL;
        it->next = NULL;
        it = head;
        while(it->next)
            it=it->next;
        it->next = tmp;
        tmp->prev = it;
        return head;
    }
};