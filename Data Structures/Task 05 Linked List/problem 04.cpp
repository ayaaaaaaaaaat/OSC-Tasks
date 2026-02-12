/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     ListNode *next;
 *     ListNode() : val(0), next(nullptr) {}
 *     ListNode(int x) : val(x), next(nullptr) {}
 *     ListNode(int x, ListNode *next) : val(x), next(next) {}
 * };
 */
class Solution {
public:
    ListNode* reverseList(ListNode* head) {
       ListNode* it = head;
       ListNode* prev = NULL;
       while(it){
        ListNode *tmp = it->next;
        it->next = prev;
        prev = it;
        it = tmp;
       }
       return prev;
    }
};