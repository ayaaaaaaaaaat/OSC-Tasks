class Solution {
public:
    int timeRequiredToBuy(vector<int>& tickets, int k) {
        int cnt = 0,i = 0;                        
        while (1) {               
            i = i % tickets.size();    
            if (!tickets[i]) {  
                i++; 
                continue;
            }
            tickets[i]--;
            cnt++;
            if (i == k && tickets[i] == 0) break;
            i++;               
        }
        return cnt;
    }
};

// class Solution {
// public:
//     int timeRequiredToBuy(vector<int>& tickets, int k) {
//         queue<int> q;
//         for (int i = 0; i < tickets.size(); i++)
//             q.push(i);     
//         int cnt = 0;
//         while (!q.empty()) {
//             cnt++;
//             int x = q.front();
//             tickets[x]--;
//             q.pop();
//             if (x == k && tickets[x] == 0)
//                 break;
//             if (tickets[x] > 0)
//                 q.push(x);
//         }
//         return cnt;
//     }
// };