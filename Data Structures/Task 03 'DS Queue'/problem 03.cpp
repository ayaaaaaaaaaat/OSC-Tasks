class Solution {
  public:
    queue<int> reverseFirstK(queue<int> q, int k) {
        // code here
        if(k > q.size()) return q;
        queue<int> ans;
        stack <int> tmp;
        int cnt = 0;
        while(cnt < k){
            tmp.push(q.front());
            q.pop();
            cnt++;
        }
        while(!tmp.empty()){
            ans.push(tmp.top());
            tmp.pop();
        }
        while(!q.empty()){
            ans.push(q.front());
            q.pop();
        }
        return ans;
    }
};