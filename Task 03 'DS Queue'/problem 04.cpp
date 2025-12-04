class Solution {
public:
    int timeRequiredToBuy(vector<int>& tickets, int k) {
        queue<int> q;
        for (int i = 0; i < tickets.size(); i++)
            q.push(i);     
        int cnt = 0;
        while (!q.empty()) {
            cnt++;
            int x = q.front();
            tickets[x]--;
            q.pop();
            if (x == k && tickets[x] == 0)
                break;
            if (tickets[x] > 0)
                q.push(x);
        }
        return cnt;
    }
};