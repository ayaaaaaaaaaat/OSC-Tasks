/* The structure of the Linked list Node is as follows:

struct Node
{
    int data;
    Node *next;
    Node(int val)
    {
        data=val;
        next=NULL;
    }
};

*/

class Solution {
  public:
    Node* findIntersection(Node* head1, Node* head2) {
        // code goes here.
        Node *it1 = head1 , *it2 = head2 , *ans = NULL,*last = NULL;
        while(it1 && it2){
            if(it1->data > it2->data)
                it2=it2->next;
            else if(it1->data < it2->data)
                it1=it1->next;
            else {
                if(ans == NULL){
                    ans = new Node(it1->data);
                    last = ans;
                }
                else{
                    Node* tmp = new Node(it1->data);
                    last->next = tmp;
                    last = tmp;
                }
                it1 = it1->next;
                it2 = it2->next;
            }  
        }
        return ans;
    }
};