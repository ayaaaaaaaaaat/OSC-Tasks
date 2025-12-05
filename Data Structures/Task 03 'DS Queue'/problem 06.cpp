class Solution {
public:
    int findTheWinner(int n, int k) {
        vector<bool> arr(n,1);
        int cnt = 0,last_removed=-1,i=k-1;
        while(1){
            i%=n;
            if(!arr[i]) {
                i++;
                continue;
            }
            last_removed = i;
            arr[i]=0;
            cnt++;
            if(cnt == n)break;
            int j = 0 ;i=(i+1)%n;
            while(j < k-1){
                if(arr[i]) j++;
                i=(i+1)%n;
            }
        }
        return last_removed+1;
    }
};
// class Solution {
// public:
//     int findTheWinner(int n, int k) {
//         queue<int> q;
//         for(int i = 1 ; i < n+1 ; ++i)
//             q.push(i);
//         while(q.size()!=1){
//             int j = 0;
//             while(j < k-1){
//                 q.push(q.front());
//                 q.pop();
//                 j++;
//             }  
//             q.pop(); 
//         }
//         return q.front() ;
//     }
// };