class Solution {
  public:
    void pb(deque<int>& dq, int x) {
        // code here
        dq.push_back(x);
    }

    void ppb(deque<int>& dq) {
        // code here
        //assert(!dq.empty());
        if(dq.empty()) return;
        dq.pop_back();
    }

        
    int front_dq(deque<int>& dq) {
        // code here
        //assert(!dq.empty());
        if(dq.empty()) return -1;
        return dq.front();
    }
        

    void pf(deque<int>& dq, int x) {
        // code here
        dq.push_front(x);
    }
};